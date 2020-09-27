using System;

namespace PetShopRestAPI.Infrastructure.Filter
{
    public class Filter
    {
        public string OrderBy { get; set; } = "asc";
        public int? NumberPerPage { get; set; } = 10;
        public string Search { get; set; }
        public string SearchField { get; set; }
    }
}
