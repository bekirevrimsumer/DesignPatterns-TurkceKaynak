namespace VisitorPattern.Interfaces;

public interface IDocument
{
    void Accept(IDocumentVisitor visitor);
}