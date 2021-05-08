using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Inventura.Generator.Generators
{
    public class PropertiesHelper
    {
        public List<KeyValuePair<string, string>> PropertiesWithAttributes = new List<KeyValuePair<string, string>>();
        public List<PropertiesWithInfo> PropertiesWithInfos { get; set; } = new List<PropertiesWithInfo>();
        public List<AttributesWithInfo> AttributesWithInfo { get; set; } = new List<AttributesWithInfo>();

        public void ExtractPropertiesAndAttrbitues(IEnumerable<MemberDeclarationSyntax> members)
        {
            foreach (var memberDeclarationSyntax in members)
            {
                var attributeName = new List<string>();
                var property = memberDeclarationSyntax as PropertyDeclarationSyntax;
                if (property != null)
                {
                    var attributes = property.AttributeLists.ToList();
                    foreach (var attributeListSyntax in attributes)
                    {
                        var attribute = attributeListSyntax.Attributes.FirstOrDefault();
                        if (attribute != null)
                        {
                            attributeName.Add(attribute.Name.NormalizeWhitespace().ToFullString());
                            if (attribute.Name.NormalizeWhitespace().ToFullString()
                                .Equals("Get"))
                            {
                                var arguments = attribute.ArgumentList?.Arguments;
                                if (arguments.HasValue)
                                    AttributesWithInfo.Add(new AttributesWithInfo
                                    {
                                        PropertyIdentifier = property.Identifier.Text,
                                        Arguments = AddArguments(arguments.Value.ToList()),
                                        Type = property.Type.NormalizeWhitespace().ToFullString()
                                    });
                            }
                            if (attribute.Name.NormalizeWhitespace().ToFullString()
                                .Equals("Post"))
                            {
                                    PropertiesWithInfos.Add(new PropertiesWithInfo()
                                    {
                                        Identifier = property.Identifier.Text,
                                        Type = property.Type.NormalizeWhitespace().ToFullString()
                                    });
                            }
                        }
                    }

                    if (attributeName != null)
                        attributeName.ForEach(x =>
                            PropertiesWithAttributes.Add(
                                new KeyValuePair<string, string>(property.Identifier.Text, x)));
                }
            }
        }

        private List<string> AddArguments(List<AttributeArgumentSyntax> arguments)
        {
            var argumentList = new List<string>();
            foreach (var argument in arguments)
                argumentList.Add(argument.NormalizeWhitespace().ToFullString());

            return argumentList;
        }
    }
}