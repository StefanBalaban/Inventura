using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Inventura.Generator
{
    public class PropertiesHelper
    {

        public List<KeyValuePair<string, string>> PropertiesWithAttributes = new List<KeyValuePair<string, string>>();
        public List<KeyValuePair<string, string>> AttributesWithArguments = new List<KeyValuePair<string, string>>();
        public void ExtractPropertiesAndAttrbitues(IEnumerable<MemberDeclarationSyntax> members)
        {


            foreach (var memberDeclarationSyntax in members)
            {
                var attributeName = new List<string>();
                var attributeArgument = new List<string>();
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
                                    foreach (var argument in arguments.Value.ToList())
                                    {
                                        AttributesWithArguments.Add(
                                            new KeyValuePair<string, string>(
                                                property.Identifier.Text,
                                                argument.NormalizeWhitespace().ToFullString())
                                        );
                                    }
                            }
                        }
                    }

                    if (attributeName != null)
                        attributeName.ForEach(x => PropertiesWithAttributes.Add(new KeyValuePair<string, string>(property.Identifier.Text, x)));
                }

            }
        }
    }
}
