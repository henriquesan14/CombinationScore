using Confitec.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScoreCombination.API.GraphQL.Queries;
using ScoreCombination.Application.Services;
using ScoreCombination.Core.Repositories;
using ScoreCombination.Core.Services;
using ScoreCombination.Infrastructure.Repositories;

namespace ScoreCombination.API
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DbConnection");
            services.AddDbContext<ScoreCombinationContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRequestCombinationRepository, RequestCombinationRepository>();
            services.AddScoped<IRequestCombinationService, RequestCombinationService>();

            

            services.AddGraphQLServer()
                .AddQueryType<RequestCombinationQuery>();

            services.AddCors(option =>
            {
                option.AddPolicy(AllowedOrigin, builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseCors(AllowedOrigin);

            app.UseWebSockets();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
