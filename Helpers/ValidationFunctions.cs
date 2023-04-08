using IcSMP_ApiApp.Helpers.Models;
using System.Data;

namespace IcSMP_ApiApp.Helpers
{
    public class ValidationFunctions
    {
        public static void ExceptionWhenDataIsNotValid(DateTime? start, DateTime? end)
        {
            if(start.HasValue && end.HasValue && start > end) 
            {
                throw new ModelValidationsException(Helpers.ErrorMessagesEnum.StartEndDatesError);
            }

        }
    }
}
