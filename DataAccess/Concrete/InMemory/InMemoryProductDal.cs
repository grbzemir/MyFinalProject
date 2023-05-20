using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal

    {
        // classin içinde ama metotun dısında tanımlanan degıskenlere global degısken denir.

        List<Product> _products;

        public InMemoryProductDal()

        {
            _products = new List<Product>

            {

                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=2,ProductId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=3,ProductId=3,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryId=4,ProductId=4,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=5,ProductId=5,ProductName="Fare",UnitPrice=85,UnitsInStock=1}



            };

        }
        public void Add(Product product)

        {

            _products.Add(product);
        }

        public void Delete(Product product)

        {
            // LİNQ - Language Integrated Query LINQ İLE SQL BAZDI VERİLERİ LİSTELEYEBİLİRİZ


            // SingleOrDefault Tek bir ürün bulmaya yarar.
            // tek tek dolasırken vercegimiz sanal isim p olsun
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()

        {
            return _products;

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products.ToList();
        }

        public List<Product> GetAllByCategory(int categoryId)

        {

            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)

        {
            // Gönderdigim ürün ıdsine sahip olan listedeki ürünü bul demek.

            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;



        }

        List<ProductDetailDto> IProductDal.GetProductDetails()
        {
            throw new NotImplementedException();
        }

        
    }
}
