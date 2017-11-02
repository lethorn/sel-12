using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sel_12.Utils
{
    public static class CollectionUtils
    {
        /// <summary>
        /// Возвращает true, если коллекция пуста, либо не инициализирована.
        /// </summary>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count().Equals(0);
        }
    }
}
