using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NetAcademy.UI.TagHelpers;

public class TimeTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Content.SetContent($"Actual time is: {DateTime.Now:T}");
    }
}

[HtmlTargetElement("date-tag")]
public class DateTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        
        output.TagName = "div";
        output.Content.SetContent($"Actual date is: {DateTime.Now:D}");
    }
}

public class SummaryTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        var childContent = await output.GetChildContentAsync();
        var content = $"<h3>Date and time summary:</h3> {childContent.GetContent()}";
        output.Content.SetHtmlContent(content);
    }
}