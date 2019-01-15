using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VM.Domain.Interfaces.Repository;
using VM.Infra.Data.Context;
using VM.Infra.Data.Repository;

namespace VM.Presentation.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = 
                Configuration.GetConnectionString("ConnectionStrings:ClienteConnection");

            services.AddDbContext<ClienteContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Cliente}/{action=Index}/{id?}");
            });
        }
    }
}
