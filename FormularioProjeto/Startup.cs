using System;
using FormularioProjeto.Dados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FormularioProjeto.Models;
using FormularioProjeto.Banco;

namespace FormularioProjeto
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conexaoInvest = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<InvestContext>();

            var conexao = Configuration.GetConnectionString("IdentityDb");

            services.AddDbContext<IdentityDadosContext>(options =>
                options.UseSqlServer(conexao)
            )
                services.InjectorServices(Configuration);

            services.AddIdentity<UserApp, RolesApp>()
                .AddEntityFrameworkStores<IdentityDadosContext>()
                .AddRoles<RolesApp>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Conta/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Conta/AcessoNegado";
                options.SlidingExpiration = true;
            });

            services.AddRazorPages();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAuthorization(options =>
           {
               options.AddPolicy("Politica 01", policy => policy.RequireClaim("Politica", "01"));
               options.AddPolicy("Permissoes", policy => policy.RequireRole("ADMINISTRADOR","CLIENTE"));
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            serviceProvider.CriarRoleClaims()
                .Wait();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
