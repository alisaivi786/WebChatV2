using Microsoft.AspNetCore.Builder;
using StackExchange.Redis;

namespace GroupChatApp
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
            //services.AddDbContext<ChatDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddRazorPages();

            // Add SignalR and Configure Redis
            string redisConnectionString = "localhost:6379,password=,ssl=False,allowAdmin=True";
            services.AddSignalR().AddStackExchangeRedis(redisConnectionString);
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...
            app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHub<ChatHub>("/chatHub");
            //});
        }
    }
}
