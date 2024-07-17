using Grpc.Core;


using GrpcServiceTLS1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.Limits.MaxRequestBodySize = 1024 * 1024 * 1050; // 1 ца
                    serverOptions.ListenLocalhost(5001, listenOptions =>
                    {
                        listenOptions.UseHttps("C:/path/certificate.pfx", "Hello");
                    });
                });
            });
}
