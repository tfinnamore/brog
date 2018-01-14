using System;
using System.Collections.Generic;
using Brog.Entities;

namespace Brog.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
