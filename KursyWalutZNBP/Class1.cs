using System.Net;
using System.Xml.Linq;

namespace KursyWalutZNBP
{
    public class Class1
    {
        public List<XDocument> document(/*string currency, string dataFrom, string dataTo*/)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Accept", "application/json");
            var link = client.DownloadString($"https://www.nbp.pl/kursy/xml/dir.aspx?tt=C");
            
            List<string> list = new List<string>();
            var splittedLink = link/*.Split("<pre")[1].Split("<a href=\"")*/;
            
            //var link = client.DownloadString($"https://www.nbp.pl/kursy/xml/c");

            //var linq = XDocument.Parse(link);

            return new List<XDocument>() {  };
        }
    }
}