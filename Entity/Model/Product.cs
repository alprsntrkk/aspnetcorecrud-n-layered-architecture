using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Product
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Code { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [NotMapped]
        public IFormFile UploadedImageFile { get; set; }
        [NotMapped]
        public string FileToDownload { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? FilePath { get; set; }
    }
}
