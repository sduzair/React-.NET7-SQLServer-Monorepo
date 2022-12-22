using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Models.Config;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("ProductsContext");
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "ProductsDOTNET API",
		Description = ".NET Advanced Project",
		Version = "v1"
	});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
	{
	  new OpenApiSecurityScheme
	  {
		Reference = new OpenApiReference
		{
		  Type = ReferenceType.SecurityScheme,
		  Id = "Bearer"
		}
	  },
	  Array.Empty<string>()
	}
  });
	c.EnableAnnotations();
	string filePath = Path.Combine(AppContext.BaseDirectory, "ProductsApi.xml");
	c.IncludeXmlComments(filePath);
	//c.SchemaFilter<SwaggerSchemaExampleFilter>();
});
// builder.Services.AddHttpsRedirection(options =>
// {
//   options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
//   options.HttpsPort = 5001;
// });
if (builder.Environment.IsDevelopment())
{
	_ = builder.Services.AddCors(
	  options =>
		options.AddPolicy(name: "_allowDevelopmentLocalhost",
		  policy => policy.WithOrigins(
			builder.Configuration.GetSection("LocalHostClient").Value!
		  ).AllowAnyMethod().AllowAnyHeader())
	);
}
//* ADD IDENTITY BEFORE ADDING AUTHENTICATION 
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<ApiDbContext>()
// .AddSignInManager();
.AddRoles<IdentityRole>();
TokenValidationParameters tokenValidationParameters = new()
{
	ValidateIssuerSigningKey = true,
	IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Secret").Value!)),
	ValidateIssuer = true,
	ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value!,
	ValidateAudience = true,
	ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value!,
	ValidateLifetime = true,
	ClockSkew = TimeSpan.Zero
};
// builder.Services.AddScoped<IAuthRepository, AuthRepository>();  // makes _authRepository (not exists) available in controller
builder.Services.AddSingleton(tokenValidationParameters);     // makes _tokenValidationParameters available in controller

List<RoleConfig> roles = builder.Configuration.GetSection("Roles").Get<List<RoleConfig>>()!;
builder.Services.AddSingleton(roles);

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
  .AddJwtBearer(options =>
  {
	  options.SaveToken = true;
	  options.RequireHttpsMetadata = true;   //* 'false' for development only
	  options.TokenValidationParameters = tokenValidationParameters;
  }
  );
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
	options.Cookie.SameSite = SameSiteMode.Strict;
});

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());








WebApplication app = builder.Build();
app.UseExceptionHandler();
app.UseStatusCodePages();
_ = app.UseSwagger();   // swagger definitions
if (app.Environment.IsDevelopment())
{
	_ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAPI v1"));
	_ = app.UseDeveloperExceptionPage();
}
else
{
	_ = app.UseHsts();
}
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
	_ = app.UseCors("_allowDevelopmentLocalhost");
}
app.UseHttpLogging();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();

// seed data
app.Logger.LogInformation("Seeding roles");
ApiDbInitializer.SeedRolesAsync(app, roles).Wait();

if (app.Environment.IsDevelopment())
{
	app.Logger.LogInformation("Seeding development data and test users");
	ApiDbInitializer.SeedDbDevelopmentAsync(app).Wait();
}

app.Run();
