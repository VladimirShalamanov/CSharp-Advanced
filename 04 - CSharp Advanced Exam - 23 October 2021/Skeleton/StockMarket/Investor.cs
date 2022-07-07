using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public int Count  { get => this.Portfolio.Count; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var company = this.Portfolio.FirstOrDefault(n => n.CompanyName == companyName);
            if (company == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < company.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(company);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            var company = this.Portfolio.FirstOrDefault(n => n.CompanyName == companyName);
            if (company == null)
            {
                return null;
            }
            return company;
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
            {
                return null;
            }
            var biggest = this.Portfolio.Max(n => n.MarketCapitalization);
            var company = this.Portfolio.FirstOrDefault(n => n.MarketCapitalization == biggest);
            return company;
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var i in Portfolio) sb.AppendLine(i.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
