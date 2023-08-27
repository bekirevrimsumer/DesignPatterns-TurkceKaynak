using VisitorPattern.Interfaces;
using VisitorPattern.Models;

namespace VisitorPattern.Visitor;

public class CompressionVisitor : IDocumentVisitor
{
    public void Visit(WordDocument doc)
    {
        Console.WriteLine("No compression for Word documents.");
    }

    public void Visit(PdfDocument doc)
    {
        doc.Compress();
    }
}