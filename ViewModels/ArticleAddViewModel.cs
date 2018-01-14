using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;

namespace Brog.ViewModels
{
    public class ArticleAddViewModel
    {
        [Required, MaxLength(80)]
        [Display(Name = "Article Title")]
        public string title { get; set; }
        [Required, MaxLength(140)]
        [Display(Name = "Article Teaser")]
        public string teaser { get; set;  }
        [Required]
        [Display(Name = "Body")]
        public string articleBody { get; set;  }
    }
}
