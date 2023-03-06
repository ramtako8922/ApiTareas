using ApiTareas.Services;
using ApiTareas.Middlewares;
using static ApiTareas.Services.HolaMundo;
using ApiTareas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 builder.Services.AddSqlServer<TareasContex>("Data Source=LAPTOP-SUHATN0J\\SQLEXPRESS; Initial Catalog=TareasDB; Trusted_Connection=True; Integrated Security=True");

//builder.Services.AddScoped<IholaService,HolaMundo>();
builder.Services.AddScoped<IholaService>(p=>new HolaMundo());
//Inyeccion de dependencia
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService,TareaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

//app.UseTimeMiddlware();

app.MapControllers();

app.Run();
