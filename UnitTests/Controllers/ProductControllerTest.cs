using System.Collections.Generic;
using AdminApp.Controllers;
using AdminLogic.Entities;
using AdminProduct;
using NUnit.Framework;

namespace UnitTests.Controllers
{
    public class ProductControllerTest
    {
        private readonly AdminApp.Controllers.ProductController _product = new AdminApp.Controllers.ProductController();
        private List<ProductEntity> _productList;
        private ProductEntity _newProduct;
        private ProductEntity _lastAddedProduct;

        [SetUp]
        public void Setup()
        {
            _newProduct = new ProductEntity()
            {
                Name = "Test-edit",
                Price = 1,
                Image = "MAARTEN.jpg"
            };

            _productList = _product.Get();
            _lastAddedProduct = _productList[_productList.Count - 1];
            _lastAddedProduct.Name = "Test-edit";
            _lastAddedProduct.Price = 2;
            _lastAddedProduct.Image = "TEST.jpg";
        }

        [Test]
        public void AA_PR_01__receive_list_of_products()
        {
            _productList = _product.Get();
            if (_productList.Count >= 1)
            {
                Assert.Pass();
            }

            Assert.Fail("List is empty");
        }

        [Test]
        public void AA_PR_02__create_new_product_without_image()
        {
            _newProduct.Image = null;
            _product.Post(_newProduct);
            _productList = _product.Get();
            isSameProduct(_productList[_productList.Count - 1], _newProduct);
        }

        [Test]
        public void AA_PR_03__create_new_product_without_name()
        {
            _newProduct.Name = null;
            _product.Post(_newProduct);
            _productList = _product.Get();
            isSameProduct(_productList[_productList.Count - 1], _newProduct);
        }

        [Test]
        public void AA_PR_04__create_new_product_without_price()
        {
            _newProduct.Price = 0;
            _product.Post(_newProduct);
            _productList = _product.Get();
            isSameProduct(_productList[_productList.Count - 1], _newProduct);
        }

        [Test]
        public void AA_PR_05__create_new_product()
        {
            _product.Post(_newProduct);
            _productList = _product.Get();
            isSameProduct(_productList[_productList.Count - 1], _newProduct);
        }

        [Test]
        public void AA_PR_06_edit_product_without_image()
        {
            _lastAddedProduct.Image = null;
            _product.Post(_lastAddedProduct);
            isSameProduct(_productList[_productList.Count - 1], _lastAddedProduct);
        }

        [Test]
        public void AA_PR_07_edit_product_without_name()
        {
            _lastAddedProduct.Name = null;
            _product.Post(_lastAddedProduct);
            isSameProduct(_productList[_productList.Count - 1], _lastAddedProduct);
        }

        [Test]
        public void AA_PR_08_edit_product_without_price()
        {
            _lastAddedProduct.Price = 0;
            _product.Post(_lastAddedProduct);
            isSameProduct(_productList[_productList.Count - 1], _lastAddedProduct);
        }

        [Test]
        public void AA_PR_09_edit_product()
        {
            _product.Post(_lastAddedProduct);
            isSameProduct(_productList[_productList.Count - 1], _lastAddedProduct);
        }

        private void isSameProduct(ProductEntity returnProduct, ProductEntity givenProduct)
        {
            if (returnProduct.Name != givenProduct.Name)
            {
                Assert.Fail("not same Name");
            }
            if (returnProduct.Price != givenProduct.Price)
            {
                Assert.Fail("not same Price");
            }
            if (returnProduct.Image != givenProduct.Image)
            {
                Assert.Fail("not same Image");
            }
            Assert.Pass();
        }
    }
}