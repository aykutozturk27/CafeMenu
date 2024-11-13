using AutoMapper;
using CafeMenu.Business.Abstract;
using CafeMenu.Business.Constants;
using CafeMenu.Core.Utilities.Results.Abstract;
using CafeMenu.Core.Utilities.Results.Concrete;
using CafeMenu.DataAccess.Abstract;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Http;

namespace CafeMenu.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(CategoryAddDto categoryAddDto)
        {
            int creatorUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value); // Kullanıcı ID'si

            var category = _mapper.Map<Category>(categoryAddDto);

            var newCategory = new Category
            {
                CategoryName = category.CategoryName,
                ParentCategoryId = category.ParentCategoryId != null ? category.ParentCategoryId : 0,
                CreatorUserId = creatorUserId,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };

            var addedCategory = _categoryDal.Add(newCategory);
            if (addedCategory == null)
                return new ErrorResult(category.CategoryName + Messages.ErrorWhileNamedCategoryAdded);

            return new SuccessResult(category.CategoryName + Messages.NamedCategoryAdded);
        }

        public IResult Delete(CategoryDeleteDto categoryDeleteDto)
        {
            var category = _categoryDal.Get(x => x.CategoryId == categoryDeleteDto.CategoryId);
            categoryDeleteDto.IsDeleted = true;
            var deletedCategory = _categoryDal.Update(category);

            if (deletedCategory == null)
                return new ErrorResult(category.CategoryName + Messages.ErrorWhileNamedCategoryDeleted);

            return new SuccessResult(category.CategoryName + Messages.NamedCategoryDeleted);
        }

        public IDataResult<CategoryListDto> GetAll()
        {
            var categoryList = _categoryDal.GetList(includeProperties: x => x.User);
            var mappedCategoryList = _mapper.Map<CategoryListDto>(categoryList);
            return new SuccessDataResult<CategoryListDto>(mappedCategoryList, Messages.CategoriesListed);
        }

        public IDataResult<CategoryDto> GetById(int categoryId)
        {
            var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            var mappedCategory = _mapper.Map<CategoryDto>(category);
            return new SuccessDataResult<CategoryDto>(mappedCategory, Messages.CategoryListed);
        }

        public IResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);

            var updateCategory = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                ParentCategoryId = category.ParentCategoryId,
                CreatorUserId = category.CreatorUserId
            };

            var updatedCategory = _categoryDal.Update(updateCategory);
            if (updatedCategory == null)
                return new ErrorResult(category.CategoryName + Messages.ErrorWhileNamedCategoryUpdated);

            return new SuccessResult(category.CategoryName + Messages.NamedCategoryUpdated);
        }
    }
}
