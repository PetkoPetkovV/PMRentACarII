namespace PMRentACar.Infrastructure.Data.Constants
{
    public static class Constants
    {
        public const int CarNumberMaxLength = 50;
        public const int CarNumberMinLength = 6;

        public const int CarMakeMaxLength = 50;
        public const int CarMakeMinLength = 3;

        public const int CarModelMaxLength = 60;
        public const int CarModelMinLength = 1;

        public const int CarDescriptionMaxLength = 500;
    }

    public static class CustomerConstants
    {
        public const int CustomerNameMaxLength = 50;
        public const int CustomerNameMinLength = 1;

        public const int CustomerPhoneMaxLength = 50;

        public const int CustomerEmailMaxLength = 80;

        public const int CustomerAddressMaxLength = 100;
        public const int CustomerAddressMinLength = 5;
    }

    public static class CategoryConstants
    {
        public const int CategoryNameMaxLength = 50;

        public const int CategoryNameMinLength = 4;
    }

    public static class DriverConstants
    {
        public const int DriverNameMaxLength = 50;

        public const int DriverCategoryMaxLength = 30;
    }

}
