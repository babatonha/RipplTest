using Microsoft.EntityFrameworkCore;
using Rippl.BusinessLayer.Interfaces.External;
using Rippl.BusinessLayer.Interfaces.Services;
using Rippl.BusinessLayer.Services;
using Rippl.BusinessLayer.Services.External;
using Rippl.DataLayer;
using Rippl.DataLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VouchersDbConnectionString")));


builder.Services.AddScoped<IVoucherProviderService, VoucherProviderService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IVoucherTransactionRepository, VoucherTransactionRepository>();

builder.Services.AddMemoryCache();

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
