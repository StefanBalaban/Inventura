using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Inventura.Generator.Generators
{
    internal class EndpointSyntaxGenerator
    {
        private readonly ArgumentFilterConstantsHelpers _argumentFilterConstantsHelpers =
            new ArgumentFilterConstantsHelpers();

        private List<PropertiesWithInfo> _propertiesWithInfo;
        private string _modelClassName;
        private List<KeyValuePair<string, string>> _propertiesWithAttributes;
        private string _serviceInstanceName;
        private string _serviceInterfaceName;
        private string _serviceParameterName;

        public SyntaxNode GenerateEndpointsNode(string modelClassName,
            List<KeyValuePair<string, string>> propertiesWithAttributes,
            List<PropertiesWithInfo> propertiesWithInfo)
        {
            _modelClassName = modelClassName;
            _serviceInterfaceName = $"I{modelClassName}Repository";
            _serviceInstanceName = $"_{modelClassName.ToCamelCase()}Repository";
            _serviceParameterName = $"{modelClassName.ToCamelCase()}Repository";
            _propertiesWithAttributes = propertiesWithAttributes;
            _propertiesWithInfo = propertiesWithInfo;

            return GenerateEndpointsNode();
        }

        private SyntaxNode GenerateEndpointsNode()
        {
            return
                CompilationUnit()
                    .WithMembers(SingletonList(GenerateMembers())).NormalizeWhitespace();
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateDto()
        {
            return new List<MemberDeclarationSyntax>
            {
                ClassDeclaration($"{_modelClassName}Dto")
                                .WithModifiers(
                                    TokenList(
                                        Token(SyntaxKind.PublicKeyword)))
                                .WithMembers(GenerateClassMembers("Dto"))
            };
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateUpdate()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateListPaged()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateGetById()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateDelete()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<MemberDeclarationSyntax> GenerateCreate()
        {
            return new List<MemberDeclarationSyntax>
            {
                ClassDeclaration("Create")
                    .WithAttributeLists(
                        SingletonList(
                            AttributeList(
                                SingletonSeparatedList(
                                    Attribute(
                                            IdentifierName("Authorize"))
                                        .WithArgumentList(
                                            AttributeArgumentList(
                                                SeparatedList<AttributeArgumentSyntax>(
                                                    new SyntaxNodeOrToken[]
                                                    {
                                                        AttributeArgument(
                                                                LiteralExpression(
                                                                    SyntaxKind.StringLiteralExpression,
                                                                    Literal("Administrators")))
                                                            .WithNameEquals(
                                                                NameEquals(
                                                                    IdentifierName("Roles"))),
                                                        Token(SyntaxKind.CommaToken),
                                                        AttributeArgument(
                                                                MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    IdentifierName("JwtBearerDefaults"),
                                                                    IdentifierName("AuthenticationScheme")))
                                                            .WithNameEquals(
                                                                NameEquals(
                                                                    IdentifierName("AuthenticationSchemes")))
                                                    })))))))
                    .WithModifiers(
                        TokenList(
                            Token(SyntaxKind.PublicKeyword)))
                    .WithBaseList(
                        BaseList(
                            SingletonSeparatedList<BaseTypeSyntax>(
                                SimpleBaseType(
                                    QualifiedName(
                                        QualifiedName(
                                            IdentifierName("BaseAsyncEndpoint"),
                                            GenericName(
                                                    Identifier("WithRequest"))
                                                .WithTypeArgumentList(
                                                    TypeArgumentList(
                                                        SingletonSeparatedList<TypeSyntax>(
                                                            IdentifierName($"Create{_modelClassName}Request"))))),
                                        GenericName(
                                                Identifier("WithResponse"))
                                            .WithTypeArgumentList(
                                                TypeArgumentList(
                                                    SingletonSeparatedList<TypeSyntax>(
                                                        IdentifierName($"Create{_modelClassName}Response")))))))))
                    .WithMembers(
                        List(
                            new MemberDeclarationSyntax[]
                            {
                                FieldDeclaration(
                                        VariableDeclaration(
                                                IdentifierName(_serviceInterfaceName))
                                            .WithVariables(
                                                SingletonSeparatedList(
                                                    VariableDeclarator(
                                                        Identifier(_serviceInstanceName)))))
                                    .WithModifiers(
                                        TokenList(Token(SyntaxKind.PrivateKeyword), Token(SyntaxKind.ReadOnlyKeyword))),
                                FieldDeclaration(
                                        VariableDeclaration(
                                                IdentifierName("IMapper"))
                                            .WithVariables(
                                                SingletonSeparatedList(
                                                    VariableDeclarator(
                                                        Identifier("_mapper")))))
                                    .WithModifiers(
                                        TokenList(Token(SyntaxKind.PrivateKeyword), Token(SyntaxKind.ReadOnlyKeyword))),
                                ConstructorDeclaration(
                                        Identifier("Create"))
                                    .WithModifiers(
                                        TokenList(
                                            Token(SyntaxKind.PublicKeyword)))
                                    .WithParameterList(
                                        ParameterList(
                                            SeparatedList<ParameterSyntax>(
                                                new SyntaxNodeOrToken[]
                                                {
                                                    Parameter(
                                                            Identifier(_serviceParameterName))
                                                        .WithType(
                                                            IdentifierName(_serviceInterfaceName)),
                                                    Token(SyntaxKind.CommaToken),
                                                    Parameter(
                                                            Identifier("mapper"))
                                                        .WithType(
                                                            IdentifierName("IMapper"))
                                                })))
                                    .WithBody(
                                        Block(
                                            ExpressionStatement(
                                                AssignmentExpression(
                                                    SyntaxKind.SimpleAssignmentExpression,
                                                    IdentifierName(_serviceInstanceName),
                                                    IdentifierName(_serviceParameterName))),
                                            ExpressionStatement(
                                                AssignmentExpression(
                                                    SyntaxKind.SimpleAssignmentExpression,
                                                    IdentifierName("_mapper"),
                                                    IdentifierName("mapper"))))),
                                MethodDeclaration(
                                        GenericName(
                                                Identifier("Task"))
                                            .WithTypeArgumentList(
                                                TypeArgumentList(
                                                    SingletonSeparatedList<TypeSyntax>(
                                                        GenericName(
                                                                Identifier("ActionResult"))
                                                            .WithTypeArgumentList(
                                                                TypeArgumentList(
                                                                    SingletonSeparatedList<TypeSyntax>(
                                                                        IdentifierName(
                                                                            $"{_modelClassName}ProductResponse"))))))),
                                        Identifier("HandleAsync"))
                                    .WithAttributeLists(
                                        List(
                                            new[]
                                            {
                                                AttributeList(
                                                    SingletonSeparatedList(
                                                        Attribute(
                                                                IdentifierName("HttpPost"))
                                                            .WithArgumentList(
                                                                AttributeArgumentList(
                                                                    SingletonSeparatedList(
                                                                        AttributeArgument(
                                                                            LiteralExpression(
                                                                                SyntaxKind.StringLiteralExpression,
                                                                                Literal(
                                                                                    $"api/{_modelClassName.ToLower()}")))))))),
                                                AttributeList(
                                                    SingletonSeparatedList(
                                                        Attribute(
                                                                IdentifierName("SwaggerOperation"))
                                                            .WithArgumentList(
                                                                AttributeArgumentList(
                                                                    SeparatedList<AttributeArgumentSyntax>(
                                                                        new SyntaxNodeOrToken[]
                                                                        {
                                                                            AttributeArgument(
                                                                                    LiteralExpression(
                                                                                        SyntaxKind
                                                                                            .StringLiteralExpression,
                                                                                        Literal(
                                                                                            $"Creates a new {_modelClassName}")))
                                                                                .WithNameEquals(
                                                                                    NameEquals(
                                                                                        IdentifierName("Summary"))),
                                                                            Token(SyntaxKind.CommaToken),
                                                                            AttributeArgument(
                                                                                    LiteralExpression(
                                                                                        SyntaxKind
                                                                                            .StringLiteralExpression,
                                                                                        Literal(
                                                                                            $"Creates a new {_modelClassName}")))
                                                                                .WithNameEquals(
                                                                                    NameEquals(
                                                                                        IdentifierName("Description"))),
                                                                            Token(SyntaxKind.CommaToken),
                                                                            AttributeArgument(
                                                                                    LiteralExpression(
                                                                                        SyntaxKind
                                                                                            .StringLiteralExpression,
                                                                                        Literal(
                                                                                            $"{_modelClassName.ToLower()}.create")))
                                                                                .WithNameEquals(
                                                                                    NameEquals(
                                                                                        IdentifierName("OperationId"))),
                                                                            Token(SyntaxKind.CommaToken),
                                                                            AttributeArgument(
                                                                                    ImplicitArrayCreationExpression(
                                                                                        InitializerExpression(
                                                                                            SyntaxKind
                                                                                                .ArrayInitializerExpression,
                                                                                            SingletonSeparatedList<
                                                                                                ExpressionSyntax>(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind
                                                                                                        .StringLiteralExpression,
                                                                                                    Literal(
                                                                                                        $"{_modelClassName}Endpoints"))))))
                                                                                .WithNameEquals(
                                                                                    NameEquals(
                                                                                        IdentifierName("Tags")))
                                                                        })))))
                                            }))
                                    .WithModifiers(
                                        TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.OverrideKeyword),
                                            Token(SyntaxKind.AsyncKeyword)))
                                    .WithParameterList(
                                        ParameterList(
                                            SeparatedList<ParameterSyntax>(
                                                new SyntaxNodeOrToken[]
                                                {
                                                    Parameter(
                                                            Identifier("request"))
                                                        .WithType(
                                                            IdentifierName($"Create{_modelClassName}Request")),
                                                    Token(SyntaxKind.CommaToken),
                                                    Parameter(
                                                            Identifier("cancellationToken"))
                                                        .WithType(
                                                            IdentifierName("CancellationToken"))
                                                })))
                                    .WithBody(
                                        Block(
                                            LocalDeclarationStatement(
                                                VariableDeclaration(
                                                        IdentifierName(
                                                            Identifier(
                                                                TriviaList(),
                                                                SyntaxKind.VarKeyword,
                                                                "var",
                                                                "var",
                                                                TriviaList())))
                                                    .WithVariables(
                                                        SingletonSeparatedList(
                                                            VariableDeclarator(
                                                                    Identifier("response"))
                                                                .WithInitializer(
                                                                    EqualsValueClause(
                                                                        ObjectCreationExpression(
                                                                                IdentifierName(
                                                                                    $"Create{_modelClassName}Response"))
                                                                            .WithArgumentList(
                                                                                ArgumentList(
                                                                                    SingletonSeparatedList(
                                                                                        Argument(
                                                                                            InvocationExpression(
                                                                                                MemberAccessExpression(
                                                                                                    SyntaxKind
                                                                                                        .SimpleMemberAccessExpression,
                                                                                                    IdentifierName(
                                                                                                        "request"),
                                                                                                    IdentifierName(
                                                                                                        "CorrelationId")))))))))))),
                                            LocalDeclarationStatement(
                                                VariableDeclaration(
                                                        IdentifierName(
                                                            Identifier(
                                                                TriviaList(),
                                                                SyntaxKind.VarKeyword,
                                                                "var",
                                                                "var",
                                                                TriviaList())))
                                                    .WithVariables(
                                                        SingletonSeparatedList(
                                                            VariableDeclarator(
                                                                    Identifier($"new{_modelClassName}"))
                                                                .WithInitializer(
                                                                    EqualsValueClause(
                                                                        AwaitExpression(
                                                                            InvocationExpression(
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind
                                                                                            .SimpleMemberAccessExpression,
                                                                                        IdentifierName(
                                                                                            _serviceInstanceName),
                                                                                        IdentifierName("PostAsync")))
                                                                                .WithArgumentList(
                                                                                    ArgumentList(
                                                                                        SingletonSeparatedList(
                                                                                            Argument(
                                                                                                ObjectCreationExpression(
                                                                                                        IdentifierName(
                                                                                                            "FoodProduct"))
                                                                                                    .WithInitializer(
                                                                                                        InitializerExpression(
                                                                                                            SyntaxKind
                                                                                                                .ObjectInitializerExpression,
                                                                                                            SeparatedList(
                                                                                                                GenerateCreateObjectInitialization()
                                                                                                            ))))))))))))),
                                            ExpressionStatement(
                                                AssignmentExpression(
                                                    SyntaxKind.SimpleAssignmentExpression,
                                                    MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        IdentifierName("response"),
                                                        IdentifierName(_modelClassName)),
                                                    InvocationExpression(
                                                            MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                IdentifierName("_mapper"),
                                                                GenericName(
                                                                        Identifier("Map"))
                                                                    .WithTypeArgumentList(
                                                                        TypeArgumentList(
                                                                            SingletonSeparatedList<TypeSyntax>(
                                                                                IdentifierName($"{_modelClassName}Dto"))))))
                                                        .WithArgumentList(
                                                            ArgumentList(
                                                                SingletonSeparatedList(
                                                                    Argument(
                                                                        IdentifierName($"new{_modelClassName}"))))))),
                                            ReturnStatement(
                                                IdentifierName("response"))))
                            })),
                ClassDeclaration($"Create{_modelClassName}Request")
                                .WithModifiers(
                                    TokenList(
                                        Token(SyntaxKind.PublicKeyword)))
                                .WithBaseList(
                                    BaseList(
                                        SingletonSeparatedList<BaseTypeSyntax>(
                                            SimpleBaseType(
                                                IdentifierName("BaseRequest")))))
                                .WithMembers(GenerateClassMembers("Post"))
            };
        }

        private SyntaxList<MemberDeclarationSyntax> GenerateClassMembers(string method)
        {
            var list = new List<MemberDeclarationSyntax>();
            _propertiesWithInfo.Where(x => x.Method.Equals(method)).ToList().ForEach(x => list.Add(
                PropertyDeclaration(
                        IdentifierName(x.Type),
                        Identifier(x.Identifier))
                    .WithModifiers(
                        TokenList(
                            Token(SyntaxKind.PublicKeyword)))
                    .WithAccessorList(
                        AccessorList(
                            List<AccessorDeclarationSyntax>(
                                new AccessorDeclarationSyntax[]{
                                    AccessorDeclaration(
                                            SyntaxKind.GetAccessorDeclaration)
                                        .WithSemicolonToken(
                                            Token(SyntaxKind.SemicolonToken)),
                                    AccessorDeclaration(
                                            SyntaxKind.SetAccessorDeclaration)
                                        .WithSemicolonToken(
                                            Token(SyntaxKind.SemicolonToken))})))));
            return List<MemberDeclarationSyntax>(list);
        }

        private IEnumerable<ExpressionSyntax> GenerateCreateObjectInitialization()
        {
            var properties = _propertiesWithAttributes.Where(x => x.Value == "Post").Select(x => x.Key).ToList();
            var list = new List<SyntaxNodeOrToken>();
            properties.ForEach(x =>
                {
                    list.Add(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            IdentifierName(x),
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                IdentifierName("t"),
                                IdentifierName(x))));
                    list.Add(
                        Token(SyntaxKind.CommaToken));
                }
            );
            // Remove last comma
            list.RemoveAt(list.Count - 1);
            var initializerExpression = SeparatedList<ExpressionSyntax>(list);
            return initializerExpression;
        }

        private List<MemberDeclarationSyntax> GetMembers()
        {
            var list = new List<MemberDeclarationSyntax>();
            list.AddRange(
                GenerateCreate());
            //list.AddRange(
            //    GenerateDelete());
            //list.AddRange(
            //    GenerateGetById());
            //list.AddRange(
            //    GenerateListPaged());
            //list.AddRange(
            //    GenerateUpdate());
            list.AddRange(
               GenerateDto());
            return list;
        }

        private MemberDeclarationSyntax GenerateMembers()
        {
            return NamespaceDeclaration(
                QualifiedName(
                    QualifiedName(
                        IdentifierName("PublicApi"),
                        IdentifierName("Endpoints")),
                    IdentifierName($"{_modelClassName}Endpoints"))).WithMembers(List(
                GetMembers()
            ));
        }
    }
}