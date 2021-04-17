using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Inventura.Generator.Generators
{
    public class SyntaxGeneratorHelper
    {
        private readonly InterfaceSyntaxGenerator _interfaceSyntayGenerator = new InterfaceSyntaxGenerator();
        private readonly PropertiesHelper _propertiesHelper = new PropertiesHelper();
        private readonly ServicesSyntaxGenerator _servicesSyntaxGenerator = new ServicesSyntaxGenerator();

        private readonly SpecificationsSyntaxGenerator _specificationsSyntaxGenerator =
            new SpecificationsSyntaxGenerator();

        private string _modelClassName;


        public string GenerateSyntaxNode(string model)
        {
            var node = CSharpSyntaxTree.ParseText(model).GetRoot();
            var classNode = node.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
            _modelClassName = classNode.Identifier.Text;
            _propertiesHelper.ExtractPropertiesAndAttrbitues(classNode.DescendantNodes()
                .OfType<MemberDeclarationSyntax>());

            var interfaceNode = _interfaceSyntayGenerator.GenerateInterfaceNode(_modelClassName);
            var serviceClassNode =
                _servicesSyntaxGenerator.GenerateServiceClassNode(_modelClassName,
                    _propertiesHelper.PropertiesWithAttributes);
            var specificationsNode =
                _specificationsSyntaxGenerator.GenerateSpecificationsNode(_modelClassName,
                    _propertiesHelper.AttributesWithInfo);

            var code = new StringBuilder();
            code.AppendLine($"// ApplicationCore\\Interfaces\\I{_modelClassName}Service.cs");
            code.AppendLine(interfaceNode.ToFullString());
            code.AppendLine($"// ApplicationCore\\Services\\{_modelClassName}Service.cs");
            code.AppendLine(serviceClassNode.ToFullString());
            code.AppendLine(specificationsNode.ToFullString());
            //specificationsNode.ToList().ForEach(x => code.AppendLine(x.ToFullString()));

            return code.ToString();
        }
    }
}