﻿using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mailings.Web.API.TagHelpers;
[HtmlTargetElement(ElementTag, ParentTag = ListTagHelper.ElementTag)]
public sealed class ListElementTagHelper : TagHelper
{
    public const string ElementTag = "el";

    public override async Task ProcessAsync(
        TagHelperContext context,
        TagHelperOutput output)
    {
        await base.ProcessAsync(context, output);

        var elemClass = (string)context.Items[ListTagHelper.ParentKey];

        output.TagName = "li";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.AddClass(elemClass, HtmlEncoder.Default);
    }
}