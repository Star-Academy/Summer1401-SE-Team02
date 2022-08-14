using SampleLibrary;
using SampleLibrary.DataProviding;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IIndexedDataRepository, InvertedIndexedDataRepository>();
builder.Services.AddSingleton<ISearchEngine, SearchEngine>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();