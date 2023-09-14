using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Mappers.ProductMappers;
using Dropshiping.BackEnd.Services.ProductServices.Interface;

namespace Dropshiping.BackEnd.Services.ProductServices.Implementation
{
    public class SubcategoryService : ISubcategoryService
    {
        private IRepository<Subcategory> _subcategoryRepository;
        public SubcategoryService(IRepository<Subcategory> subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        // Get all Subcategories
        public List<SubcategoryDto> GetAll()
        {
            var subcategories = _subcategoryRepository.GetAll();
            return subcategories.Select(x => x.ToDtoSub()).ToList();
        }

        // Get Subcategory by Id
        public SubcategoryDto GetById(string id)
        {
            var subcategory = _subcategoryRepository.GetById(id);

            if(subcategory == null)
            {
                throw new KeyNotFoundException($"Subcategory with id {id} is not found");
            }

            return subcategory.ToDtoSub();
        }

        // Add Subcategory
        public void Add(SubcategoryDto subcategoryDto)
        {
            if (subcategoryDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if (subcategoryDto.Name.Length > 50)
            {
                throw new InvalidDataException("Name Length must not be more then 50 characters!");
            }
            if (subcategoryDto.Description == null)
            {
                throw new ArgumentNullException("Description must not be empty");
            }
            if (subcategoryDto.Description.Length > 250)
            {
                throw new InvalidDataException("Description Length must not be more then 250 characters!");
            }

            var subcategory = new Subcategory
            {
                Name = subcategoryDto.Name,
                Description = subcategoryDto.Description,
                CategoryId = subcategoryDto.CategoryId,
            };

            _subcategoryRepository.Add(subcategory);
        }

        // Update Subcategory
        public void Update(SubcategoryDto subcategoryDto)
        {
            var subcategory = _subcategoryRepository.GetById(subcategoryDto.Id);

            subcategory.Id = subcategoryDto.Id;
            subcategory.Name = subcategoryDto.Name;
            subcategory.Description = subcategoryDto.Description;
            subcategory.CategoryId = subcategoryDto.CategoryId;

            if (subcategoryDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if (subcategoryDto.Name.Length > 50)
            {
                throw new InvalidDataException("Name Length must not be more then 50 characters!");
            }
            if (subcategoryDto.Description == null)
            {
                throw new ArgumentNullException("Description must not be empty");
            }
            if (subcategoryDto.Description.Length > 250)
            {
                throw new InvalidDataException("Description Length must not be more then 250 characters!");
            }

            _subcategoryRepository.Update(subcategory);
        }

        //Delete Subcategory by Id
        public void DeleteById(string id)
        {
            var subcategory = _subcategoryRepository.GetById(id);

            if (subcategory.Id == null)
            {
                throw new KeyNotFoundException($"Subcategory with id {id} was not found.");
            }
            if (id == "")
            {
                throw new ArgumentException("You must enter id");
            }

            _subcategoryRepository.GetById(subcategory.Id);
        } 
    }
}
