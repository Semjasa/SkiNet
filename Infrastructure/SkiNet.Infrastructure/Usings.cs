// Externes
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Configuration;
global using System.Reflection;
global using System.Text;
global using System.Text.Json;
global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;
global using StackExchange.Redis;

// Internes
global using SkiNet.Core.Specifications;
global using SkiNet.Core.Abstractions;
global using SkiNet.Core.Entities;
global using SkiNet.Core.Entities.Identity;
global using SkiNet.Infrastructure.Repositories;
global using SkiNet.Infrastructure.Data;
global using SkiNet.Infrastructure.Identity;