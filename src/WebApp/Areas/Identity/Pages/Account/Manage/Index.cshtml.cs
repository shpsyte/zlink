using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Areas.Identity.Pages.Account.Manage {
    public partial class IndexModel : PageModel {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IEmailSender _emailSender;

        public IndexModel (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender
        ) {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;

        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display (Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public IFormFile avatarImage { get; set; }
            public byte[] Avatar { get; set; }

            [Display (Name = "Name")]
            public string FirstName { get; set; }

            [Display (Name = "Last Name")]
            public string LastName { get; set; }

            [Url]
            [Display (Name = "Main URl of Profile")]
            public string MainLinkImg { get; set; }

            [Display (Name = "Theme")]
            public string Theme { get; set; }

            [Display (Name = "Custom Css")]
            public string CssFile { get; set; }

            public bool RemoveImg { get; set; }

            public string GetImgConverted {
                get {
                    byte[] data = this.Avatar;
                    if (data == null) {
                        data = new byte[0];
                    }
                    return $"data:image/jpeg;base64,{Convert.ToBase64String (data)}";
                }
            }

        }

        public async Task<IActionResult> OnGetAsync () {
            var user = await _userManager.GetUserAsync (User);
            if (user == null) {
                return NotFound ($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync (user);
            var email = await _userManager.GetEmailAsync (user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync (user);
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var mainLinkImg = user.MainLinkImg;
            var theme = user.Theme;
            var cssFile = user.CssFile;
            var avatar = user.Avatar;

            Username = userName;

            Input = new InputModel {
                Email = email,
                PhoneNumber = phoneNumber,
                CssFile = cssFile,
                FirstName = firstName,
                LastName = lastName,
                Theme = theme,
                MainLinkImg = mainLinkImg,
                Avatar = avatar,
                RemoveImg = false
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync (user);

            return Page ();
        }

        public async Task<IActionResult> OnPostAsync () {
            if (!ModelState.IsValid) {
                return Page ();
            }

            var user = await _userManager.GetUserAsync (User);
            if (user == null) {
                return NotFound ($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync (user);
            if (Input.Email != email) {
                var setEmailResult = await _userManager.SetEmailAsync (user, Input.Email);
                if (!setEmailResult.Succeeded) {
                    var userId = await _userManager.GetUserIdAsync (user);
                    throw new InvalidOperationException ($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync (user);
            if (Input.PhoneNumber != phoneNumber) {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync (user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded) {
                    var userId = await _userManager.GetUserIdAsync (user);
                    throw new InvalidOperationException ($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            user.MainLinkImg = Input.MainLinkImg;
            user.CssFile = Input.CssFile;
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.Theme = Input.Theme;
            user.MainLinkImg = Input.MainLinkImg;

            if (Input.RemoveImg == false) {

                using (var memoryStream = new MemoryStream ()) {

                    try {
                        Input.avatarImage.CopyTo (memoryStream);
                        user.Avatar = memoryStream.ToArray ();
                    } catch {

                    }

                }

            } else {
                user.Avatar = null;
            }

            var userResutl = await _userManager.UpdateAsync (user);
            if (!userResutl.Succeeded) {
                var userId = await _userManager.GetUserIdAsync (user);
                throw new InvalidOperationException ($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
            }

            await _signInManager.RefreshSignInAsync (user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage ();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync () {
            if (!ModelState.IsValid) {
                return Page ();
            }

            var user = await _userManager.GetUserAsync (User);
            if (user == null) {
                return NotFound ($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = await _userManager.GetUserIdAsync (user);
            var email = await _userManager.GetEmailAsync (user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync (user);
            var callbackUrl = Url.Page (
                "/Account/ConfirmEmail",
                pageHandler : null,
                values : new { userId = userId, code = code },
                protocol : Request.Scheme);
            await _emailSender.SendEmailAsync (
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage ();
        }
    }
}