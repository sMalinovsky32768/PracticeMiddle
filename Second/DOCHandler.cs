using DocumentFormat.OpenXml.Packaging;

using System;

namespace Second
{
    public class DOCHandler : AbstractHandler, IDisposable
    {
        public WordprocessingDocument? Document { get; private set; }

        public DOCHandler(string fileName) : base(fileName) { }

        public override void Create()
        {
            Document = WordprocessingDocument.Create(FileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
        }

        public override void Edit() => Open();

        public override void Open()
        {
            if (Exists)
                Document = WordprocessingDocument.Open(FileName, false);
            else
                Create();
        }

        public override void Save()
        {
            Document?.Save();
            Document?.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Document?.Dispose();
        }
    }
}
