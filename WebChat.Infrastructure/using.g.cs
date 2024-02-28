global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using WebChat.Application.ApplicationSettings;
global using WebChat.Application.Contracts.UnitOfWork;
global using WebChat.Presistence.DBContext;
global using WebChat.Presistence.UnitOfWork;
global using WebChat.Application.Contracts.Presistence.IRepositories.Mongo;
global using WebChat.Presistence.Repositories.MongoRepositories;
global using MongoDB.Driver;
global using WebChat.Application.Contracts.Presistence.IDBContext;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Logging;
global using Asp.Versioning;
global using WebChat.Application.Helpers;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;

global using Microsoft.AspNetCore.Http;
global using WebChat.Application.Auth;

global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using WebChat.Infrastructure.Middleware.EnsureMigrationExtension;
global using WebChat.Infrastructure.Middleware.SwaggerUI;
global using WebChat.Infrastructure.Services.ModelValidation;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using WebChat.Infrastructure.Health;
global using WebChat.Infrastructure.Services.ApiVersionExtension;
global using WebChat.Infrastructure.Services.ApplicationInfrastructure;
global using WebChat.Infrastructure.Services.AuthRegistration;
global using WebChat.Infrastructure.Services.JWT;
global using WebChat.Infrastructure.Services.RabbitMQ;
global using WebChat.Infrastructure.Services.Redis;
global using WebChat.Infrastructure.Services.SwaggerExtension;
