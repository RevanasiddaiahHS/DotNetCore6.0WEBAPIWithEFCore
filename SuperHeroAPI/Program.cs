using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Revana addingstarts   
//Configuring the  JWT Authentication Service
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "JwtBearer";
    option.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", jwtOptions =>
    {
        jwtOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")),
            ValidateIssuer=true,
            ValidateAudience=true,
            ValidIssuer= "https://localhost:44352",
            ValidAudience= "https://localhost:44352",
            ValidateLifetime=true
        };
    });
//Revana adding Ends
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
