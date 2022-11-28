using OrangeTemplate.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrangeTemplate.Helper
{
    public class DynaTableHelper
    {
        public static string GetSearchItem(Dictionary<string, string> queries)
        {
            var result = "";
            queries.TryGetValue("search", out result);
            return result;
        }




    }
    public class DynaTableHelper<T>
    {


        public static List<T> GetItems(int offset,
            int limit, IEnumerable<T> filteredItems)
        {
            var totalSkips = offset;
            var result = filteredItems
                .Skip(totalSkips)
                .Take(limit)
                .ToList();
            return result;
        }


        public static DynaTable<T> GetTableOutput(int offset, int perPage,
            IEnumerable<T> fullItems, string search_item, IEnumerable<T> filteredItems)
        {

            var totalRecordCount = fullItems.Count();

            var inputItems = fullItems.AsEnumerable();
            var queryRecordCount = totalRecordCount;
            
            if (string.IsNullOrEmpty(search_item) == false)
            {
                inputItems = filteredItems;
                queryRecordCount = filteredItems.Count();
            }

            var result = GetItems(offset, perPage, inputItems);
            var output = new DynaTable<T>()
            {
                records = result,
                totalRecordCount = totalRecordCount,
                queryRecordCount = queryRecordCount
            };
            return output;
        }

    }
}
