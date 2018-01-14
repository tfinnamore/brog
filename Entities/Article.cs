using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;

namespace Brog.Entities
{
    public class Article
    {
        public int id { get; set; }

        [Required, MaxLength(80)]
        public string title { get; set; }
        [Required, MaxLength(140)]
        public string teaser { get; set; }
        [Required]
        public string body { get; set;  }



    }

}
