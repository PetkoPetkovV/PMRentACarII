namespace PMRentACarII.Core.Exceptions
{
    public class CarRentingException : ApplicationException
    {
        public CarRentingException()
        {

        }

        public CarRentingException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
