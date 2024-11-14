using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Abstract
{
    public interface IProductPropertyService
    {
        IDataResult<ProductPropertyListDto> GetAll();
        IDataResult<ProductPropertyUpdateDto> GetById(int productPropertyId);
        IResult Add(ProductPropertyAddDto productPropertyAddDto);
        IResult Update(ProductPropertyUpdateDto productPropertyUpdateDto);
        IResult Delete(ProductPropertyDeleteDto productPropertyDeleteDto);
    }
}
