using Demo.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DemoApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            // accepts any access token issued by identity server
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = DemoConst.IdentityServer_Uri;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            // adds an authorization policy to make sure the token is for scope 'DemoApi'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("NeedScope1", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", DemoConst.DemoApi_Scope1);
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var htmlString = new HtmlString(@"<b>Hello World</b>");
                    await context.Response.WriteAsync(htmlString.ToString());
                    await context.Response.WriteAsync(@"<ul>
    <li>
        <a href='/Api/Foo/GetInfo'>GetInfo</a>
    </li> 
    <li>
        <a href='/Api/Foo/GetUser'>GetUser</a>
    </li>
<ul>");
                });
                endpoints.MapControllers().RequireAuthorization("NeedScope1");
            });
        }
    }
}
