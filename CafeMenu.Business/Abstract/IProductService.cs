using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace CafeMenu.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<ProductListDto> GetAll();
        IDataResult<ProductUpdateDto> GetById(int productId);
        IResult Add(ProductAddDto productAddDto, IFormFile file);
        IResult Update(ProductUpdateDto productUpdateDto, IFormFile file);
        IResult Delete(ProductDeleteDto productDeleteDto);
    }
}
