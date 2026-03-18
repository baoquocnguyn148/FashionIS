using System;
using Oracle.EntityFrameworkCore;
public class EnumChecker {
    public static void Main() {
        foreach (var name in Enum.GetNames(typeof(OracleSQLCompatibility))) {
            Console.WriteLine(name);
        }
    }
}
