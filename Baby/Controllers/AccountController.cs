using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Baby.Models;
using Baby.Models.ViewModels;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using Baby.Controllers.Base;

namespace Baby.Controllers
{
	[Authorize]
	public class AccountController : BaseController
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public AccountController()
		{
		}

		public AccountController( ApplicationUserManager userManager, ApplicationSignInManager signInManager )
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		// GET: /Account/Users
		public ActionResult Users()
		{
			//			var addresses = db.Addresses.Include( a => a.Advertiser ).Include( a => a.Country ).Include( a => a.Organization ).Include( a => a.User );
			//			return View( addresses.ToList() );
			var user = UserManager.FindById( User.Identity.GetUserId() );
			var users = db.Users.Where( u => u.OrganizationId == user.OrganizationId );
			return View( users.ToList() );
		}

		// GET: /Account/Apply
		[AllowAnonymous]
		public ActionResult Apply()
		{
			ViewBag.CountryList = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
			return View();
		}

		// POST: /Account/Apply
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Apply( ApplicationViewModel model )
		{
			if ( ModelState.IsValid )
			{
				Guid orgGuid = Guid.NewGuid();

				try
				{
					var org = new Organization
					{
						OrganizationId = orgGuid,
						Name = model.OrganizationName,
						OfficialOrganizationId = model.OfficialOrganizationId,
						Status = "Submitted",
						ApplicationSubmissionDate = DateTime.Now,
					};

					db.Organizations.Add( org );
					db.SaveChanges();

					var email = new Email
					{
						EmailId = Guid.NewGuid(),
						Type = "Work",
						Address = model.Email,
						OrganizationId = orgGuid
					};
					db.Emails.Add( email );
					db.SaveChanges();

					var address = new Address
					{
						AddressId = Guid.NewGuid(),
						Type = "Mailing",
						Street1 = model.StreetAddress1,
						Street2 = model.StreetAddress2,
						District = model.District,
						City = model.City,
						StateOrProvince = model.StateOrProvince,
						CountryId = model.CountryId,
						PostalCode = model.PostalCode,
						OrganizationId = orgGuid
					};
					db.Addresses.Add( address );
					db.SaveChanges();

					var phone = new Phone
					{
						PhoneId = Guid.NewGuid(),
						Type = "Work",
						Number = model.PhoneNumber,
						OrganizationId = orgGuid
					};
					db.Phones.Add( phone );
					db.SaveChanges();

					return RedirectToAction( "ApplicationSubmitted" );
				}
				catch ( Exception /*e*/ )
				{
					//TODO:  Need to handle unique constraint issues with emails an official org id - need to display error

					// we need to delete the organization if it exists
					Organization org = db.Organizations.Find( orgGuid );
					db.Organizations.Remove( org );
					db.SaveChanges();

					ViewBag.CountryList = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
					return View();

				}
			}

			// If we got this far, something failed, redisplay form
			ViewBag.CountryList = new SelectList( db.Countries.OrderBy( c => c.Name ), "CountryId", "Name" );
			return View( model );

		}

		// GET: /Account/ApplicationSubmitted
		[AllowAnonymous]
		public ActionResult ApplicationSubmitted()
		{
			return View();
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login( string returnUrl )
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login( LoginViewModel model, string returnUrl )
		{
			if ( !ModelState.IsValid )
			{
				return View( model );
			}

			// This doesn't count login failures towards account lockout
			// To enable password failures to trigger account lockout, change to shouldLockout: true
			var result = await SignInManager.PasswordSignInAsync( model.UserName, model.Password, model.RememberMe, shouldLockout: false );
			switch ( result )
			{
				case SignInStatus.Success:
					ApplicationUser user = db.Users.FirstOrDefault( u => u.UserName == model.UserName );
					if ( user.OrganizationId == null )
					{
						return RedirectToAction( "Index", "Admin" );
					}
					return RedirectToLocal( returnUrl );
				case SignInStatus.LockedOut:
					return View( "Lockout" );
				case SignInStatus.RequiresVerification:
					return RedirectToAction( "SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe } );
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError( "", "Invalid login attempt." );
					return View( model );
			}
		}

		//
		// GET: /Account/VerifyCode
		[AllowAnonymous]
		public async Task<ActionResult> VerifyCode( string provider, string returnUrl, bool rememberMe )
		{
			// Require that the user has already logged in via username/password or external login
			if ( !await SignInManager.HasBeenVerifiedAsync() )
			{
				return View( "Error" );
			}
			return View( new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe } );
		}

		//
		// POST: /Account/VerifyCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> VerifyCode( VerifyCodeViewModel model )
		{
			if ( !ModelState.IsValid )
			{
				return View( model );
			}

			// The following code protects for brute force attacks against the two factor codes. 
			// If a user enters incorrect codes for a specified amount of time then the user account 
			// will be locked out for a specified amount of time. 
			// You can configure the account lockout settings in IdentityConfig
			var result = await SignInManager.TwoFactorSignInAsync( model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser );
			switch ( result )
			{
				case SignInStatus.Success:
					return RedirectToLocal( model.ReturnUrl );
				case SignInStatus.LockedOut:
					return View( "Lockout" );
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError( "", "Invalid code." );
					return View( model );
			}
		}

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register( Guid orgid )
		{
			ApplicationUser user = db.Users.FirstOrDefault( u => u.OrganizationId == orgid );

			// if this is the first time this link has been accessed for the organization (in other words, they do not have a user set up yet)
			if ( user == default( ApplicationUser ) )
			{
				Organization org = db.Organizations.First( o => o.OrganizationId == orgid );

				if ( org != null )
				{
					return View( new RegisterViewModel() { OrganizationId = orgid, Email = org.Emails.First().Address, Phone = org.Phones.First().Number } );
				}
			} // if ( user == default( ApplicationUser ) )

			return RedirectToAction( "Account", "Login" );
		}

		//
		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register( RegisterViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var user = new ApplicationUser
				{
					UserName = model.UserName,
					Email = model.Email,
					Surname = model.Surname,
					GivenNames = model.GivenNames,
					OrganizationId = model.OrganizationId
				};

				var result = await UserManager.CreateAsync( user, model.Password );

				if ( result.Succeeded )
				{
					try
					{
						var Email = new Email
						{
							EmailId = Guid.NewGuid(),
							Address = model.Email,
							Type = "Work",
							UserId = user.Id
						};
						db.Emails.Add( Email );

						var Phone = new Phone
						{
							PhoneId = Guid.NewGuid(),
							Number = model.Phone,
							Type = "Work",
							UserId = user.Id
						};
						db.Phones.Add( Phone );

						db.SaveChanges();
					}
					catch ( Exception /*e*/ )
					{
						//TODO handle problems with saving email and phone number here
					}

					await SignInManager.SignInAsync( user, isPersistent: false, rememberBrowser: false );

					// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
					// Send an email with this link
					// string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
					// var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
					// await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

					return RedirectToAction( "Index", "Home" );
				}

				AddErrors( result );
			}

			// If we got this far, something failed, redisplay form
			return View( model );
		}

		//
		// GET: /Account/Create
		[Authorize]
		public ActionResult CreateUser()
		{
			return View();
		}

		//
		// POST: /Account/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateUser( RegisterViewModel model )
		{
			if ( ModelState.IsValid )
			{
				Guid? orgid = UserManager.FindById( User.Identity.GetUserId() ).OrganizationId;

				var user = new ApplicationUser
				{
					UserName = model.UserName,
					Email = model.Email,
					Surname = model.Surname,
					GivenNames = model.GivenNames,
					OrganizationId = orgid
				};

				var result = await UserManager.CreateAsync( user, model.Password );

				if ( result.Succeeded )
				{
					try
					{
						var Email = new Email
						{
							EmailId = Guid.NewGuid(),
							Address = model.Email,
							Type = "Work",
							UserId = user.Id
						};
						db.Emails.Add( Email );

						var Phone = new Phone
						{
							PhoneId = Guid.NewGuid(),
							Number = model.Phone,
							Type = "Work",
							UserId = user.Id
						};
						db.Phones.Add( Phone );

						db.SaveChanges();
					}
					catch ( Exception /*e*/ )
					{
						//TODO handle problems with saving email and phone number here
					}

					return RedirectToAction( "Users", "Account" );
				}

				AddErrors( result );
			}

			// If we got this far, something failed, redisplay form
			return View( model );
		}


		//
		// GET: /Account/ConfirmEmail
		[AllowAnonymous]
		public async Task<ActionResult> ConfirmEmail( string userId, string code )
		{
			if ( userId == null || code == null )
			{
				return View( "Error" );
			}
			var result = await UserManager.ConfirmEmailAsync( userId, code );
			return View( result.Succeeded ? "ConfirmEmail" : "Error" );
		}

		//
		// GET: /Account/ForgotPassword
		[AllowAnonymous]
		public ActionResult ForgotPassword()
		{
			return View();
		}

		//
		// POST: /Account/ForgotPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ForgotPassword( ForgotPasswordViewModel model )
		{
			if ( ModelState.IsValid )
			{
				var user = await UserManager.FindByNameAsync( model.Email );
				if ( user == null || !( await UserManager.IsEmailConfirmedAsync( user.Id ) ) )
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View( "ForgotPasswordConfirmation" );
				}

				// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
				// Send an email with this link
				// string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
				// var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
				// await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
				// return RedirectToAction("ForgotPasswordConfirmation", "Account");
			}

			// If we got this far, something failed, redisplay form
			return View( model );
		}

		//
		// GET: /Account/ForgotPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		//
		// GET: /Account/ResetPassword
		[AllowAnonymous]
		public ActionResult ResetPassword( string code )
		{
			return code == null ? View( "Error" ) : View();
		}

		//
		// POST: /Account/ResetPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ResetPassword( ResetPasswordViewModel model )
		{
			if ( !ModelState.IsValid )
			{
				return View( model );
			}
			var user = await UserManager.FindByNameAsync( model.Email );
			if ( user == null )
			{
				// Don't reveal that the user does not exist
				return RedirectToAction( "ResetPasswordConfirmation", "Account" );
			}
			var result = await UserManager.ResetPasswordAsync( user.Id, model.Code, model.Password );
			if ( result.Succeeded )
			{
				return RedirectToAction( "ResetPasswordConfirmation", "Account" );
			}
			AddErrors( result );
			return View();
		}

		//
		// GET: /Account/ResetPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		//
		// POST: /Account/ExternalLogin
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult ExternalLogin( string provider, string returnUrl )
		{
			// Request a redirect to the external login provider
			return new ChallengeResult( provider, Url.Action( "ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl } ) );
		}

		//
		// GET: /Account/SendCode
		[AllowAnonymous]
		public async Task<ActionResult> SendCode( string returnUrl, bool rememberMe )
		{
			var userId = await SignInManager.GetVerifiedUserIdAsync();
			if ( userId == null )
			{
				return View( "Error" );
			}
			var userFactors = await UserManager.GetValidTwoFactorProvidersAsync( userId );
			var factorOptions = userFactors.Select( purpose => new SelectListItem { Text = purpose, Value = purpose } ).ToList();
			return View( new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe } );
		}

		//
		// POST: /Account/SendCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SendCode( SendCodeViewModel model )
		{
			if ( !ModelState.IsValid )
			{
				return View();
			}

			// Generate the token and send it
			if ( !await SignInManager.SendTwoFactorCodeAsync( model.SelectedProvider ) )
			{
				return View( "Error" );
			}
			return RedirectToAction( "VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe } );
		}

		//
		// GET: /Account/ExternalLoginCallback
		[AllowAnonymous]
		public async Task<ActionResult> ExternalLoginCallback( string returnUrl )
		{
			var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
			if ( loginInfo == null )
			{
				return RedirectToAction( "Login" );
			}

			// Sign in the user with this external login provider if the user already has a login
			var result = await SignInManager.ExternalSignInAsync( loginInfo, isPersistent: false );
			switch ( result )
			{
				case SignInStatus.Success:
					return RedirectToLocal( returnUrl );
				case SignInStatus.LockedOut:
					return View( "Lockout" );
				case SignInStatus.RequiresVerification:
					return RedirectToAction( "SendCode", new { ReturnUrl = returnUrl, RememberMe = false } );
				case SignInStatus.Failure:
				default:
					// If the user does not have an account, then prompt the user to create an account
					ViewBag.ReturnUrl = returnUrl;
					ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
					return View( "ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email } );
			}
		}

		//
		// POST: /Account/ExternalLoginConfirmation
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ExternalLoginConfirmation( ExternalLoginConfirmationViewModel model, string returnUrl )
		{
			if ( User.Identity.IsAuthenticated )
			{
				return RedirectToAction( "Index", "Manage" );
			}

			if ( ModelState.IsValid )
			{
				// Get the information about the user from the external login provider
				var info = await AuthenticationManager.GetExternalLoginInfoAsync();
				if ( info == null )
				{
					return View( "ExternalLoginFailure" );
				}
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await UserManager.CreateAsync( user );
				if ( result.Succeeded )
				{
					result = await UserManager.AddLoginAsync( user.Id, info.Login );
					if ( result.Succeeded )
					{
						await SignInManager.SignInAsync( user, isPersistent: false, rememberBrowser: false );
						return RedirectToLocal( returnUrl );
					}
				}
				AddErrors( result );
			}

			ViewBag.ReturnUrl = returnUrl;
			return View( model );
		}

		//
		// POST: /Account/LogOff
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			AuthenticationManager.SignOut( DefaultAuthenticationTypes.ApplicationCookie );
			return RedirectToAction( "Index", "Home" );
		}

		//
		// GET: /Account/ExternalLoginFailure
		[AllowAnonymous]
		public ActionResult ExternalLoginFailure()
		{
			return View();
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				if ( _userManager != null )
				{
					_userManager.Dispose();
					_userManager = null;
				}

				if ( _signInManager != null )
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose( disposing );
		}

		#region Helpers
		// Used for XSRF protection when adding external logins
		private const string XsrfKey = "XsrfId";

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private void AddErrors( IdentityResult result )
		{
			foreach ( var error in result.Errors )
			{
				ModelState.AddModelError( "", error );
			}
		}

		private ActionResult RedirectToLocal( string returnUrl )
		{
			if ( Url.IsLocalUrl( returnUrl ) )
			{
				return Redirect( returnUrl );
			}
			return RedirectToAction( "Index", "Home" );
		}

		internal class ChallengeResult : HttpUnauthorizedResult
		{
			public ChallengeResult( string provider, string redirectUri )
				 : this( provider, redirectUri, null )
			{
			}

			public ChallengeResult( string provider, string redirectUri, string userId )
			{
				LoginProvider = provider;
				RedirectUri = redirectUri;
				UserId = userId;
			}

			public string LoginProvider { get; set; }
			public string RedirectUri { get; set; }
			public string UserId { get; set; }

			public override void ExecuteResult( ControllerContext context )
			{
				var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
				if ( UserId != null )
				{
					properties.Dictionary[ XsrfKey ] = UserId;
				}
				context.HttpContext.GetOwinContext().Authentication.Challenge( properties, LoginProvider );
			}
		}
		#endregion
	}
}