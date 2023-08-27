using VisitorPattern.Interfaces;

namespace VisitorPattern.Models;

public class PdfDocument : IDocument
{
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
    
    public void Compress()
    {
        Console.WriteLine("Compressing PDF document...");
    }
    
    public void Export()
    {
        Console.WriteLine("Exporting PDF document...");
    }
}