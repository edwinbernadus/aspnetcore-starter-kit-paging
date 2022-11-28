using System.Collections.Generic;
using OrangeTemplate.ModelsDemo;

namespace OrangeTemplate.Helper
{
    public class DynaTable<T>
    {
        public List<T> records { get; set; }
        public int queryRecordCount { get; set; }
        public int totalRecordCount { get; set; }
    }
}