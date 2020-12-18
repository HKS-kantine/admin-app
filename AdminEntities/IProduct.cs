using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminEntities
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
    }

    public interface IProduct
    {
        Task<List<ProductDTO>> ReadAllAsync();
        Task<ProductDTO> ReadOneAsync(int id);
        Task<ProductDTO> UpdateAsync(ProductDTO product);
        Task<ProductDTO> CreateAsync(ProductDTO product);
    }
}