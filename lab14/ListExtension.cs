using System;
using System.Collections.Generic;
using System.Text;
using lab12_collections;
using System.Linq;

namespace lab14
{

    
    public static class ListExtension
    {
        public static IEnumerable<T> Select<T>(this IEnumerable<T> people, Func<T, bool> func) => people.Where(func);
        public static int Count<T>(this IEnumerable<T> people)
        {
            int cnt = 0;
            foreach (var elem in people)
                ++cnt;
            return cnt;
        }

        public static T Aggregate<T>(this IEnumerable<T> people, Func<T, T, T> func)
        {
            int count = people.Count();
            if (count == 0) throw new Exception("Error");

            var list = people.ToList();
            T result = list[0];
            for (int i = 1; i < list.Count; ++i)
                result = func(result, list[i]);
            return result;
        }

        
        
    }
}
