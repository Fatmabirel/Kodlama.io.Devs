﻿using AutoMapper.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Application.Features.ProgrammingLanguages.Rules;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // AutoMapper yapılandırması
            services.AddAutoMapper(cfg =>
            {
                cfg.Internal().MethodMappingEnabled = false; // MethodMapping'i devre dışı bırak
            }, Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
