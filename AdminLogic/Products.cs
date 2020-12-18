using System.Collections.Generic;
using AdminEntities;
using AdminFactory;
using AdminLogic.Entities;

namespace AdminLogic
{
    public class Products
    {
        private readonly IProduct _ProductsDal = ProductFactory.GetProduct();

        public List<ProductEntity> ReadAll()
        {
            List<ProductEntity> products = new List<ProductEntity>();

            foreach (ProductDTO product in _ProductsDal.ReadAllAsync().Result)
            {
                products.Add(new ProductEntity().ProductDTOToProduct(product));
            }
            return products;
        }

        public ProductEntity ReadOne(int id)
        {
            return new ProductEntity().ProductDTOToProduct(_ProductsDal.ReadOneAsync(id).Result);
        }

        public ProductEntity Update(ProductEntity product)
        {
            return new ProductEntity().ProductDTOToProduct(_ProductsDal.UpdateAsync(product.ProductToProductDTO()).Result);
        }

        public ProductEntity Create(ProductEntity product)
        {
            return new ProductEntity().ProductDTOToProduct(_ProductsDal.CreateAsync(product.ProductToProductDTO()).Result);
        }
    }
}