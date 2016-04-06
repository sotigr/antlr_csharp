using System; 
using Antlr4.Runtime; 
using Antlr4.Runtime.Tree;
using System.IO;  
using MyProject.Folder;

namespace antlr_csharp
{
    class Program
    {
        static void Main(string[] args)
        { 
            StreamReader inputStream = new StreamReader(Console.OpenStandardInput());
            AntlrInputStream input = new AntlrInputStream(inputStream.ReadToEnd());
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.prog();
            Console.WriteLine(tree.ToStringTree(parser));
            CalculatorVisitor visitor = new CalculatorVisitor();
            Console.WriteLine(visitor.Visit(tree));
            Console.ReadLine();
        }
    }
}
