using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Dtos.ProductDtos.CategoryDtos;
using Dropshiping.BackEnd.Mappers.ProductMappers;
using Dropshiping.BackEnd.Services.ProductServices.Interface;

namespace Dropshiping.BackEnd.Services.ProductServices.Implementation
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
       
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
     
        }

        // Get all Categories
        public List<CategoryDto> GetAll()
        {
            var categories = _categoryRepository.GetAll();
            return categories.Select(x => x.ToDtoCat()).ToList();
        }

        // Get Category by Id
        public CategoryDto GetById(string id)
        {
            var category = _categoryRepository.GetById(id);

            if(category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} is not found");
            }
            return category.ToDtoCat();
        }

        // Nested
        public List<ProductDto> GetByIdNested(string id)
        {
            var category = _categoryRepository.GetByIdNest(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} is not found");
            }
            
            var  listOfProducts = category.Subcategories.SelectMany(x => x.Products).ToList();

            List<ProductDto> listOfProductMapped = new();

            foreach(var product in listOfProducts)
            {
                listOfProductMapped.Add(product.ToDto());
            }

            return listOfProductMapped;

        }

        // Add Category
        public void Add(CategoryDto categoryDto)
        {
            if (categoryDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if (categoryDto.Name.Length > 50)
            {
                throw new InvalidDataException("Name Length must not be more then 50 characters!");
            }
            if(categoryDto.Description == null)
            {
                throw new ArgumentNullException("Description must not be empty");
            }
            if (categoryDto.Description.Length > 250)
            {
                throw new InvalidDataException("Description Length must not be more then 250 characters!");
            }

            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };

            _categoryRepository.Add(category);
        }

        // Update Category
        public void Update(CategoryDto categoryDto)
        {
            var category = _categoryRepository.GetById(categoryDto.Id);

            category.Id = categoryDto.Id;
            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            if (categoryDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if (categoryDto.Name.Length > 50)
            {
                throw new InvalidDataException("Name Length must not be more then 50 characters!");
            }
            if (categoryDto.Description == null)
            {
                throw new ArgumentNullException("Description must not be empty");
            }
            if (categoryDto.Description.Length > 250)
            {
                throw new InvalidDataException("Description Length must not be more then 250 characters!");
            }

            _categoryRepository.Update(category);
        }

        // Delete Category by Id
        public void DeleteById(string id)
        {
            var category = GetById(id);

            if (category.Id == null)
            {
                throw new KeyNotFoundException($"Category with id {id} was not found.");
            }
            if (id == "")
            {
                throw new ArgumentException("You must enter id");
            }

            _categoryRepository.Delete(category.Id);
        }

        
    }
}
