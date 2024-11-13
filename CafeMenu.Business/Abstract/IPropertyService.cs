using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Abstract
{
    public interface IPropertyService
    {
        IDataResult<PropertyListDto> GetAll();
        IDataResult<PropertyUpdateDto> GetById(int propertyId);
        IResult Add(PropertyAddDto propertyAddDto);
        IResult Update(PropertyUpdateDto propertyUpdateDto);
        IResult Delete(PropertyDeleteDto propertyDeleteDto);
    }
}
