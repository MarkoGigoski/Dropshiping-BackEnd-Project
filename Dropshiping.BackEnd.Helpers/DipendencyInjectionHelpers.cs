using Dropshiping.BackEnd.DataAccess;
using Dropshiping.BackEnd.DataAccess.Implementation;
using Dropshiping.BackEnd.DataAccess.Interface;
using Dropshiping.BackEnd.Domain.ProductModels;
using Dropshiping.BackEnd.Domain.UserModels;
using Dropshiping.BackEnd.Services.ProductServices.Implementation;
using Dropshiping.BackEnd.Services.ProductServices.Interface;
using Dropshiping.BackEnd.Services.UserServices.Implementation;
using Dropshiping.BackEnd.Services.UserServices.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dropshiping.BackEnd.Helpers
{
    public static class DipendencyInjectionHelpers
    {
        // Inject Configuration string
        public static void InjectDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DropshipingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        //Repositories
        public static void InjectRepositories(IServiceCollection services)
        {
            // Product menagment Repositories
            services.AddTransient<IRepository<Product>, ProductRepository> ();
            services.AddTransient<IRepository<Category>, CategoryRepository> ();
            services.AddTransient<IRepository<Subcategory>, SubcategoryRepository>();
            //services.AddTransient<ICatalogService, CatalogService>();



            // User Repository
            services.AddTransient<IRepository<User>,UserRepository> ();
        }

        //Services
        public static void InjectService(IServiceCollection services)
        {
            // Product menagment Services
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISubcategoryService, SubcategoryService>();
            //services.AddTransient<ICatalogService, CatalogService> ();


            // User Services
            services.AddTransient<IUserService, UserService>();
        }

    }
}
