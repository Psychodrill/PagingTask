using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using PagingTask.Models.ViewModels;

namespace PagingTask.Infrastructure
{
    [HtmlTargetElement("div", Attributes="page-model")]
    public class PageLinkTagHelper : TagHelper 
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            TagBuilder tagFirst = new TagBuilder("a");
            tagFirst.Attributes["href"] = urlHelper.Action(PageAction, new { pageNumber = 1 });
            tagFirst.InnerHtml.Append("<<");
            result.InnerHtml.AppendHtml(tagFirst);
            for (int i=PageModel.StartPageNumber; i<=PageModel.EndPageNumber; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNumber = i });
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);

            }

            TagBuilder tagLast = new TagBuilder("a");
            tagLast.Attributes["href"] = urlHelper.Action(PageAction, new { pageNumber = PageModel.TotalPages });
            tagLast.InnerHtml.Append(">>");
            result.InnerHtml.AppendHtml(tagLast);

            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}
