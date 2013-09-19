using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using SimpleInjector;

namespace VirtualSummit
{
    public static class SimpleInjectorExtensions
    {
        public static void Register<TService, TImplementation>(
            this Container container, IConstructorSelector selector)
            where TService : class
        {
            container.Register<TService>(() => null);

            container.ExpressionBuilt += (sender, e) =>
            {
                if (e.RegisteredServiceType == typeof (TService))
                {
                    var ctor =
                        selector.GetConstructor(typeof (TImplementation));

                    var parameters =
                        from p in ctor.GetParameters()
                        select container.GetRegistration(p.ParameterType, true)
                            .BuildExpression();

                    e.Expression = Expression.New(ctor, parameters);
                }
            };
        }
    }

    public interface IConstructorSelector
    {
        ConstructorInfo GetConstructor(Type type);
    }

    public sealed class ConstructorSelector : IConstructorSelector
    {
        public static readonly IConstructorSelector MostParameters =
            new ConstructorSelector(type => type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length).First());

        public static readonly IConstructorSelector LeastParameters =
            new ConstructorSelector(type => type.GetConstructors()
                .OrderBy(c => c.GetParameters().Length).First());

        private readonly Func<Type, ConstructorInfo> selector;

        public ConstructorSelector(Func<Type, ConstructorInfo> selector)
        {
            this.selector = selector;
        }

        public ConstructorInfo GetConstructor(Type type)
        {
            return this.selector(type);
        }
    }
}