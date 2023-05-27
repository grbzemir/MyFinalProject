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
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Business.CCS;
using Core.Aspects.Autofac.Validation;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal , ICategoryService  categoryService)

        {
            _productDal = productDal;
            _categoryService = categoryService;


        }

        // AOP BİR METODUN ÖNÜNDE ARKASINDA ÇALIŞAN YAPILARDIR
        // ÖRNEK OLARAK BİR METODUN BAŞINDA LOG YAZDIRMAK İSTİYORUZ
        // Aynı isimde ürün eklenemez
        // jason aslında bir formattır formatlı bir metindir aslında! taraflar arasındaki veri arişverişini sağlar

        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

           IResult result = BusinessRules.Run(CheckIfProductNameExsist(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExsist());
           
            
            if(result != null)
            {
                return result;
            }
            
            _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
            
        }

        // result döndürüyoruz çünkü iş kodları varsa eger buraya yazılır
        // İş kodları varsa eger buraya yazılır
        // validation ekleme yapıcaksak eger buraya yazılır
        // Loglama yapılan işlemlerin çalışmaların bir yerde kaydını tutmaktı



        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 22)

            {
                // Bakıma alındı mesajı döndürüyoruz
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }

            //iş kodları varsa eger yazılır
            //bir iş sınıfı baska bir sınıfı newlemez o yüzden injection yapılır constructor ile

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)

        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));


        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)

        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }



        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId);

            if (result.Count > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }
    

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)

        {
            // Count ile sayıyoruz

            var result = _productDal.GetAll(p => p.CategoryId == categoryId);

            if (result.Count > 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();

        }

        private IResult CheckIfProductNameExsist(string productName)

        {
            // Count ile sayıyoruz

            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();

        }

        private IResult CheckIfCategoryLimitExsist()

        {
            // Count ile sayıyoruz

            var result = _categoryService.GetAll();

            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();

        }




    }
    
}

