using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bootcamp_names.Pages
{
    public class IndexModel : PageModel
    {

        public string Users { get; private set; } = "PageModel in C#";

        public void OnGet()
        {
            Users += $"Edmar";
        }
    }
}
