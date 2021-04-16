using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace Inventura.Generator
{
    public class SyntaxGeneratorHelper
    {
        private ServicesSyntaxGenerator _servicesSyntaxGenerator = new ServicesSyntaxGenerator();
        private PropertiesHelper _propertiesHelper = new PropertiesHelper();


        public string GenerateSyntaxNode(string model)
        {
            var node = CSharpSyntaxTree.ParseText(model).GetRoot();
            var classNode = node.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            _propertiesHelper.ExtractPropertiesAndAttrbitues(classNode.DescendantNodes().OfType<MemberDeclarationSyntax>());

            var serviceClassNode = _servicesSyntaxGenerator.GenerateServiceClassNode(classNode, _propertiesHelper.PropertiesWithAttributes );

            

            return serviceClassNode.ToFullString();
        }

        
    }
}
