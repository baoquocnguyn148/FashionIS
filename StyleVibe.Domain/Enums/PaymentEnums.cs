namespace StyleVibe.Domain.Enums;

public enum PaymentMethod : byte
{
    Cash = 1,
    BankTransfer = 2,
    EWallet = 3,
    Card = 4
}

public enum PaymentStatus : byte
{
    Unpaid = 1,
    Paid = 2,
    Refunded = 3
}

