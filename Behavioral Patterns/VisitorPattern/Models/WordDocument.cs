using VisitorPattern.Interfaces;

namespace VisitorPattern.Models;

public class WordDocument : IDocument
{
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
    
    public void ConvertToPdf()
    {
        Console.WriteLine("Converting Word document to PDF...");
        Export();
    }
    
    private void Export()
    {
        Console.WriteLine("Exporting Word document...");
    }
}