using System.Collections.Generic;
using System.Linq;

namespace Distrib.Helper.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool AllAreNull<T>(this IEnumerable<T> enumerable) => enumerable.All(x => x == null);
    }
}
