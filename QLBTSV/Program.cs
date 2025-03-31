using BussinessLayer;
using BussinessLayer.interfaces;
using DataAccessLayer;
using DataAccessLayer.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyCors", build =>
    {
        build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IAccountsBUSS, AccountsBUS>();
builder.Services.AddTransient<IAccountsResponsitory, AccountsResponsitory>();

builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
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

app.UseCors("MyCors");

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
