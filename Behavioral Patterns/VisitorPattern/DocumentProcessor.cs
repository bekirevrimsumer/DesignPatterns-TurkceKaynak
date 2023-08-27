using VisitorPattern.Interfaces;

namespace VisitorPattern;

public class DocumentProcessor
{
    private List<IDocument> _documents = new();
    
    public void AddDocument(IDocument document)
    {
        _documents.Add(document);
    }
    
    public void Process(IDocumentVisitor visitor)
    {
        foreach (var document in _documents)
        {
            document.Accept(visitor);
        }
    }
}