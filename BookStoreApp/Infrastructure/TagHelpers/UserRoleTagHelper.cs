using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BookStoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td",Attributes ="user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleTagHelper(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public string UserName { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            TagBuilder ul = new TagBuilder("ul");

            var roles = _roleManager.Roles.ToList().Select(p => p.Name);

            foreach (var role in roles)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml.Append($"{role} : {await _userManager.IsInRoleAsync(user,role)}");
                ul.InnerHtml.AppendHtml(li);
            }

            output.Content.AppendHtml(ul);
        }
    }
}
