﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Domain.Identity;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;

namespace SHJ.BaseArchitecture.Infrastructure;

public static class IdentityConfiguration
{
    public static IServiceCollection RegisterIdentity(this IServiceCollection services)
    {

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<EfDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = true;
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });

        services.BuildTokenBase();

        return services;
    }

    private static IServiceCollection BuildTokenBase(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization(options =>
        {

        });
        return services;
    }

    private static IServiceCollection BuildCookieeBase(this IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        services.Configure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, option =>
        {
            option.LogoutPath = "/";
            option.LogoutPath = "/";
            option.AccessDeniedPath = "/";
            option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            option.Cookie.Name = "SHJ.BaseArchitecture.COOKIE";
        });
        return services;
    }
}