using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DbContext>
(Options => Options.UseSqlServer(
    "Data Source=LAPTOP-CQ8RUCFE\\SQLEXPRESS;Database=MinimalApi;Trusted_Connection=True;"));

builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();

app.MapPost("AdicionarProduto", async (Produto produto, DbContext contexto) =>
{
    DbContext.Produto.add(produto);
    await contexto.SaveChangesAsync();  
}
    );



app.MapGet("/", () => "Hello World!");

app.UseSwaggerUI();

app.Run();
