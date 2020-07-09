﻿using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Persistence.Specification.Composition;

namespace Aptacode.CSharp.Common.Persistence.Specification
{
    public abstract class Specification<T>
    {
        public static readonly Specification<T> All = new IdentitySpecification<T>();

        public bool IsSatisfiedBy(T entity) => ToExpression().Compile().Invoke(entity);

        public abstract Expression<Func<T, bool>> ToExpression();

        public Specification<T> And(Specification<T> specification)
        {
            if (this == All)
            {
                return specification;
            }

            return specification == All ? this : new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            if (this == All || specification == All)
            {
                return All;
            }

            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not() => new NotSpecification<T>(this);
    }
}