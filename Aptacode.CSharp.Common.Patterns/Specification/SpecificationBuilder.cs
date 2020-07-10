﻿using System.Threading.Tasks;

namespace Aptacode.CSharp.Common.Patterns.Specification {
    public static class SpecificationBuilder
    {
        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
        {
            return left == right ? left : new AndSpecification<T>(left, right);
        }

        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right)
        {
            return left == right ? left : new OrSpecification<T>(left, right);
        }

        public static Specification<T> Identity<T>()
        {
            return new IdentitySpecification<T>();
        }

        public static Specification<T> Not<T>(this Specification<T> specification) => new NotSpecification<T>(specification);
    }
}