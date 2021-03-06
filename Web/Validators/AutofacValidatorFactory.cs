﻿namespace Levelnis.Learning.AutofacExamples.Web.Validators
{
    using System;
    using Autofac;
    using FluentValidation;

    public class AutofacValidatorFactory : IValidatorFactory
    {
        private readonly IComponentContext container;

        public AutofacValidatorFactory(IComponentContext container)
        {
            this.container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)GetValidator(typeof(T));
        }

        public IValidator GetValidator(Type type)
        {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            object validator;
            if (container.TryResolve(genericType, out validator))
                return (IValidator)validator;

            return null;
        }
    }
}