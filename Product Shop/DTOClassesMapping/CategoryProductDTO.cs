using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.DTOClassesMapping
{
    [JsonObject]
    public class CategoryProductDTO
    {
        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("ProductId")]
        public int ProductId { get; set; }
    }
}
