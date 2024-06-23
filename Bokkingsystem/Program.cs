
using AutoMapper;
using Bokkingsystem.Data;
using Bokkingsystem.Models.DTOs;
using Bokkingsystem.Models.Entities;
using Bokkingsystem.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bokkingsystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookingDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<BookingDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IAppointment, AppointmentRepo>();
            builder.Services.AddScoped<IHisotry, HistoryRepository>();
            builder.Services.AddScoped<IBooking<Customer>, CustomerRepo>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });


            /*
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            */

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            builder.Services.AddSwaggerGen(swagger =>
            {
                // This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET 8 WEB API",
                    Description = "Authentication"
                });
                // To enable authorization using Swagger(JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            }
                        }, Array.Empty<string>()
                    }
                });
            });

            // Policy 
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminCompanyCustomerPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("admin", "company", "customer");
                });
                options.AddPolicy("AdminCompanyPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("admin", "company");
                });
                options.AddPolicy("AdminCustomerPolicy", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("admin", "customer");
                });
            });



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
            // Authentication
            /*app.MapPost("/register", async (RegisterDTO register, IAccountService account) =>
            {
                return Results.Ok(await account.Register(register));
            }).AllowAnonymous();
            app.MapPost("/login", async (LoginDTO login, IAccountService account) =>
            {
                return Results.Ok(await account.Login(login));
            }).AllowAnonymous();
            */
            /*
            app.MapPost("/account/create",
               async (LoginDTO model, UserManager<AppUser> userManager, IMapper mapper, BookingDbContext db) =>
               {
                   IdentityUser user = await userManager.FindByEmailAsync(model.Email);
                   if (user != null)
                   {
                       return Results.BadRequest("User already exists.");
                   }
                  AppUser newUser = new()
                   {
                       UserName = model.Email,
                       Email = model.Email,
                       Role = model.Role,
                   };
                  newUser = mapper.Map<AppUser>(model);
                   IdentityResult result = await userManager.CreateAsync(newUser, model.Password);
                   if (!result.Succeeded)
                       return Results.BadRequest("User creation failed.");


                   Claim[] userClaims = new[]
                   {
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.Role, model.Role),
                   };

                   await userManager.AddClaimsAsync(newUser, userClaims);
                   /*
                   if (model.Role == "customer")
                   {
                       Customer customer = mapper.Map<Customer>(model);
                       customer.AppUser = newUser;
                       db.Customers.Add(customer);
                   }
                   else if (model.Role == "company")
                   {
                       Company company = mapper.Map<Company>(model);
                       company.AppUser = newUser;
                       db.Companies.Add(company);
                   }*/
                  /* if (model.Role == "customer")
                   {
                       Customer customer = new Customer
                       {
                           Email = model.Email,
                           UserName = model.Email,
                           Password = model.Password,
                           Role = model.Role,
                           AppUser = newUser,
                           AppUserId = newUser.Id 
                       };
                       db.Customers.Add(customer);
                   }
                   else if (model.Role == "company")
                   {
                       Company company = new Company
                       {
                           Email = model.Email,
                           Password = model.Password,
                           Role = model.Role,
                           AppUser = newUser,
                           AppUserId = newUser.Id
                       };
                       db.Companies.Add(company);
                   }

                   await db.SaveChangesAsync();*/

            /*
                   return Results.Ok("User created successfully.");
               });

            app.MapPost("/account/login", async (string email, string password, LoginDTO model, UserManager <AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config, BookingDbContext db) =>
            {

                AppUser user = await userManager.FindByEmailAsync(email);
                if (user == null)
                    return Results.NotFound("User not found.");

                SignInResult result = await signInManager.CheckPasswordSignInAsync(user, password, false);
                if (!result.Succeeded)
                    return Results.BadRequest("Invalid credentials.");

                //var existingCustomer = await db.Customers.FirstOrDefaultAsync(c => c.Email == model.Email);
                //var existingCompany = await db.Companies.FirstOrDefaultAsync(c => c.Email == model.Email);


                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: config["Jwt:Issuer"],
                    audience: config["Jwt:Audience"],
                    claims: await userManager.GetClaimsAsync(user),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

                return Results.Ok(new JwtSecurityTokenHandler().WriteToken(token));
            });*/

            app.MapControllers();

            app.Run();
        }
    }
}
