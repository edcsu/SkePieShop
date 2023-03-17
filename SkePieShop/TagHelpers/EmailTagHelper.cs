using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SkePieShop.TagHelpers;

public class EmailTagHelper: TagHelper
{
    public string Address { get; set; } = default!;
    public string Content { get; set; } = default!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";

        output.Attributes.SetAttribute("href", "mailto:" + Address);
        output.Content.SetContent(Content);
    }
}