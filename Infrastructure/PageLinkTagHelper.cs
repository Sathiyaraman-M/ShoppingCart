using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Infrastructure
{
    [HtmlTargetElement("ul", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
            TagBuilder tagBuilder = new TagBuilder("li");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder builder = new TagBuilder("a");
                PageUrlValues["productPage"] = i;
                builder.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                builder.Attributes["href"] = urlHelper.Action(PageAction, new { ProductPage = i });
                if(i == PageModel.CurrentPage)
                {
                    builder.AddCssClass("font-weight-bold");
                }
                builder.InnerHtml.Append(i.ToString());
                tagBuilder.InnerHtml.AppendHtml(builder);
            }
            output.Content.AppendHtml(tagBuilder.InnerHtml);
        }
    }
}