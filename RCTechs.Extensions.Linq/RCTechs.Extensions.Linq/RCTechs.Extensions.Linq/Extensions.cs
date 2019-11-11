using System;
using System.Collections.Generic;
using System.Linq;

namespace RCTechs.Extensions.Linq
{
    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source
                .Select(x => selector(x))
                .DefaultIfEmpty()
                .Max();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TSource MaxOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source
                .DefaultIfEmpty()
                .Max();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult MinOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source
                .Select(x => selector(x))
                .DefaultIfEmpty()
                .Min();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TSource MinOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source
                .DefaultIfEmpty()
                .Min();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source != null)
                foreach (var item in source)
                    action(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TIdentity"></typeparam>
        /// <param name="source"></param>
        /// <param name="identitySelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T, TIdentity>(this IEnumerable<T> source, Func<T, TIdentity> identitySelector)
        {
            return source.Distinct(By(identitySelector));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TIdentity"></typeparam>
        /// <param name="identitySelector"></param>
        /// <returns></returns>
        public static IEqualityComparer<TSource> By<TSource, TIdentity>(Func<TSource, TIdentity> identitySelector)
        {
            return new DelegateComparer<TSource, TIdentity>(identitySelector);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TIdentity"></typeparam>
        private class DelegateComparer<T, TIdentity> : IEqualityComparer<T>
        {
            private readonly Func<T, TIdentity> identitySelector;

            public DelegateComparer(Func<T, TIdentity> identitySelector)
            {
                this.identitySelector = identitySelector;
            }

            public bool Equals(T x, T y)
            {
                return Equals(identitySelector(x), identitySelector(y));
            }

            public int GetHashCode(T obj)
            {
                return identitySelector(obj).GetHashCode();
            }
        }
    }
}
