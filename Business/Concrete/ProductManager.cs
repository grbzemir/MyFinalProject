using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Core.Utilities.Result;
using System.Runtime.InteropServices;
using Business.Constants;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)

        {
            _productDal = productDal;
        }

        // AOP BİR METODUN ÖNÜNDE ARKASINDA ÇALIŞAN YAPILARDIR
        // ÖRNEK OLARAK BİR METODUN BAŞINDA LOG YAZDIRMAK İSTİYORUZ

        public IResult Add(Product product)
        {
            // result döndürüyoruz çünkü iş kodları varsa eger buraya yazılır
            // İş kodları varsa eger buraya yazılır
            
            if(product.ProductName.Length<2)

            {

                return new ErrorResult(Messages.ProductNameInvalid);

            }

             _productDal.Add(product);

             return new SuccessResult(Messages.ProductAdded); // void yerine result döndürüyoruz ! 


        
        }

        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 22)

            {
                // Bakıma alındı mesajı döndürüyoruz
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }

            //iş kodları varsa eger yazılır
            //bir iş sınıfı baska bir sınıfı newlemez o yüzden injection yapılır constructor ile

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)

        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));


        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult <Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)

        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }



        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}

