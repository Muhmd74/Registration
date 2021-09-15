using System.Collections.Generic;

namespace Registration.Core.Common.Response
{
   public class OutputResponseForValidationFilter
    {
       public bool Success { get; set; }
       public object Message { get; set; }
       public object Model { get; set; }
       public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
   }

   public class ErrorModel
   {
       public string Property { get; set; }
       public string Message { get; set; }
   }
}
