// Externes
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.OpenApi.Models;
global using System.Text.Json;
global using System.Net;
global using System.Security.Claims;
global using System.ComponentModel.DataAnnotations;
global using StackExchange.Redis;


// Internes
global using SkiNet.Api.Dtos;
global using SkiNet.Api.Extensions;
global using SkiNet.Api.Errors;
global using SkiNet.Api.Helpers;
global using SkiNet.Api.Middleware;
global using SkiNet.Core.Specifications;
global using SkiNet.Core.Abstractions;
global using SkiNet.Core.Entities;
global using SkiNet.Core.Models;
global using SkiNet.Core.Entities.Identity;
global using SkiNet.Infrastructure.Extensions;
global using SkiNet.Infrastructure.Data;
global using SkiNet.Infrastructure.Identity;