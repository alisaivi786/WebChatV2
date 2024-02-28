﻿global using WebChat.Application.ApplicationSettings;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using WebChat.Application.Contracts.UnitOfWork;
global using WebChat.Common.Dto.RequestDtos.Message;
global using WebChat.Hubs;
global using WebChat.Extension.Extensions;
global using WebChat.Infrastructure.Services.ApplicationInfrastructure;
global using WebChat.Infrastructure.Services.RabbitMQ;
global using WebChat.Infrastructure.Services.Redis;
global using WebChat.Infrastructure.Middleware.EnsureMigrationExtension;
global using Swashbuckle.AspNetCore.Annotations;
global using WebChat.Common.Dto.RequestDtos.Group;
global using WebChat.Common.Dto.ResponseDtos.Group;
global using WebChat.Common.Dto.ResponseDtos.Message;
global using WebChat.Common.Enums.API;
global using WebChat.Common.IBaseResponse;
global using WebChat.Application.Helpers;
global using MongoDB.Bson;
global using System.Diagnostics;
global using System.Text;
global using WebChat.Common.IBaseRequest;
global using Asp.Versioning;
global using WebChat.Infrastructure.Middleware.SwaggerUI;
global using WebChat.Infrastructure.Services.ApiVersionExtension;
global using WebChat.Infrastructure.Services.SwaggerExtension;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using WebChat.Common.Dto.RequestDtos.GroupUser;
global using WebChat.Common.Dto.ResponseDtos.GroupUser;

global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Serilog;
//global using WebChat.API.Middleware;
global using WebChat.API.Controllers.BaseController;
global using WebChat.Common.Dto.RequestDtos.LotteryUsers;
global using WebChat.Infrastructure.Health;
global using WebChat.Infrastructure.Services.AuthRegistration;
global using WebChat.Infrastructure.Services.JWT;

global using WebChat.Infrastructure.Middleware.ExceptionMiddleware;
global using WebChat.Infrastructure.Services.ModelValidation;
global using WebChat.Infrastructure.Services.WebChatExtension;
global using WebChat.Infrastructure.Middleware.WebChatMiddleware;

global using WebChat.Common.Dto.RequestDtos.SubGroup;
global using WebChat.Common.Dto.ResponseDtos.SubGroup;

global using Microsoft.AspNetCore.Authorization;
global using WebChat.Application.Auth;
global using JwtService.Interface;
global using WebChat.Common.Dto.RequestDtos.User;

global using WebChat.Common.Dto.ResponseDtos.Users;
global using WebChat.Redis;
