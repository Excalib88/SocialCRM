using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialCRM.IdentityServer.Data;

namespace SocialCRM.IdentityServer.Controller
{
    [Authorize]
    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
    {
        
    }
}