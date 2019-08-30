using System;
using System.Collections.Generic;
using System.Linq;

namespace RCTechs.Extensions.Linq
{
    public static class Extensions
    {
        public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source
                .Select(x => selector(x))
                .DefaultIfEmpty()
                .Max();
        }
    }
}
