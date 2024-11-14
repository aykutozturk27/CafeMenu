using AutoMapper;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Constants;
using CafeMenu.Core.Utilities.Helpers;
using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Core.Utilities.Results.Concrete;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.DataAccess.Concrete.EntityFramework;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace CafeMenu.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductManager(IProductDal productDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _productDal = productDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(ProductAddDto productAddDto, IFormFile file)
        {
            int creatorUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value); // Kullanıcı ID'si

            var product = _mapper.Map<Product>(productAddDto);

            product.ImagePath = FileHelper.Add(file);

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CreatorUserId = creatorUserId,
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
            product.IsDeleted = true;
            var deletedProduct = _productDal.Update(product);

            if (deletedProduct == null)
                return new ErrorResult(product.ProductName + Messages.ErrorWhileNamedProductDeleted);

            return new SuccessResult(product.ProductName + Messages.NamedProductDeleted);
        }

        public IDataResult<ProductListDto> GetAll()
        {
            var productList = _productDal.GetList(x => !x.IsDeleted, x => x.User, y => y.Category);
            var mappedProductList = _mapper.Map<ProductListDto>(productList);
            return new SuccessDataResult<ProductListDto>(mappedProductList, Messages.ProductsListed);
        }

        public IDataResult<ProductUpdateDto> GetById(int productId)
        {
            var product = _productDal.Get(x => x.ProductId == productId);
            var mappedProduct = _mapper.Map<ProductUpdateDto>(product);
            return new SuccessDataResult<ProductUpdateDto>(mappedProduct, Messages.ProductListed);
        }

        public IResult Update(ProductUpdateDto productUpdateDto, IFormFile file)
        {
            int creatorUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value);

            var product = _productDal.Get(x => x.ProductId == productUpdateDto.ProductId);

            product.ImagePath = FileHelper.Update(product.ImagePath, file);

            var updateProduct = new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CreatorUserId = creatorUserId
            };

            var updatedProduct = _productDal.Update(updateProduct);
            if (updatedProduct == null)
                return new ErrorResult(product.ProductName + Messages.ErrorWhileNamedProductUpdated);

            return new SuccessResult(product.ProductName + Messages.NamedProductUpdated);
        }
    }
}
