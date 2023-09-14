using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Dtos.ProductDtos;
using Dropshiping.BackEnd.Mappers.ProductMappers;
using Dropshiping.BackEnd.Services.ProductServices.Interface;

namespace Dropshiping.BackEnd.Services.ProductServices.Implementation
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        //Get all products
        public List<ProductDto> GetAll()
        {
            var products = _productRepository.GetAll();
            return products.Select(x => x.ToDto()).ToList();
        }

        //Get product by ID
        public ProductDto GetById(string id)
        {
            var product = _productRepository.GetById(id);

            if(product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} is not found");
            }
            return product.ToDto();
        }

        // Add new product
        public void Add(ProductDto productDto)
        {
            if(productDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if(productDto.Name.Length > 50)
            {
                throw new InvalidDataException("Name Length must not be more then 50 characters!");
            }
            if(productDto.Price == null)
            {
                throw new ArgumentNullException("Price must not be empty");
            }
            if (productDto.Description.Length > 250)
            {
                throw new InvalidDataException("Description Length must not be more then 250 characters!");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                Stock = productDto.Stock,
            };

            _productRepository.Add(product);
        }

        // Update Product
        public void Update(ProductDto productDto)
        {
            var product = _productRepository.GetById(productDto.Id);

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Description = productDto.Description;
            product.Stock = productDto.Stock;

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {productDto.Id} does not exist!");
            }
            if (productDto.Name == null)
            {
                throw new ArgumentNullException("Name must not be empty");
            }
            if (productDto.Name.Length > 50)
            {
                throw new ArgumentException("Name Length must not be more then 50 characters!");
            }
            if (productDto.Price == null)
            {
                throw new ArgumentNullException("Price must not be empty");
            }
            if (productDto.Description.Length > 250)
            {
                throw new ArgumentException("Description Length must not be more then 50 characters!");
            }

            _productRepository.Update(product);
        }

        // Delete Product
        public void DeleteById(string id)
        {
            var product = _productRepository.GetById(id);

            if(product.Id == null)
            {
                throw new KeyNotFoundException($"Product with id {id} was not found.");
            }
            if (id == "")
            {
                throw new ArgumentException("You must enter id");
            }
            _productRepository.Delete(product.Id);
        } 
    }
}
