using AutoMapper;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Constants;
using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Core.Utilities.Results.Concrete;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Concrete.Managers
{
    public class PropertyManager : IPropertyService
    {
        private readonly IPropertyDal _propertyDal;
        private readonly IMapper _mapper;

        public PropertyManager(IPropertyDal propertyDal, IMapper mapper)
        {
            _propertyDal = propertyDal;
            _mapper = mapper;
        }

        public IResult Add(PropertyAddDto propertyAddDto)
        {
            var newProperty = new Property
            {
                Key = propertyAddDto.Key,
                Value = propertyAddDto.Value
            };

            var addedProperty = _propertyDal.Add(newProperty);
            if (addedProperty == null)
                return new ErrorResult(propertyAddDto.Key + Messages.ErrorWhileNamedPropertyAdded);

            return new SuccessResult(propertyAddDto.Key + Messages.NamedPropertyAdded);
        }

        public IResult Delete(PropertyDeleteDto propertyDeleteDto)
        {
            var property = _propertyDal.Get(x => x.PropertyId == propertyDeleteDto.PropertyId);

            var deletedCategory = _propertyDal.Delete(property);

            if (!deletedCategory)
                return new ErrorResult(property.Key + Messages.ErrorWhileNamedPropertyDeleted);

            return new SuccessResult(property.Key + Messages.NamedPropertyDeleted);
        }

        public IDataResult<PropertyListDto> GetAll()
        {
            var propertyList = _propertyDal.GetList();
            var mappedPropertyList = _mapper.Map<PropertyListDto>(propertyList);
            return new SuccessDataResult<PropertyListDto>(mappedPropertyList, Messages.PropertiesListed);
        }

        public IDataResult<PropertyUpdateDto> GetById(int propertyId)
        {
            var propertyList = _propertyDal.Get(x => x.PropertyId == propertyId);
            var mappedPropertyList = _mapper.Map<PropertyUpdateDto>(propertyList);
            return new SuccessDataResult<PropertyUpdateDto>(mappedPropertyList, Messages.PropertyListed);
        }

        public IResult Update(PropertyUpdateDto propertyUpdateDto)
        {
            var property = _propertyDal.Get(x => x.PropertyId == propertyUpdateDto.PropertyId);

            var updateCategory = new Property
            {
                Key = propertyUpdateDto.Key,
                Value = propertyUpdateDto.Value
            };

            var updatedProperty = _propertyDal.Update(updateCategory);
            if (updatedProperty == null)
                return new ErrorResult(property.Key + Messages.ErrorWhileNamedPropertyUpdated);

            return new SuccessResult(property.Key + Messages.NamedPropertyUpdated);
        }
    }
}
