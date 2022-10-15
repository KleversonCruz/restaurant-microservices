using Restaurants.Core;
using Restaurants.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(opt =>
    opt.SuppressAsyncSuffixInActionNames = false
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfra(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();