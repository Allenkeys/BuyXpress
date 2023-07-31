namespace BuyXpress.Models.Enums
{
    public enum UserType
    {
        Admin = 1,
        Merchant,
        Customer,
    }

    public static class UserTypeExtension
    {
        public static string? ToStringValue(this UserType userType)
        {
            return userType switch
            {
                UserType.Admin => "Admin",
                UserType.Merchant => "Merchant",
                UserType.Customer => "Customer",
                _ => null,
            };
        }
    }
}
