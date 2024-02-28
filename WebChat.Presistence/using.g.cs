global using Microsoft.EntityFrameworkCore;
global using WebChat.Application.Contracts.Presistence.IDBContext;
global using WebChat.Domain.Entities;
global using System.Linq.Expressions;
global using WebChat.Application.Contracts.Presistence.IBaseRepository;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Configuration;
global using WebChat.Application.Response;
global using WebChat.Presistence.DBContext;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using WebChat.Domain.Abstract;
global using System.ComponentModel.DataAnnotations;

global using WebChat.Common.Enums.DB;
global using WebChat.Common.Enums.API;

global using WebChat.Application.ApplicationSettings;
global using WebChat.Application.Contracts.Presistence.IRepositories;
global using WebChat.Common.Dto.RequestDtos.Message;
global using WebChat.Common.Dto.ResponseDtos.Message;
global using WebChat.Presistence.Repositories.BaseRepository;

global using WebChat.Presistence.SeedConfiguration;
global using WebChat.Common.IBaseResponse;
global using WebChat.Common.Dto.ResponseDtos.Users;
global using WebChat.Common.Dto.ResponseDtos.Group;
global using MongoDB.Driver;
global using System.Data;
global using WebChat.Common.Dto.RequestDtos.Group;
global using WebChat.Application.Contracts.UnitOfWork;
global using WebChat.Presistence.Repositories;
global using WebChat.Common.Dto.RequestDtos.LoginInUser;
global using WebChat.Common.Dto.ResponseDtos.LoginInUser;

global using JwtService;
global using WebChat.Common.Dto.RequestDtos.LotteryUsers;
global using WebChat.Common.Dto.RequestDtos.User;
global using WebChat.Common.Dto.ResponseDtos.LotteryUsers;
global using WebChat.Extension.Extensions;
global using WebChat.Presistence.Ado;

global using WebChat.Common.Dto.RequestDtos.SubGroup;
global using WebChat.Common.Dto.ResponseDtos.SubGroup;

global using JwtService.Interface;