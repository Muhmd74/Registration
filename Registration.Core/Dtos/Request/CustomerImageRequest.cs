using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Registration.Core.Dtos.Request
{
    public class CustomerImageRequest
    {
        public Guid Id { get; set; } 
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
