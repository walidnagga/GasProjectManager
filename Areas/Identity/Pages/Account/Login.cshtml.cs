using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GasProjectManager.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        public readonly SignInManager<IdentityUser> _signInManager;
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if (ModelState.IsValid)
            {
               
                var result = await _signInManager.PasswordSignInAsync(Input.Matricule, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded) return LocalRedirect(ReturnUrl);
               
            }

            return Page();
        }

        public class InputModel
        {
            [Required]
            public string Matricule { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
    }
}
