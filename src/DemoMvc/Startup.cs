using System.IdentityModel.Tokens.Jwt;
using Demo.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoMvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = DemoConst.IdentityServerUri;
                    options.ClientId = DemoConst.DemoMvc;
                    options.ClientSecret = DemoConst.Secret;
                    options.ResponseType = "code";
                    options.Scope.Add(DemoConst.ApiScope1);
                    options.SaveTokens = true;
                });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("NeedLogin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
//                endpoints.MapGet("/", async context =>
//                {
//                    var htmlString = new HtmlString(@"<b>Hello World</b>");
//                    await context.Response.WriteAsync(htmlString.ToString());
//                    await context.Response.WriteAsync(@"<ul>
//    <li>
//        <a href='/Home/Index'>Home/Index</a>
//    </li> 
//    <li>
//        <a href='/Home/CallApi'>Home/CallApi</a>
//    </li>
//<ul>");
//                });

                endpoints.MapDefaultControllerRoute().RequireAuthorization("NeedLogin");
            });
        }
    }
}
