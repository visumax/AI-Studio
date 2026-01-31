namespace AI_Studio
{
    [Command(PackageIds.AddSummary)]
    internal sealed class AddSummary : AIBaseCommand<AddSummary>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            SystemMessage = "Refactor the code adding summary. Write only the code, not the explanation.\r\n" +
                "When writing XML documentation comments for C# code, follow these rules:\r\n" +
                "Structure: \r\n" +
                "- Place comments directly above the code element using ///\r\n" +
                "- Start with <summary> - a brief description of what the code does\r\n" +
                "- Use <param name=\"paramName\"> for each parameter\r\n" +
                "- Use <returns> to describe the return value\r\n" +
                "- Use <exception cref=\"ExceptionType\"> to document thrown exceptions\r\n" +
                "Key Tags: \r\n" +
                "- <c> - inline code reference: <c>variableName</c>\r\n" +
                "- <code> - multi-line code examples in a block\r\n" +
                "- <see cref=\"Type\"/> - link to other types or members\r\n" +
                "- <seealso cref=\"Type\"/> - related documentation references\r\n" +
                "- <example> - wrap code examples to show usage\r\n" +
                "- <remarks> - additional details beyond the summary\r\n" +
                "Example: \r\n" +
                "/// <summary>\r\n" +
                "/// Calculates the total price including tax.\r\n" +
                "/// </summary>\r\n" +
                "/// <param name=\"basePrice\">The price before tax</param>\r\n" +
                "/// <param name=\"taxRate\">Tax rate as a decimal (e.g., 0.08 for 8%)</param>\r\n" +
                "/// <returns>The final price with tax applied</returns>\r\n" +
                "/// <exception cref=\"ArgumentException\">Thrown when <paramref name=\"taxRate\"/> is negative</exception>\r\n" +
                "/// <example>\r\n" +
                "/// <code>\r\n" +
                "/// decimal total = CalculateTotal(100m, 0.08m); // Returns 108\r\n" +
                "/// </code>\r\n" +
                "/// </example>\r\n" +
                "public decimal CalculateTotal(decimal basePrice, decimal taxRate)\r\n" +
                "{\r\n" +
                "    if (taxRate < 0) throw new ArgumentException(\"Tax rate cannot be negative\", nameof(taxRate));\r\n" +
                "    return basePrice * (1 + taxRate);\r\n" +
                "}\r\n" +
                "Best Practices: \r\n" +
                "- Keep summaries concise but complete\r\n" +
                "- Document all public members\r\n" +
                "- Use <paramref> and <typeparamref> when referencing parameters in descriptions\r\n" +
                "- Enable XML documentation file generation in project settings\r\n";
            //"According to the this Url https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags, refactor the code adding summary. Write only the code, not the explanation.";
            ResponseBehavior = ResponseBehavior.Replace;

            var opts = await Commands.GetLiveInstanceAsync();

            UserInput = opts.AddSummary;
            _stripResponseMarkdownCode = true;
            _addContentTypePrefix = true;

            await base.ExecuteAsync(e);
        }
    }
}
