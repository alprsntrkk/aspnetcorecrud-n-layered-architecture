using BilicraWork.Helper;
using BilicraWork.TransferModel;
using BLL.Abstract;
using Entity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilicraWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private IWebHostEnvironment _hostingEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public async Task<object> GetList()
        {
            var result = _productService.GetProducts();
            foreach(var res in result)
            {
                if(res.FilePath!=null)
                    res.FileToDownload = await ContentHelper.GetFormFile(res.FilePath);
            }
            return result;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add([FromForm]TmProductRequest productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Product product = new Product { Id = productRequest.Id, Code = productRequest.Code, Name = productRequest.Name, Price = productRequest.Price, UploadedImageFile = productRequest.UploadedImageFile };
            var result = _productService.Add(product);
            if(result)
                product.FilePath = await ContentHelper.SaveFormFile(product.UploadedImageFile, _hostingEnvironment.ContentRootPath);

            return Ok(result);
        }
        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(string Id)
        {
            //not deleting file just deleting record
            return Ok(_productService.Delete(Id));
        }
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> Update([FromForm] TmProductRequest productRequest,string Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Product product = new Product { Id = productRequest.Id, Code = productRequest.Code, Name = productRequest.Name, Price = productRequest.Price,UploadedImageFile=productRequest.UploadedImageFile };
            var result = _productService.Update(product, Id);
            if(result)
                product.FilePath = await ContentHelper.SaveFormFile(product.UploadedImageFile, _hostingEnvironment.ContentRootPath);
            return Ok(result);
        }
        [HttpGet]
        [Route("SearchByAnyColumn")]
        public async Task<ActionResult> GetList(string queryValue)
        {
            var result = _productService.SearchByAnyColumn(queryValue);
            foreach (var res in result)
            {
                if (res.FilePath != null)
                    res.FileToDownload = await ContentHelper.GetFormFile(res.FilePath);
            }
            return Ok(result);
        }


        [HttpGet]
        [Route("ExportToExcel")]
        public ActionResult ExportToCSV()
        {
            var productList = _productService.GetProducts();

            var builder = new StringBuilder();
            builder.AppendLine("Id,Code,Name,Price");
            foreach (var product in productList)
            {
                builder.AppendLine($"{product.Id},{product.Code},{product.Name},{product.Price}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "products.csv");
        }
        
    }
}
