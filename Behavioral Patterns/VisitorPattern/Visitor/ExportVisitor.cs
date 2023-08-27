using VisitorPattern.Interfaces;
using VisitorPattern.Models;

namespace VisitorPattern.Visitor;

public class ExportVisitor : IDocumentVisitor
{
    public void Visit(WordDocument doc)
    {
        doc.ConvertToPdf();
    }

    public void Visit(PdfDocument doc)
    {
        doc.Export();
    }
}