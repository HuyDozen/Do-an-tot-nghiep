using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Application.Services;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Repositories;
using Ecommerce.Website.Database.Models.Configiurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//Cau hinh cho mail
var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

//Cau hinh cho JWT
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

/// <summary>
/// Mã hoá và sinh ra jwt
/// Secret key
/// </summary>
var secretKey = builder.Configuration["AppSettings:SecretKey"];
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

// Xử lý, tính toán và configuration
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    {
        opt.SaveToken = true;
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            // Tự cấp token
            ValidateIssuer = false, //Tự cấp, nếu cấp phải chỉ dịch vụ mih chọn
            ValidateAudience = false,

            // Ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes), // Sử dụng thuật toán đối xứng

            ClockSkew = TimeSpan.Zero,

            ValidateLifetime = true,
            RequireExpirationTime = false,
        };
    });

// Add services to the container.

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Tự động khởi tạo class sau đó tiêm vào nó tự động khởi tạo
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();


// Map section
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "WEB API CHO ĐỒ ÁN TỐT NGHIỆP NĂM 2023", Version = "v1" });
});

builder.Services.AddDbContext<EcommerceContext>(
    opt => opt
    //.UseLazyLoadingProxies()
    .UseNpgsql(builder.Configuration.GetConnectionString("EF_postgreSql"))
    );

//builder.Services.AddIdentity<IdentityUser,IdentityRole>(opt =>
//    opt.SignIn.RequireConfirmedAccount = true
//).AddEntityFrameworkStore

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

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
