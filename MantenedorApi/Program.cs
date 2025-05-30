using MantenedorApi.Services.Interfaces;
using MantenedorApi.Services;
using MantenedorApi.Repository.Interfaces;
using MantenedorApi.Repository;
using MantenedorApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); //agregamos esta linea agregar controladores al swagger y funcionen
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

// scoped Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IVariableService, VariableService>();
// scoped Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IVariableRepository, VariableRepository>();

builder.Services.AddScoped<DapperContext>();
var app = builder.Build();
app.UseRouting(); //middleware encargado de hablitar el enrutamiento de la app, permite la url de las solicitudes
app.MapControllers(); //metodo que registra los controladores en el sistema de enrutamiento

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();


