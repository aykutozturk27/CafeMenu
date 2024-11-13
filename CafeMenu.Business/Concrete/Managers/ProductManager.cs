using AutoMapper;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Constants;
using CafeMenu.Core.Utilities.Helpers;
using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Core.Utilities.Results.Concrete;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace CafeMenu.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public IResult Add(ProductAddDto productAddDto, IFormFile file)
        {
            var product = _mapper.Map<Product>(productAddDto);

            product.ImagePath = FileHelper.Add(file);

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CreatorUserId = product.CreatorUserId,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            var addedProduct = _productDal.Add(newProduct);
            if (addedProduct == null)
                return new ErrorResult(product.ProductName + Messages.ErrorWhileNamedProductAdded);

            return new SuccessResult(product.ProductName + Messages.NamedProductAdded);
        }

        public IResult Delete(ProductDeleteDto productDeleteDto)
        {
            var product = _productDal.Get(x => x.ProductId == productDeleteDto.ProductId);
            productDeleteDto.IsDeleted = true;
            var deletedProduct = _productDal.Update(product);

            if (deletedProduct == null)
                return new ErrorResult(product.ProductName + Messages.ErrorWhileNamedProductDeleted);

            return new SuccessResult(product.ProductName + Messages.NamedProductDeleted);
        }

        public IDataResult<ProductListDto> GetAll()
        {
            var productList = _productDal.GetList();
            var mappedProductList = _mapper.Map<ProductListDto>(productList);
            return new SuccessDataResult<ProductListDto>(mappedProductList);
        }

        public IResult Update(ProductUpdateDto productUpdateDto, IFormFile file)
        {
            var product = _mapper.Map<Product>(productUpdateDto);

            product.ImagePath = FileHelper.Update(product.ImagePath, file);

            var updateProduct = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CreatorUserId = product.CreatorUserId
            };

            var updatedProduct = _productDal.Update(updateProduct);
            if (updatedProduct == null)
                return new ErrorResult(product.ProductName + Messages.ErrorWhileNamedProductUpdated);

            return new SuccessResult(product.ProductName + Messages.NamedProductUpdated);
        }
    }
}
