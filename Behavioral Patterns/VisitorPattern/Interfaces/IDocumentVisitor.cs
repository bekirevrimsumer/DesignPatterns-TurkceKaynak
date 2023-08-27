using VisitorPattern.Models;

namespace VisitorPattern.Interfaces;

public interface IDocumentVisitor
{
    void Visit(WordDocument doc);
    void Visit(PdfDocument doc);
}