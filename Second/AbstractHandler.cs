using System.IO;
using System.Linq;

namespace Second
{
    public abstract class AbstractHandler
    {
        protected string FileName { get; init; }
        public bool Exists => File.Exists(FileName);

        protected AbstractHandler(string fileName)
        {
            FileName = fileName;
        }

        public abstract void Open();
        public abstract void Create();
        public abstract void Edit();
        public abstract void Save();

        public static AbstractHandler CreateInstance(string fileName) => fileName.Split('.').LastOrDefault() switch
        {
            "doc" or "docx" => new DOCHandler(fileName),
            "xml" => new XMLHandler(fileName),
            _ => new TXTHandler(fileName),
        };
    }
}
