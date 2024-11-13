using System.Xml;

namespace CafeMenu.Core.Utilities.Helpers
{
    public static class CurrencyHelper
    {
        public static decimal GetCurrency()
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            var usd = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexBuying", "USD")).InnerText.Replace(',', '.'));
            return usd;
        }
    }
}
