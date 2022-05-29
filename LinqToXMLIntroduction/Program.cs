using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXMLIntroduction
{
    public class Program
    {

        public static void Main(string[] args)
        {
            XDocument employeeTree = CreateXMLExample();
            employeeTree.Save("EmployeesFile.xml");

            XDocument loadXml = XDocument.Load("EmployeesFile.xml");
            Console.WriteLine(loadXml);

            var xmlInString = loadXml.ToString();

            XDocument parseXMLFromString = XDocument.Parse(xmlInString);
            Console.WriteLine(parseXMLFromString);

            Console.WriteLine();
            XElement root = parseXMLFromString.Root;
            foreach (var emp in root.Elements())
            {
                XElement empNameNode = emp.Element("Name");
                Console.WriteLine(empNameNode.Value);
                IEnumerable<XElement> phones = emp.Elements("PhoneNumber");
                foreach (var phone in phones)
                {
                    Console.WriteLine($" * {phone.Value}");
                }
            }

            // descendants
            Console.WriteLine();
            var empsQuery = from emp in parseXMLFromString.Descendants("Employee") select emp;
            foreach (var emp in empsQuery)
            {
                string empNames = emp.Element("Name").Value;
                IEnumerable<string> empPhoneList = emp.Elements("PhoneNumber").Select(x => x.Value);
                Console.WriteLine($"{ empNames } : {string.Join(", ", empPhoneList)}");
            }

            XElement osoba = new XElement("Employee",
                                    new XComment("Wykładowca WSEI"),
                                    new XElement("Name", "Krzysztof Molenda"),
                                    new XElement("PhoneNumber", "+48 111-111-111")
                                    );
            root.Add(osoba);
            Console.WriteLine(parseXMLFromString);

            Console.WriteLine();
            parseXMLFromString.Descendants("Employee").FirstOrDefault(x => x.Element("Name").Value == "Bob Smith").Remove();
            Console.WriteLine(parseXMLFromString);

            // Modify node
            XElement empToMod = parseXMLFromString.Descendants("Employee").FirstOrDefault(x => x.Element("Name").Value == "Sally Jones");
            empToMod.SetElementValue("Name", "Boby Smith");
            Console.WriteLine(parseXMLFromString);

            Console.WriteLine();
            var employeesWithAttributes = CreateXMLWithAttribute();
            Console.WriteLine(employeesWithAttributes);

            XElement empAttributeToMod = employeesWithAttributes.Root;

            Console.WriteLine();
            foreach (var emp in employeesWithAttributes.Descendants("Employee"))
            {
                var name = emp.Element("Name")?.Value;
                var id = emp.Attribute("EmpId")?.Value;
                Console.WriteLine($"{id}: {name}");
            }

            empAttributeToMod.Attribute("Gender")?.Remove();

            empAttributeToMod = employeesWithAttributes.Descendants("Employee").FirstOrDefault(x => x.Element("Name").Value == "Sally Jones");
            empAttributeToMod?.SetAttributeValue("EmpId", "102");
            Console.WriteLine(employeesWithAttributes);

            Console.WriteLine();
            foreach (var emp in employeesWithAttributes.Descendants("Employee"))
            {
                var name = emp.Element("Name")?.Value;
                var id = emp.Attribute("EmpId")?.Value;
                Console.WriteLine($"{id}: {name}");
            }

            Console.WriteLine("XML settings save");
            CreateAppSettings();

            //
            Console.WriteLine("XML settings load");
            var settings = XDocument.Load("settings.xml");
            var settingsIntoObject = settings
                .Descendants("AppSettings")
                .Descendants("add")
            .Select(x => new settings()
            {
                key = x.Attribute("key").Value,
                value = x.Attribute("value").Value

            });

            foreach(var setting in settingsIntoObject)
                Console.WriteLine(setting);
        }
        

        public static XDocument CreateXMLExample()
        {
            return new XDocument(
                        new XElement("Employees",
                            new XElement("Employee",
                                new XElement("Name", "Bob Smith"),
                                new XElement("PhoneNumber", "408-555-1000")
                                ),
                            new XElement("Employee",
                                new XElement("Name", "Sally Jones"),
                                new XElement("PhoneNumber", "415-555-2000"),
                                new XElement("PhoneNumber", "415-555-2001")
                                )
                            )
                        );
        }

        public static XDocument CreateXMLWithAttribute()
        {
            return new XDocument(
                        new XElement("Employees",
                            new XElement("Employee",
                                new XAttribute("EmpId", "101"),
                                new XAttribute("Gender", "M"),
                                new XElement("Name", "Bob Smith"),
                                new XElement("PhoneNumber", "408-555-1000")
                                ),
                            new XElement("Employee",
                                new XElement("Name", "Sally Jones"),
                                new XElement("PhoneNumber", "415-555-2000"),
                                new XElement("PhoneNumber", "415-555-2001")
                                )
                            )
                        );
        }

        public static void CreateAppSettings()
        {
            if (!File.Exists("settings.xml"))
            {
                var doc = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("AppSettings",
                        new XElement("add",
                            new XAttribute("key", "color"),
                            new XAttribute("value","red")),
                        new XElement("add",
                            new XAttribute("key", "size"),
                            new XAttribute("value", "large")),
                        new XElement("add",
                            new XAttribute("key", "price"),
                            new XAttribute("value", "23.99"))
                        )
                    );
                doc.Save("settings.xml");
            }
        }
    }
}
