using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<CategoryListDto> GetAll();
        IDataResult<CategoryDto> GetById(int categoryId);
        IResult Add(CategoryAddDto categoryAddDto);
        IResult Update(CategoryUpdateDto categoryUpdateDto);
        IResult Delete(CategoryDeleteDto categoryDeleteDto);
    }
}
