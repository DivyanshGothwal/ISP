namespace InterfaceSegregationPrinciple
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            IPrinterBefore hpPrinterBefore = new HpBefore();
            hpPrinterBefore.fax(4);
            hpPrinterBefore.scan(5);

            IPrinterBefore epsonPrinterBefore = new EpsonBefore();
            epsonPrinterBefore.photoCopy(10);
            // this call will throw an exception as Epson dont have functionality of scan
            // epsonPrinterBefore.scan(5);

            IPrinterBefore canonPrinterBefore = new CanonBefore();
            canonPrinterBefore.photoCopy(10);
            canonPrinterBefore.scan(5);
            // this call will throw an exception as canon dont have functionality of fax
            // canonPrinterBefore.fax(9);



            HpAfter hpPrinterAfter = new HpAfter();
            hpPrinterAfter.fax(4);
            hpPrinterAfter.scan(5);

            EpsonAfter epsonPrinterAfter = new EpsonAfter();
            epsonPrinterAfter.photoCopy(10);
            epsonPrinterAfter.print(4);

            CanonAfter canonPrinterAfter = new CanonAfter();
            canonPrinterAfter.photoCopy(10);
            canonPrinterAfter.scan(5);
            canonPrinterAfter.print(20);

            Console.ReadKey();
        }
    }

    // this interface is overloaded with lot of functions which some cliets might not need
    // eg EpsonEco dont have functionality of scan and fax but has to implement these functions
    // which will throw not implemented exception and Canon have functionality of print, scan, photoCopy 
    // but dont have functionality of fax.
    // so IPrinter1 interface in following the principle of interface segregation principle which states that
    // No client should be fored to implement functionality which it is not using.
    // so we need to split this interface into smaller interfaces.
    public interface IPrinterBefore
    {
        void print(int pages);
        void photoCopy(int pages);
        void scan(int pages);
        void fax(int pages);
    }

    public class HpBefore : IPrinterBefore
    {
        public void print(int pages)
        {
            Console.WriteLine("Printing "+pages+ " pages");
        }

        public void photoCopy(int pages)
        {
            Console.WriteLine("PhotoCopying " + pages + " pages");
        }

        public void scan(int pages)
        {
            Console.WriteLine("Scanning " + pages + " pages");
        }

        public void fax(int pages)
        {
            Console.WriteLine("Faxing " + pages + " pages");
        }
    }

    public class EpsonBefore : IPrinterBefore
    {
        public void print(int pages)
        {
            Console.WriteLine("Printing " + pages + " pages");
        }

        public void photoCopy(int pages)
        {
            Console.WriteLine("PhotoCopying " + pages + " pages");
        }

        public void scan(int pages)
        {
            throw new NotImplementedException();
        }

        public void fax(int pages)
        {
            throw new NotImplementedException();
        }
    }
    public class CanonBefore : IPrinterBefore
    {
        public void print(int pages)
        {
            Console.WriteLine("Printing " + pages + " pages");
        }

        public void photoCopy(int pages)
        {
            Console.WriteLine("PhotoCopying " + pages + " pages");
        }

        public void scan(int pages)
        {
            Console.WriteLine("Scanning " + pages + " pages");
        }

        public void fax(int pages)
        {
            throw new NotImplementedException();
        }
    }


    // Now after segrigating our large interface into smaller interface ESPON printer class changes,
    // only those functionalities are there which this printer can implement. Similarly for canon also
    public interface IPrinterAfter
    {
        void print(int pages);
        void photoCopy(int pages);
    }

    public interface IScan
    {
        void scan(int pages);
    }

    public interface IFax
    {
        void fax(int pages);
    }

    public class HpAfter : IPrinterAfter, IScan, IFax
    {
        public void print(int pages)
        {
            Console.WriteLine("Printing " + pages + " pages");
        }

        public void photoCopy(int pages)
        {
            Console.WriteLine("PhotoCopying " + pages + " pages");
        }

        public void scan(int pages)
        {
            Console.WriteLine("Scanning " + pages + " pages");
        }

        public void fax(int pages)
        {
            Console.WriteLine("Faxing " + pages + " pages");
        }
    }

    public class EpsonAfter : IPrinterAfter
    {
        public void print(int pages)
        {
            Console.WriteLine("Printing " + pages + " pages");
        }

        public void photoCopy(int pages)
        {
            Console.WriteLine("PhotoCopying " + pages + " pages");
        }

    }
    public class CanonAfter : IPrinterAfter, IScan
    {
        public void print(int pages)
        {
            Console.WriteLine("Printing " + pages + " pages");
        }

        public void photoCopy(int pages)
        {
            Console.WriteLine("PhotoCopying " + pages + " pages");
        }

        public void scan(int pages)
        {
            Console.WriteLine("Scanning " + pages + " pages");
        }
    }
}
