using AdminEntities;
using AdminProduct;

namespace AdminFactory
{
    public class ProductFactory
    {
        public static IProduct GetProduct()
        {
            return new ProductController();
        }
    }
}