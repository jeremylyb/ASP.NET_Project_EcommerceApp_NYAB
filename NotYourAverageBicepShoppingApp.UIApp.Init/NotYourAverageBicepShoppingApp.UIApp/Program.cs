using NotYourAverageBicepShoppingApp.UIApp.APIClient;

namespace NotYourAverageBicepShoppingApp.UIApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Adjust session timeout as needed
                options.Cookie.IsEssential = true;
            });
           


            builder.Services.AddHttpClient("ProductsApiClient",
                httpClient =>
                {
                    httpClient.DefaultRequestHeaders
                                    .Accept
                                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    httpClient.BaseAddress = new Uri("https://localHost:7159");

                });
            builder.Services.AddScoped<IProductsClient, ProductsClient>();

            builder.Services.AddHttpClient("CartsApiClient",
                httpClient =>
                {
                    httpClient.DefaultRequestHeaders
                                    .Accept
                                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    httpClient.BaseAddress = new Uri("https://localHost:7038");

                });
            builder.Services.AddScoped<ICartsClient, CartsClient>();


            //builder.Services.AddHttpClient("OrdersApiClient",
            //    httpClient =>
            //    {
            //        httpClient.DefaultRequestHeaders
            //                        .Accept
            //                        .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //        httpClient.BaseAddress = new Uri("https://localHost:7240");

            //    });
            //builder.Services.AddScoped<IOrdersClient, OrdersClient>();


            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseSession();
            app.Run();
        }
    }


}
