using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Configure EF Core DbContext and repository DI
builder.Services.AddDbContext<DA.Persistence.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sql =>
        sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: System.TimeSpan.FromSeconds(30), errorNumbersToAdd: null)));

builder.Services.AddScoped(typeof(DA.Repositories.IRepository<>), typeof(DA.Repositories.EfRepository<>));
builder.Services.AddScoped<DA.UnitOfWork.IUnitOfWork, DA.UnitOfWork.EfUnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
