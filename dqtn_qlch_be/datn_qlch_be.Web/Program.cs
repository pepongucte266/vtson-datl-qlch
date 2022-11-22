using datn_qlch_be.Core.Exceptions;
using datn_qlch_be.Core.Interfaces.repository;
using datn_qlch_be.Core.Interfaces.services;
using datn_qlch_be.Core.Services;
using datn_qlch_be.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", b =>
    {
        //b.WithOrigins(Configuration["Web:Origin"].Split(","))
        b.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .Build();
    });
});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));


builder.Services.AddScoped<IFoodUnitRepository, FoodUnitRepository>();
builder.Services.AddScoped<IFoodUnitService, FoodUnitService>();

builder.Services.AddScoped<IFoodCategoryRepository, FoodCategoryRepository>();
builder.Services.AddScoped<IFoodCategoryService, FoodCategoryService>();

builder.Services.AddScoped<IFoodPlaceRepository, FoodPlaceRepository>();
builder.Services.AddScoped<IFoodPlaceService, FoodPlaceService>();

builder.Services.AddScoped<IFoodGroupRepository, FoodGroupRepository>();
builder.Services.AddScoped<IFoodGroupService, FoodGroupService>();

builder.Services.AddScoped<IFoodSequenceRepository, FoodSequenceRepository>();
builder.Services.AddScoped<IFoodSequenceService, FoodSequenceService>();

builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();

builder.Services.AddScoped<IFavoriteServiceRepository, FavoriteServiceRepository>();
builder.Services.AddScoped<IFavoriteServiceService, FavoriteServiceService>();

builder.Services.AddScoped<IFavoriteServiceGroupRepository, FavoriteServiceGroupRepository>();
builder.Services.AddScoped<IFavoriteServiceGroupService, FavoriteServiceGroupService>();

builder.Services.AddScoped<IFoodFavoriteServiceRepository, FoodFavoriteServiceRepository>();
builder.Services.AddScoped<IFoodFavoriteServiceService, FoodFavoriteServiceService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
