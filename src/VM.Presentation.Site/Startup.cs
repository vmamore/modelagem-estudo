using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VM.Application;
using VM.Application.AutoMapper;
using VM.Application.Interfaces;
using VM.Domain.Interfaces.Repository;
using VM.Infra.Data.Context;
using VM.Infra.Data.Interfaces;
using VM.Infra.Data.Repository;
using VM.Infra.Data.UoW;

namespace VM.Presentation.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClienteProfile());
                mc.AddProfile(new EnderecoProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            
            var connectionString =
                Configuration.GetConnectionString("ClienteConnection");
            
            services.AddSingleton(mapper);

            services.AddDbContext<ClienteContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ApplicationService>();
            
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
