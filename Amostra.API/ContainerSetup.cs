//using Microsoft.EntityFrameworkCore;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Security;
//using AutoMapper;
//using AutoMapper.Configuration;


//namespace Amostra.API
//{
//    public static class ContainerSetup
//    {
//        public static void Setup(IServiceCollection services, IConfigurationRoot configuration)
//        {
//            AddUow(services, configuration);
//            AddQueries(services);
//            ConfigureAutoMapper(services);
//        }


//        private static void ConfigureAutoMapper(IServiceCollection services)
//        {
//            var mapperConfig = AutoMapperConfigurator.Configure();
//            var mapper = mapperConfig.CreateMapper();
//            services.AddSingleton(x => mapper);
//            services.AddTransient<IAutoMapper, AutoMapperAdapter>();
//        }

//        private static void AddUow(IServiceCollection services, IConfigurationRoot configuration)
//        {
//            var connectionString = configuration["Data:main"];

//            services.AddEntityFrameworkSqlServer();

//            services.AddDbContext<MainDbContext>(options =>
//                options.UseSqlServer(connectionString));

//            services.AddScoped<IUnitOfWork>(ctx => new EFUnitOfWork(ctx.GetRequiredService<MainDbContext>()));

//            services.AddScoped<IActionTransactionHelper, ActionTransactionHelper>();
//            services.AddScoped<UnitOfWorkFilterAttribute>();
//        }

//        private static void AddQueries(IServiceCollection services)
//        {
//            var exampleProcessorType = typeof(UsersQueryProcessor);
//            var types = (from t in exampleProcessorType.GetTypeInfo().Assembly.GetTypes()
//                         where t.Namespace == exampleProcessorType.Namespace
//                             && t.GetTypeInfo().IsClass
//                             && t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null
//                         select t).ToArray();

//            foreach (var type in types)
//            {
//                var interfaceQ = type.GetTypeInfo().GetInterfaces().First();
//                services.AddScoped(interfaceQ, type);
//            }
//        }
//    }
//}
