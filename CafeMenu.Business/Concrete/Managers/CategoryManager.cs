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
        private readonly IUserDal _userDal;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserDal userDal)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userDal = userDal;
        }

        public IResult Add(CategoryAddDto categoryAddDto)
        {
            //int creatorUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value); // Kullanıcı ID'si
            int creatorUserId = _userDal.Get(x => x.Username == _httpContextAccessor.HttpContext.User.Identity.Name).UserId;

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
            category.IsDeleted = true;

            var deletedCategory = _categoryDal.Update(category);

            if (deletedCategory == null)
                return new ErrorResult(category.CategoryName + Messages.ErrorWhileNamedCategoryDeleted);

            return new SuccessResult(category.CategoryName + Messages.NamedCategoryDeleted);
        }

        public IDataResult<CategoryListDto> GetAll()
        {
            var categoryList = _categoryDal.GetList(x => !x.IsDeleted, x => x.User);
            var mappedCategoryList = _mapper.Map<CategoryListDto>(categoryList);
            return new SuccessDataResult<CategoryListDto>(mappedCategoryList, Messages.CategoriesListed);
        }

        public IDataResult<CategoryListDto> GetAllWithParentCategory()
        {
            var categoryList = _categoryDal.GetList(x => x.ParentCategoryId == 0, x => x.User);
            var mappedCategoryList = _mapper.Map<CategoryListDto>(categoryList);
            return new SuccessDataResult<CategoryListDto>(mappedCategoryList, Messages.CategoriesListed);
        }

        public IDataResult<CategoryUpdateDto> GetById(int categoryId)
        {
            var category = _categoryDal.Get(x => x.CategoryId == categoryId);
            var mappedCategory = _mapper.Map<CategoryUpdateDto>(category);
            return new SuccessDataResult<CategoryUpdateDto>(mappedCategory, Messages.CategoryListed);
        }

        public IResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            //int creatorUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value); // Kullanıcı ID'si
            int creatorUserId = _userDal.Get(x => x.Username == _httpContextAccessor.HttpContext.User.Identity.Name).UserId;

            var category = _categoryDal.Get(x => x.CategoryId == categoryUpdateDto.CategoryId);

            var updateCategory = new Category
            {
                CategoryId = categoryUpdateDto.CategoryId,
                CategoryName = categoryUpdateDto.CategoryName,
                ParentCategoryId = categoryUpdateDto.ParentCategoryId,
                CreatorUserId = creatorUserId,
                CreatedDate = category.CreatedDate,
                IsDeleted = category.IsDeleted
            };

            var updatedCategory = _categoryDal.Update(updateCategory);
            if (updatedCategory == null)
                return new ErrorResult(category.CategoryName + Messages.ErrorWhileNamedCategoryUpdated);

            return new SuccessResult(category.CategoryName + Messages.NamedCategoryUpdated);
        }
    }
}
