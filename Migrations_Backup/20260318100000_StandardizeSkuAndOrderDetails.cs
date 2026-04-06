using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionStoreIS.Data.Migrations
{
    /// <inheritdoc />
    public partial class StandardizeSkuAndOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1) Rename PRODUCTVARIANTS -> PRODUCTSKUS if needed
            migrationBuilder.Sql(@"
BEGIN
    DECLARE
        v_cnt NUMBER;
    BEGIN
        SELECT COUNT(*) INTO v_cnt FROM user_tables WHERE table_name = 'PRODUCTSKUS';
        IF v_cnt = 0 THEN
            SELECT COUNT(*) INTO v_cnt FROM user_tables WHERE table_name = 'PRODUCTVARIANTS';
            IF v_cnt > 0 THEN
                EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTVARIANTS RENAME TO PRODUCTSKUS';
            END IF;
        END IF;
    END;
END;");

            // 2) Ensure PRODUCTSKUS has required columns
            migrationBuilder.Sql(@"
BEGIN
    FOR c IN (
        SELECT 'SKU' AS COL FROM dual UNION ALL
        SELECT 'SKUCODE' FROM dual UNION ALL
        SELECT 'COSTPRICE' FROM dual UNION ALL
        SELECT 'SELLINGPRICE' FROM dual UNION ALL
        SELECT 'ISACTIVE' FROM dual
    ) LOOP
        DECLARE
            v_cnt NUMBER;
        BEGIN
            SELECT COUNT(*) INTO v_cnt
            FROM user_tab_cols
            WHERE table_name = 'PRODUCTSKUS' AND column_name = c.COL;
            IF v_cnt = 0 THEN
                IF c.COL = 'SKU' THEN
                    EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTSKUS ADD (SKU NVARCHAR2(50))';
                ELSIF c.COL = 'SKUCODE' THEN
                    EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTSKUS ADD (SKUCODE NVARCHAR2(30))';
                ELSIF c.COL = 'COSTPRICE' THEN
                    EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTSKUS ADD (COSTPRICE NUMBER(12,0) DEFAULT 0)';
                ELSIF c.COL = 'SELLINGPRICE' THEN
                    EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTSKUS ADD (SELLINGPRICE NUMBER(12,0) DEFAULT 0)';
                ELSIF c.COL = 'ISACTIVE' THEN
                    EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTSKUS ADD (ISACTIVE NUMBER(1) DEFAULT 1)';
                END IF;
            END IF;
        END;
    END LOOP;
END;");

            // 3) Ensure FK PRODUCTSKUS(PRODUCTID) -> PRODUCTS(ID) with name FK_SKU_PROD
            migrationBuilder.Sql(@"
BEGIN
    DECLARE
        v_cnt NUMBER := 0;
    BEGIN
        SELECT COUNT(*) INTO v_cnt 
        FROM user_constraints 
        WHERE constraint_name = 'FK_SKU_PROD' AND table_name = 'PRODUCTSKUS';
        IF v_cnt = 0 THEN
            -- Try create FK if PRODUCTID exists
            SELECT COUNT(*) INTO v_cnt
            FROM user_tab_cols WHERE table_name = 'PRODUCTSKUS' AND column_name = 'PRODUCTID';
            IF v_cnt > 0 THEN
                EXECUTE IMMEDIATE 'ALTER TABLE PRODUCTSKUS ADD CONSTRAINT FK_SKU_PROD FOREIGN KEY (PRODUCTID) REFERENCES PRODUCTS (ID)';
            END IF;
        END IF;
    END;
END;");

            // 4) Create ORDERDETAILS if not exists
            migrationBuilder.Sql(@"
BEGIN
    DECLARE v_cnt NUMBER := 0;
    BEGIN
        SELECT COUNT(*) INTO v_cnt FROM user_tables WHERE table_name = 'ORDERDETAILS';
        IF v_cnt = 0 THEN
            EXECUTE IMMEDIATE '
                CREATE TABLE ORDERDETAILS (
                    ID NUMBER(10) NOT NULL,
                    ORDERID NUMBER(10) NOT NULL,
                    PRODUCTSKUID NUMBER(10) NULL,
                    QUANTITY NUMBER(10) NOT NULL,
                    UNITPRICE NUMBER(12,0) NOT NULL,
                    DISCOUNTPERCENT NUMBER(5,0) DEFAULT 0 NOT NULL,
                    SUBTOTAL NUMBER(14,0) NOT NULL,
                    CREATEDAT TIMESTAMP(7) NULL,
                    CONSTRAINT PK_ORDERDETAILS PRIMARY KEY (ID)
                )
            ';
            EXECUTE IMMEDIATE 'CREATE INDEX IX_OD_ORDER ON ORDERDETAILS (ORDERID)';
            EXECUTE IMMEDIATE 'CREATE INDEX IX_OD_SKU ON ORDERDETAILS (PRODUCTSKUID)';
            EXECUTE IMMEDIATE 'ALTER TABLE ORDERDETAILS ADD CONSTRAINT FK_OD_ORD FOREIGN KEY (ORDERID) REFERENCES ORDERS (ID)';
            EXECUTE IMMEDIATE 'ALTER TABLE ORDERDETAILS ADD CONSTRAINT FK_OD_SKU FOREIGN KEY (PRODUCTSKUID) REFERENCES PRODUCTSKUS (ID)';
        END IF;
    END;
END;");

            // 5) Migrate data from ORDERITEMS to ORDERDETAILS (best-effort), then drop ORDERITEMS
            migrationBuilder.Sql(@"
BEGIN
    DECLARE
        v_has_items NUMBER := 0;
        v_has_details NUMBER := 0;
    BEGIN
        SELECT COUNT(*) INTO v_has_items FROM user_tables WHERE table_name = 'ORDERITEMS';
        IF v_has_items > 0 THEN
            SELECT COUNT(*) INTO v_has_details FROM ORDERDETAILS;
            IF v_has_details = 0 THEN
                -- Copy as best-effort: PRODUCTSKUID left NULL, SUBTOTAL from TotalPrice if exists
                EXECUTE IMMEDIATE '
                    INSERT INTO ORDERDETAILS (ID, ORDERID, PRODUCTSKUID, QUANTITY, UNITPRICE, DISCOUNTPERCENT, SUBTOTAL, CREATEDAT)
                    SELECT HILOSEQUENCE.NEXTVAL, oi.ORDERID, NULL, oi.QUANTITY, oi.UNITPRICE, 0,
                           CASE WHEN EXISTS (SELECT 1 FROM user_tab_cols WHERE table_name = ''ORDERITEMS'' AND column_name = ''TOTALPRICE'')
                                THEN oi.TOTALPRICE ELSE (oi.QUANTITY * oi.UNITPRICE) END,
                           SYSTIMESTAMP
                    FROM ORDERITEMS oi
                ';
            END IF;
            -- Drop old table to avoid confusion
            EXECUTE IMMEDIATE 'DROP TABLE ORDERITEMS CASCADE CONSTRAINTS PURGE';
        END IF;
    END;
END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No-op: down migration omitted to avoid destructive operations on production data
        }
    }
}
