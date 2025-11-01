using System;
using System.Xml.Schema;
using System.Xml;
namespace ConsoleApp1
{
    public class Program
    {
        
        public static string xmlURL = "https://blpeterson.github.io/Assignment-4/Assign4/Hotels.xml"; //Q1.2
        public static string xmlErrorURL = "https://blpeterson.github.io/Assignment-4/Assign4/HotelsErrors.xml"; //Q1.3
        public static string xsdURL = "https://blpeterson.github.io/Assignment-4/Assign4/Hotels.xsd"; //Q1.1

        public static void Main(string[] args)
        {
            // Q3: You can pick two of three
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);

            Console.WriteLine("EPICO MOVING ON TO THE ERRO DOC");


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);
            //result = Xml2Json(xmlURL);
            //Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            bool isValid = true;
            string errorMessage = "Error:";

            //Load XSD Schema
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(xmlUrl, xsdUrl);

            //Load the XML
            XmlDocument doc = new XmlDocument();
            doc.Schemas.Add(schemas);
            doc.Load(xmlUrl);

            //Validate the XML
            doc.Validate((o, error) =>
            {
                errorMessage += " " + error.Message;
                isValid = false;
            });

            if (isValid)
            {
                return "No Error";
            }
            else
            {
                return errorMessage;
            }



            //return "No Error" if XML is valid. Otherwise, return the desired exception message.
        }
        // Q2.2
        // public static string Xml2Json(string xmlUrl)
        // {


        //     // The returned jsonText needs to be de-serializable by Newtonsoft.Json package.
        //     (JsonConvert.DeserializeXmlNode(jsonText));
        //     return jsonText;
        // }
    }
}