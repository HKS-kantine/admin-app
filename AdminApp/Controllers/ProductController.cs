using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLogic;
using AdminLogic.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Products cont = new Products();

        // GET: api/<ProductController>
        [HttpGet]
        public List<ProductEntity> Get()
        {
            return cont.ReadAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductEntity Get(int id)
        {
            return cont.ReadOne(id);
        }

        [HttpPost]
        public async void Post([FromBody] ProductEntity product)
        {
            if (product.Id == 0)
            {
                cont.Create(product);
            }
            else
            {
                cont.Update(product);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] ProductEntity product)
        {
            product.Id = id;
            cont.Update(product);
        }
    }
}
