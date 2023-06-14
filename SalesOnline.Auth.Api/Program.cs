using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SalesOnline.IOC.Dependencies;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Mis dependencias //
builder.Services.AddContextDependency(builder.Configuration.GetConnectionString("SalesContext"));
builder.Services.AddSecurityDependency();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region "Token Info"

var key = Encoding.ASCII.GetBytes(builder.Configuration["TokenInfo:SiginigKey"]);

builder.Services.AddAuthentication(jb =>
{
    jb.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    jb.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddCookie()
  .AddJwtBearer(jb =>
  {
      jb.RequireHttpsMetadata = false;
      jb.SaveToken = true;
      jb.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
      };
  });
#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
