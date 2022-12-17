using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Exceptions
{
    public class Guard : IGuard
    {
        /// <summary>
        /// guard against null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="errorMessage"></param>
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ? 
                    new CarRentingException() :
                    new CarRentingException(errorMessage);

                throw exception;
            }
        }
    }
}
