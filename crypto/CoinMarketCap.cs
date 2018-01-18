using System;
using System.Collections.Generic;
using System.Linq;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace Scrape
{
    public class CoinMarketCap
    {
        public void scrape()
        {
            var browser = new ScrapingBrowser()
            {
                AllowAutoRedirect = true,
                AllowMetaRedirect = true
            };
            
            //Variable to store the site to scrape
            var pageResult = browser.NavigateToPage(new Uri("http://coinmarketcap.com/all/views/all"));
            //Store title based on CSS class
            var titleNode = pageResult.Html.CssSelect("#title").First();
            var pageTitle = titleNode.InnerText;


            Console.WriteLine(pageTitle);
            Console.WriteLine();

            //Store scraped items in specified CSS class
            List<String> names = new List<string>();
            var table = pageResult.Html.CssSelect("#currencies-all").First();
            var i = 0;
            //Loop through Table element and store selections based on specified element 
            foreach (var row in table.SelectNodes("tbody/tr"))
            {
                
                foreach (var col in row.SelectNodes("td"))
                {
                        
                    if (col.InnerText != "" && col.InnerText !=  " ")
                    {
                           
                        names.Add(col.InnerText.Replace(" ", String.Empty).Trim());
                        Console.WriteLine(names[i]);
                        i++;
                    }
                }
                
            }

            //Put in DB using entity framework
            using (var ctx = new CurrencyContext())
            {

                for (var j = 0; j<names.Count; j += 10)
                {
                    Currency Cryptos = new Currency()
                    {

                        Id = names[j],
                        Name = names[j + 1],
                        Symbol = names[j + 2],
                        Market = names[j + 3],
                        Price = names[j + 4],
                        Supply = names[j + 5],
                        Volume = names[j + 6],
                        Hour = names[j + 7],
                        Day = names[j + 8],
                        Week = names[j + 9]

                    };
                    ctx.Currencies.Add(Cryptos);
                }


                ctx.SaveChanges();

            }           
        }

    }
}