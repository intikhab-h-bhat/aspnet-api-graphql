using Microsoft.EntityFrameworkCore;
using WebApi.Graphql.Data;
using WebApi.Graphql.GraphQl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Replace with your React app URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddScoped<WebApi.Graphql.GraphQl.Query>();
builder.Services.AddScoped<WebApi.Graphql.GraphQl.Mutation>();
// Add GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");  // Apply CORS Policy
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Enable GraphQL
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();  // GraphQL API
});

app.Run();
