namespace CurrencyMvc.Models
{
    public class CurrencyCodes
    {
        public Dictionary<string, string> Kodlar { get; }
        //public List<string> Kodlar { get; }

        public CurrencyCodes()
        {
             Kodlar = new Dictionary<string, string>
            {
                {"USD", "ABD DOLARI" },
                {"AUD", "AVUSTRALYA DOLARI" },
                {"DKK", "DANİMARKA KRONU" },
                {"EUR", "EURO"},
                {"GBP", "İNGİLİZ STERLİNİ"},
                {"CHF", "İSVİÇRE FRANGI"},
                {"SEK", "İSVEÇ KRONU"},
                {"CAD", "KANADA DOLARI"},
                {"KWD", "KUVEYT DİNARI"},
                {"NOK", "NORVEÇ KRONU"},
                {"SAR", "SUUDİ ARABİSTAN RİYALİ"},
                {"JPY", "JAPON YENİ"},
                {"BGN", "BULGAR LEVASI"},
                {"RON", "RUMEN LEYİ"},
                {"RUB", "RUS RUBLESİ"},
                {"IRR", "İRAN RİYALİ"},
                {"CNY", "ÇİN YUANI"},
                {"PKR", "PAKİSTAN RUPİSİ"},
                {"QAR", "KATAR RİYALİ"},
                {"XDR", "SDR (ÖZEL ÇEKME HAKKI)"},

            };


            //Kodlar = new List<string> { "USD", "EUR", "GBP", "TRY" };
        }
    }
}
