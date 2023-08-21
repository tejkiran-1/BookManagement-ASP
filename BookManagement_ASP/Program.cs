using Microsoft.Extensions.FileProviders;

namespace BookManagement_ASP
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "pages/components")),
                RequestPath = "/pages/components",
                ServeUnknownFileTypes = true
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "pages/style")),
                RequestPath = "/pages/style",
                ServeUnknownFileTypes = true
            });



            /*
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new CompositeFileProvider(
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "pages/components")),
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "pages/style"))
                ),
                RequestPath = "/pages",
                ServeUnknownFileTypes = true
            });
            */

            app.Run();

        }
    }
}
