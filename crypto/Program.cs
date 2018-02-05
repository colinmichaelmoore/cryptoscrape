namespace crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CoinMarketCap coinMarketCap = new CoinMarketCap();
            coinMarketCap.Scrape();
            
        }
    }
}
