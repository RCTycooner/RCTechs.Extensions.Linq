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
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static TResult MInOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source
                .Select(x => selector(x))
                .DefaultIfEmpty()
                .Min();
        }
    }
}
