using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using OrangeTemplate.ModelsDemo;
using System;
using OrangeTemplate.Helper;
using OrangeTemplate.Models;

namespace OrangeTemplate.Demo
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DynaTablePlain()
        {
            return View();
        }

        public IActionResult DynaTableAjax()
        {
            return View();
        }

        // http://localhost/demo/sourcejson
        public IActionResult SourceJson(Dictionary<string,string> queries,
            int page = 1, int offset = 10, int perPage = 10)
        {
            var items = GenerateFullItems();
            var search_item = DynaTableHelper.GetSearchItem(queries);
            var filteredItems =
                    items.Where(x => x.someAttribute.ToLower().Contains(search_item));

            var output = 
                DynaTableHelper<DemoItem>.GetTableOutput(offset, 
                perPage, items, search_item, filteredItems);

            return Json(output);
        }

       

        private static IEnumerable<DemoItem> GenerateFullItems()
        {
            return Enumerable.Range(0, 500)
                .Select(x => new DemoItem()
                {
                    someAttribute = $"attribute-{x}",
                    someOtherAttribute = $"other-{x}",
                });
        }

       
    }
}
