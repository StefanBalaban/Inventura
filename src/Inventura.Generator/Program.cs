using System;
using System.IO;
using Inventura.Generator;

var code = new StreamReader("..\\..\\..\\..\\ApplicationCore\\Entities\\FoodProduct.cs").ReadToEnd();
var syntaxGeneratorHelper = new SyntaxGeneratorHelper();
var syntaxNode = syntaxGeneratorHelper.GenerateSyntaxNode(code);
Console.WriteLine(syntaxNode);



