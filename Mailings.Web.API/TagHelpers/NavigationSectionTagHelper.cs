﻿using Mailings.Web.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mailings.Web.API.TagHelpers;

[HtmlTargetElement(ElementTag, Attributes = "action, controller")]
public sealed class NavigationSectionTagHelper : TagHelper
{
    public const string ElementTag = "navsec";
    public const string ElementClass = "navigation-section";

    private readonly IUrlHelperFactory _urlHelperFactory;

    [ViewContext]
    public ViewContext ViewContext { get; set; } = null!;

    public string Action { get; set; } = null!;
    public string Controller { get; set; } = null!;
    public object? Data { get; set; } = null;

    public NavigationSectionTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override async Task ProcessAsync(
        TagHelperContext context,
        TagHelperOutput output)
    {
        await base.ProcessAsync(context, output);

        var urlHelper = _urlHelperFactory.GetUrlHelper(new ActionContext(
            actionDescriptor:ViewContext.ActionDescriptor,
            httpContext: ViewContext.HttpContext,
            routeData: ViewContext.RouteData,
            modelState: ViewContext.ModelState));

        var url = urlHelper.Action(Action, Controller, Data) ?? 
                  throw new UrlIsNotGeneratedException();

        output.TagName = "a";
        output.TagMode = TagMode.StartTagAndEndTag;
        output.Attributes.Add("class", ElementClass);
        output.Attributes.Add("href", url);
    }
}