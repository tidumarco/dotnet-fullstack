using DrinkApi.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<DrinkContext>("Data Source=Drinks.db");

var app = builder.Build();

app.CreateDbIfNotExists();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder =>
{
	builder.AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader();
});

app.MapControllers();

app.Run();
