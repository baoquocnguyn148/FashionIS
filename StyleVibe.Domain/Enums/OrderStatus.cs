namespace StyleVibe.Domain.Enums;

public enum OrderStatus : byte
{
    Pending = 1,
    Confirmed = 2,
    Processing = 3,
    Completed = 4,
    Cancelled = 5
}

