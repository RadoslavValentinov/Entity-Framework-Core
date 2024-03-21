using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.DTOClassesMapping
{
    [JsonObject]
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("SellerId")]
        public int SellerId { get; set; }

        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
