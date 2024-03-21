using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.DTOClassesMapping
{
    [JsonObject]
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
