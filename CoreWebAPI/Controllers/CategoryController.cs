using CoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")] // www.google.com/api/category/getcategories ..route yapısını nasıl istiyosak öyle yazabiliriz.
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /* http status codes
         * 1 information
         * 2 success
         * 3 redirect
         * 4 client error
         * 5 server error
         * */

        [HttpGet]
        public IActionResult Get() // ../api/category/get
        {
            var category = "içecekler";
            return Ok(category);  // farklı dönüş tipleri var. view yok. Ok() 200 başarılı işlem
        }

        [HttpPost]
        public IActionResult Add(CategoryDTO model) //dto'yu viewmodel olarak düşünebilirsin
        {
            // logic
            return Ok("eklendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // .../api/category/GetById/3
        {
            if (id == 0)
            {
                return ValidationProblem("Category 0 veya null olamaz"); //BadRequest de return edebilirsin.
            }

            // db'den veriyi çek client'a gönder

            return Ok(new CategoryDTO() { CategoryName = "içecekler", Description = "su kola fanta" });
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO dTO)
        {
            // logic
            return Ok("Düzenleme yapıldı."); // ok= servisten sonuç döndü demek.
        }

        [HttpDelete("{id}")] // web api'deki routing yapısından dolayı bunları belirtiyoruz.
        public IActionResult Delete(int id)
        {
            // logic
            return Ok("silindi");
        }


    }
}
