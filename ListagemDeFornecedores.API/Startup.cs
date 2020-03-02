using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListagemDeFornecedores.Repository;
using ListagemDeFornecedores.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ListagemDeFornecedores.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

             // Configurações para CORS.
            services.AddCors();



            // Realiza conexão com a base de dados.
            services.AddDbContext<FornecedoresContext>(x =>
                x.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")
                )
            );


                // servicos adicionais

            // Dados mockados para popular as tabelas.
            services.AddTransient<DadosTeste>();

            services.AddScoped<IEmpresaRepository,EmpresaRepository>();
        }

 

       // public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
       public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DadosTeste dados)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
