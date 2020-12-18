using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminEntities;

namespace AdminLogic.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        public ProductEntity ProductDTOToProduct(ProductDTO product)
        {
            return new ProductEntity()
            {
                Id = product.Id,
                Image = product.Image,
                Name = product.Name,
                Price = product.Price
            };
        }

        public ProductDTO ProductToProductDTO()
        {
            return new ProductDTO()
            {
                Id = this.Id,
                Image = this.Image,
                Name = this.Name,
                Price = this.Price
            };
        }
    }
}
