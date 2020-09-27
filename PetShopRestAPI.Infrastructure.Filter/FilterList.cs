using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopRestAPI.Infrastructure.Filter
{
    public class FilterList<T>
    {
        public List<T> List { get; set; }
        public Filter filter { get; set; }
        public int TotalCount { get; set; }


    }
}
