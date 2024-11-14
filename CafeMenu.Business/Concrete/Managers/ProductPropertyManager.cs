using AutoMapper;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Constants;
using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Core.Utilities.Results.Concrete;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;
using System.Linq.Expressions;

namespace CafeMenu.Business.Concrete.Managers
{
    public class ProductPropertyManager : IProductPropertyService
    {
        private readonly IProductPropertyDal _productPropertyDal;
        private readonly IMapper _mapper;

        public ProductPropertyManager(IProductPropertyDal productPropertyDal, IMapper mapper)
        {
            _productPropertyDal = productPropertyDal;
            _mapper = mapper;
        }

        public IResult Add(ProductPropertyAddDto productPropertyAddDto)
        {
            var newProductProperty = new ProductProperty
            {
                ProductId = productPropertyAddDto.ProductId,
                PropertyId = productPropertyAddDto.PropertyId
            };

            var addedProductProperty = _productPropertyDal.Add(newProductProperty);
            if (addedProductProperty == null)
                return new ErrorResult(addedProductProperty.Product.ProductName + Messages.ErrorWhileNamedPropertyAdded);

            return new SuccessResult(addedProductProperty.Product.ProductName + Messages.NamedPropertyAdded);
        }

        public IResult Delete(ProductPropertyDeleteDto productPropertyDeleteDto)
        {
            var productProperty = _productPropertyDal.Get(filter: x => x.ProductPropertyId == productPropertyDeleteDto.ProductPropertyId,
                includeProperties: new Expression<Func<ProductProperty, object>>[]
                {
                    x => x.Property,
                    y => y.Product
                }
            );

            var deletedProductProperty = _productPropertyDal.Delete(productProperty);

            if (!deletedProductProperty)
                return new ErrorResult(productProperty.Product.ProductName + Messages.ErrorWhileNamedProductPropertyDeleted);

            return new SuccessResult(productProperty.Product.ProductName + Messages.NamedProductPropertyDeleted);
        }

        public IDataResult<ProductPropertyListDto> GetAll()
        {
            var productPropertyList = _productPropertyDal.GetList(
                includeProperties: new Expression<Func<ProductProperty, object>>[]
                {
                    x => x.Property,
                    y => y.Product
                }
            );
            var mappedProductPropertyList = _mapper.Map<ProductPropertyListDto>(productPropertyList);
            return new SuccessDataResult<ProductPropertyListDto>(mappedProductPropertyList, Messages.ProductPropertiesListed);
        }

        public IDataResult<ProductPropertyUpdateDto> GetById(int productPropertyId)
        {
            var productProperty = _productPropertyDal.Get(filter: x => x.ProductPropertyId == productPropertyId,
                includeProperties: new Expression<Func<ProductProperty, object>>[]
                {
                    x => x.Property,
                    y => y.Product
                }
            );
            var mappedProductProperty = _mapper.Map<ProductPropertyUpdateDto>(productProperty);
            return new SuccessDataResult<ProductPropertyUpdateDto>(mappedProductProperty, Messages.ProductPropertyListed);
        }

        public IResult Update(ProductPropertyUpdateDto productPropertyUpdateDto)
        {
            var product = _productPropertyDal.Get(x => x.ProductPropertyId == productPropertyUpdateDto.ProductPropertyId);

            var updateProductProperty = new ProductProperty
            {
                ProductId = product.ProductId,
                PropertyId = product.PropertyId
            };

            var updatedProductProperty = _productPropertyDal.Update(updateProductProperty);
            if (updatedProductProperty == null)
                return new ErrorResult(product.Product.ProductName + Messages.ErrorWhileNamedProductPropertyUpdated);

            return new SuccessResult(product.Product.ProductName + Messages.NamedProductPropertyUpdated);
        }
    }
}
