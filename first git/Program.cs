using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace prac5
{
    public interface IDocumnet
    {
        void Open();
    }

    public abstract class DocumentCreator
    {
        public abstract IDocumnet CreateDocument();
    }

    public class Report : IDocumnet
    {
        public void Open()
        {
            Console.WriteLine("Report opened");
        }
    }

    public class ReportCreator : DocumentCreator
    {
        public override IDocumnet CreateDocument()
        {
            return new Report();
        }
    }

    public class Resume : IDocumnet
    {
        public void Open()
        {
            Console.WriteLine("Resume opened");
        }
    }

    public class ResumeCreator : DocumentCreator
    {
        public override IDocumnet CreateDocument()
        {
            return new Resume();
        }
    }

    public class Letter : IDocumnet
    {
        public void Open()
        {
            Console.WriteLine("Letter opened");
        }
    }

    public class LetterCreator : DocumentCreator
    {
        public override IDocumnet CreateDocument()
        {
            return new Letter();
        }
    }

    public class Invoice : IDocumnet
    {
        public void Open()
        {
            Console.WriteLine("Invoice opened");
        }
    }

    public class InvoiceCreator : DocumentCreator
    {
        public override IDocumnet CreateDocument()
        {
            return new Invoice();
        }
    }

    public enum DocType
    {
        Report, Resume, Letter, Invoice
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GetDocument(DocType.Report).Open();
            GetDocument(DocType.Invoice).Open();
        }

        public static IDocumnet GetDocument(DocType docType)
        {
            DocumentCreator creator = null;
            switch (docType)
            {
                case DocType.Report:
                    creator = new ReportCreator();
                    break;
                case DocType.Resume:
                    creator = new ResumeCreator();
                    break;
                case DocType.Letter:
                    creator = new LetterCreator();
                    break;
                case DocType.Invoice:
                    creator = new InvoiceCreator();
                    break;
                default:
                    throw new Exception("Invalid document type");
            }
            return creator.CreateDocument();
        }
    }
}
