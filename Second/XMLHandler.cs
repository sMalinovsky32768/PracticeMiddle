using System.Xml;

namespace Second
{
    public class XMLHandler : AbstractHandler
    {
        public XmlDocument? Document { get; set; }

        public XMLHandler(string fileName) : base(fileName) { }

        public override void Create()
        {
            Document = new XmlDocument();
        }

        public override void Edit() => Open();

        public override void Open()
        {
            Document = new XmlDocument();
            if (Exists)
                Document.Load(FileName);
        }

        public override void Save()
        {
            Document?.Save(FileName);
        }
    }
}
