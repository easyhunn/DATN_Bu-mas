using CoreBL.Base;
using CoreBL.Interface;
using CoreDL.Interface;
using CoreDL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.VMHUNG.Core.Interface;
using MISA.VMHUNG.Core.Service;
using MISA.VMHUNG.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CoreBL;

namespace bumas_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public const string CookieAuthScheme = "CookieAuthScheme";
        public const string JWTAuthScheme = "JWTAuthScheme";
        public static readonly SymmetricSecurityKey SecurityKey =
    new SymmetricSecurityKey(
        Encoding.Default.GetBytes("this would be a real secret vmhung 123456"));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            }
            );
            services.AddAuthentication(CookieAuthScheme)
            // Now configure specific Cookie and JWT auth options
            .AddCookie(CookieAuthScheme, options =>
            {
                // Set the cookie name (optional)
                options.Cookie.Name = "AuthCookie";
                // Set the samesite cookie parameter as none, 
                // otherwise it won’t work with clients on uses a different domain wont work!
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                // Simply return 401 responses when authentication fails 
                // as opposed to the default of redirecting to the login page
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
                // In order to decide the between both schemas
                // inspect whether there is a JWT token either in the header or query string
                options.ForwardDefaultSelector = ctx =>
                {
                    if (ctx.Request.Query.ContainsKey("access_token")) return JWTAuthScheme;
                    if (ctx.Request.Headers.ContainsKey("Authorization")) return JWTAuthScheme;
                    return CookieAuthScheme;
                };
            })
            .AddJwtBearer(JWTAuthScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    LifetimeValidator = (before, expires, token, param) =>
                    {
                        return expires > DateTime.UtcNow;
                    },
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = SecurityKey,
                };
            });

            
            addServiceScoped(ref services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "bumas_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "bumas_api v1"));
            }
            app.UseRouting();
            app.UseCors(x => x.AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        #region custom function
        public void addServiceScoped(ref IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

            services.AddScoped(typeof(ITestBL), typeof(TestBL));
            services.AddScoped(typeof(ITestDL), typeof(TestDL));
            services.AddScoped(typeof(IAccountBL), typeof(AccountBL));
            services.AddScoped(typeof(IAccountDL), typeof(AccountDL));
            services.AddScoped(typeof(IReportSettingBL), typeof(ReportSettingBL));
            services.AddScoped(typeof(IReportSettingDL), typeof(ReportSettingDL));
            services.AddScoped(typeof(IOrganizationBL), typeof(OrganizationBL));
            services.AddScoped(typeof(IOrganizationDL), typeof(OrganizationDL));
            services.AddScoped(typeof(IEstimateBL), typeof(EstimateBL));
            services.AddScoped(typeof(IEstimateDL), typeof(EstimateDL));
            services.AddScoped(typeof(ITemplateWorkbookBL), typeof(TemplateWorkbookBL));
            services.AddScoped(typeof(ITemplateWorkbookDL), typeof(TemplateWorkbookDL));
        }
        #endregion
    }

}
