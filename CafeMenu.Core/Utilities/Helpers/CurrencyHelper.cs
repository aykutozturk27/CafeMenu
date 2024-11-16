using System.Globalization;
using System.Xml;

namespace CafeMenu.Core.Utilities.Helpers
{
    public static class CurrencyHelper
    {
        public static decimal GetCurrency()
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            var usd = xmlVerisi.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying")?.InnerText.Replace(',', '.'); 

            if (decimal.TryParse(usd, NumberStyles.Any, CultureInfo.InvariantCulture, out var decimalUsd))
            {
                // Değer virgül formatında string olarak döndürülür.
                return Convert.ToDecimal(decimalUsd.ToString("N", new CultureInfo("tr-TR")));
            }

            return 0; 
        }
    }
}
