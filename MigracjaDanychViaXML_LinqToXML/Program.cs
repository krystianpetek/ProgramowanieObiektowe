using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MigracjaDanychViaXML_LinqToXML
{
    public class Program
    {
        static void Main()
        {
            XDocument documentIssue = XDocument.Load("../../../issues.xml");
            XElement issueCurrent = documentIssue.Element("issues").Element("issue");
            XElement volume = issueCurrent.Element("volume");
            XElement number = issueCurrent.Element("number");
            XElement year = issueCurrent.Element("year");

            var articles = issueCurrent.Element("section").Elements("article");

            XDocument output;
            XNamespace xmlns = "http://pkp.sfu.ca";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            foreach (var article in articles)
            {
                output = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("article",
                        new XAttribute(XNamespace.Xmlns + "ns", "http://pkp.sfu.ca"),
                        new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                        new XAttribute(xsi + "schemaLocation", "http://pkp.sfu.ca native.xsd"),
                        new XAttribute("locale", article.Attribute("locale").Value),
                        new XAttribute("date_submitted", article.Element("date_published").Value),
                        new XAttribute("stage", "production"),
                        new XAttribute("date_published", article.Parent.Parent.Element("date_published").Value),
                        new XAttribute("section_ref", article.Parent.Element("abbrev").Value),
                        new XAttribute("seq", "1"),
                        new XAttribute("access_status", "0"),

                        new XElement("id",
                            new XAttribute("advice", "ignore"),
                            new XAttribute("type", "internal"),
                            article.Element("galley").Element("file").Element("remote").Attribute("src").Value.TakeLast(9).Select(x => x.ToString().Replace("-", ""))),

                        new XElement("title",
                            new XAttribute("locale", article.Element("title").Attribute("locale").Value),
                            article.Element("title").Value.Split(" ").Skip(1).Select(x=>$"{x} ")),

                        new XElement("prefix",
                            new XAttribute("locale", article.Element("title").Attribute("locale").Value),
                            article.Element("title").Value.Split(" ")[0]),

                        new XElement("abstract",
                            new XAttribute("locale", article.Element("abstract").Attribute("locale").Value),
                            article.Element("abstract").Value),

                        new XElement("licenseUrl", article.Element("permissions").Element("license_url").Value),

                        new XElement("keywords",
                            new XAttribute("locale", article.Element("indexing").Element("subject").Attribute("locale").Value),
                            article.Element("indexing").Element("subject").Value.Split(";").Select(x => new XElement("keyword", x.Trim()))),

                        new XElement("authors",
                            new XAttribute(xsi + "schemaLocation", "http://pkp.sfu.ca native.xsd"),
                            new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance")),
                            new XElement("author",
                                article.Elements("author").Attributes(),
                                new XAttribute("user_group_ref","Author"),
                                new XAttribute("include_in_browse","true"),
                                new XElement("givenname",
                                    new XAttribute("locale",article.Element("author").Element("affiliation").Attribute("locale").Value),
                                    article.Element("author").Element("firstname").Value
                                    ),
                                new XElement("familyname",
                                    new XAttribute("locale",article.Element("author").Element("affiliation").Attribute("locale").Value),
                                    article.Element("author").Element("lastname").Value
                                    ),
                                new XElement("affiliation",
                                    new XAttribute("locale",article.Element("author").Element("affiliation").Attribute("locale").Value),
                                    article.Element("author").Element("affiliation").Value),
                                new XElement("country", article.Element("author").Element("country")?.Value),
                                new XElement("email", article.Element("author").Element("email")?.Value)
                            ),
                            new XElement("article_galley",
                                new XAttribute(""
                        )
                    );
                var file = article.Element("galley").Element("file").Element("remote").Attribute("src").Value.Split("-");
;
                Console.WriteLine(output);
                output.Save($"{string.Join("", file[1], file[2])}.xml");
            }
        }
    }
}
