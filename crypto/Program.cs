using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Html.Forms;

namespace Scrape
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CoinMarketCap coinMarketCap = new CoinMarketCap();
            coinMarketCap.scrape();
            
        }
    }
}
