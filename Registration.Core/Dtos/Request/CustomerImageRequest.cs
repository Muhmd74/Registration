using System;
 using Microsoft.AspNetCore.Http;
 
namespace Registration.Core.Dtos.Request
{
    public class CustomerImageRequest
    {
        public Guid Id { get; set; } 
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
