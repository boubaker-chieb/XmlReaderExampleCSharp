using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp3
{
    class Program
    {
        public class Rate
        {
            public string Category { get; set; }
            public DateTime DateTime { get; set; }
            public decimal Value { get; set; }
        }
        static void Main(string[] args)
        {
            foreach (var item in ReadRates("C:/Users/BE/Source/Repos/scharpCertification/ConsoleApp3/rateXml.xml"))
            {
                Console.WriteLine("rate Category : {0}, rate Date : {1}, rate value : {2}", item.Category, item.DateTime, item.Value);
                Console.WriteLine("*****************************************");
            }
            Console.ReadKey();
        }
        private static Collection<Rate>  ReadRates(string ratesXml)
        {
            Collection<Rate> rateCollection = new Collection<Rate>();
            try
            {
                using (XmlReader reader = XmlReader.Create(new StreamReader(ratesXml)))
                {
                    while (reader.ReadToFollowing("rate"))
                    {
                        Rate rate = new Rate();
                        reader.MoveToFirstAttribute();
                        rate.Category = reader.Value;
                        reader.MoveToNextAttribute();
                        DateTime rateDate;
                        if (DateTime.TryParse(reader.Value, out rateDate))
                        {
                            rate.DateTime = rateDate;
                        }
                        reader.ReadToFollowing("value");
                        decimal rateValue;
                        if (Decimal.TryParse(reader.ReadElementContentAsString(), out rateValue))
                        {
                            rate.Value = rateValue;
                        }
                        rateCollection.Add(rate);
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return rateCollection;
        }
    }
}
