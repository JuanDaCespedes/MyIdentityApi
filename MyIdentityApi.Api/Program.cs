using Microsoft.EntityFrameworkCore;
using MyIdentityApi.Domain.Aggregates.UserAggregate;
using MyIdentityApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Asegúrate de que la cadena de conexión está correcta y accesible
builder.Services.AddDbContext<MyIdentityApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura Identity para usar tu clase User extendida
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyIdentityApiDbContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configuration middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.MapControllers();
app.Run();