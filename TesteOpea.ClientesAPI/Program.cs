using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TesteOpea.ClientesAPI.Config;
using TesteOpea.ClientesAPI.Model.Context;
using TesteOpea.ClientesAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





//Injenção de Dependencia do SQL Server
builder.Services.AddDbContext<BDContext>(options =>
               options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(BDContext).Assembly.FullName)));

//Injenção do AutoMapper e Classe de Repositorio do Cliente
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();


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
