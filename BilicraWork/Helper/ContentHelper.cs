using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BilicraWork.Helper
{
    public static class ContentHelper
    {
        public async static Task<string> SaveFormFile(IFormFile file,string root)
        {
            string uploads = Path.Combine(root, "uploads");
            if (file != null) { 
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                return filePath;
                }
            }
            return null;
        }
        public async static Task<string> GetFormFile( string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }
    }
}
