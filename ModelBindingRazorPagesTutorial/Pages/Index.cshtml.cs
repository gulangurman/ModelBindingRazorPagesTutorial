using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/***
 * Model Binding in Razor Pages
 * 
 * Repo: https://github.com/gulangurman/ModelBindingRazorPagesTutorial.git
 * Author: Gülan Gürman
 * Date: 23.10.2021
 */

namespace ModelBindingRazorPagesTutorial.Pages
{
    // No need to bind each property one by one
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //[BindProperty]
        public string Name { get; set; }
        //[BindProperty]
        public string Email { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        // 3. Binding properties
        public void OnPost()
        {
            TempData["result"] = $"Adınız: {Name} e-posta: {Email}";
        }

        // 2. Using handler method parameters
        public void OnPost2(string name, string email)
        {
            TempData["result"] = $"Adınız: {name} e-posta: {email}";
        }

        // 1. Using Request.Form
        public void OnPost1()
        {
            var name = Request.Form["name"];
            var email = Request.Form["email"];
            TempData["result"] = $"Adınız: {name} e-posta: {email}";
        }
    }
}
