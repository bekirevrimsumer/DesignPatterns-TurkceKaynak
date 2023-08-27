using VisitorPattern;
using VisitorPattern.Models;
using VisitorPattern.Visitor;

var documentProcessor = new DocumentProcessor();
documentProcessor.AddDocument(new WordDocument());
documentProcessor.AddDocument(new PdfDocument());

var exportVisitor = new ExportVisitor();
var compressionVisitor = new CompressionVisitor();

Console.WriteLine("Exporting documents:");
documentProcessor.Process(exportVisitor);

Console.WriteLine("\nCompressing documents:");
documentProcessor.Process(compressionVisitor);