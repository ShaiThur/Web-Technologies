using EmployeeProductivity.Server.Middleware;

namespace EmployeeProductivity.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddServerServices();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();
            app.UseResponseCompression();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCustomAuthorization();
            //app.MapMyIdentityApi<ApplicationUser>();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.UseExceptionHandler(options => { });

            app.Run();
        }
    }
}
