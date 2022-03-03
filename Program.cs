using GraphQL.Types;
using GraphQLNetExample.Extensions;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.

builder.Services.AddControllers ();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterServices ();
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen (c => {
    c.SwaggerDoc ("v1", new () { 
        Title = "GraphQLNetExample", 
        Version = "v1" });
});

var app = builder.Build ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ()) {
    app.UseSwagger ();
    app.UseSwaggerUI ();
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection ();

app.UseAuthorization ();

app.MapControllers ();

// make sure all our schemas registered to route
app.UseGraphQL<ISchema>();

app.Run ();