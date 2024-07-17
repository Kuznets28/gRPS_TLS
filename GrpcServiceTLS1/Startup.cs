using GrpcServiceTLS1.Services;

namespace GrpcServiceTLS1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                options.MaxReceiveMessageSize = 1024 * 1024 * 1050; // 1 ГБ
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DataTransferService>();
            });
        }
    }
}
