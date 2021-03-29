using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BilicraWork.TransferModel
{
    public class TmProductRequest
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public IFormFile UploadedImageFile { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
    }
}
