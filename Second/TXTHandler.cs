using System;
using System.IO;
using System.Threading.Tasks;

namespace Second
{
    public class TXTHandler : AbstractHandler, IDisposable, IAsyncDisposable
    {
        public FileStream? Document { get; private set; }

        public TXTHandler(string fileName) : base(fileName) { }

        public override void Create()
        {
            Document = new FileStream(FileName, FileMode.Create, FileAccess.Write);
        }

        public override void Edit()
        {
            Document = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
        }

        public override void Open()
        {
            Document = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public override void Save()
        {
            Document?.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Document?.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            return Document?.DisposeAsync() ?? new ValueTask();
        }
    }
}
