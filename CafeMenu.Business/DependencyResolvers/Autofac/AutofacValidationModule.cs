﻿using Autofac;
using CafeMenu.Business.ValidationRules.FluentValidation;
using CafeMenu.Entities.Dtos;
using FluentValidation;

namespace CafeMenu.Business.DependencyResolvers.Autofac
{
    public class AutofacValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserLoginValidator>().As<IValidator<UserForLoginDto>>();
            builder.RegisterType<UserRegisterValidator>().As<IValidator<UserForRegisterDto>>();
            builder.RegisterType<CategoryAddValidator>().As<IValidator<CategoryAddDto>>();
            builder.RegisterType<CategoryUpdateValidator>().As<IValidator<CategoryUpdateDto>>();
            builder.RegisterType<PropertyAddValidator>().As<IValidator<PropertyAddDto>>();
            builder.RegisterType<PropertyUpdateValidator>().As<IValidator<PropertyUpdateDto>>();
        }
    }
}
