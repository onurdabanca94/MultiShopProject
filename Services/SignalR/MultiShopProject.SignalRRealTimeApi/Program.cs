using MultiShopProject.SignalRRealTimeApi.Hubs;
using MultiShopProject.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShopProject.SignalRRealTimeApi.Services.SignalRMessageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISignalRMessageService, SignalRMessageService>();
builder.Services.AddScoped<ISignalRCommentService, SignalRCommentService>();

builder.Services.AddSignalR();

builder.Services.AddControllers();
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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();


//localhost://1234/swagger/category/index --> maphub bizde url'de port no ve s�n�f�n ismine gidecek �ekilde y�nlendirmeye yarayacak.