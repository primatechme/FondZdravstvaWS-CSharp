using Primatech.FondZdravstvaWS.Models.Lager;
using System;


namespace Primatech.FondZdravstvaWS.Sample
{
    class Program
    {
        const string USTANOVA_ID = "#####";
        const string ORG_JEDINICA = "######";
        const string USERNAME = "******";
        const string PASSWORD = "***************";

        static FondZdravstvaWSConfig _config;

        static void Main(string[] args)
        {
            _config = new FondZdravstvaWSConfig {
                SifraUstanove = USTANOVA_ID,
                OrgJedinicaId = ORG_JEDINICA,
                Username = USERNAME,
                Password = PASSWORD
            };

            Start();
        }

        private static void Start()
        {
            Console.WriteLine("============================");
            Console.WriteLine("1. SF Ustanove");
            Console.WriteLine("2. SF OrganizacioneJedinice");
            Console.WriteLine("3. SF JediniceMjere");
            Console.WriteLine("4. SF LijekoviLager");
            Console.WriteLine("5. SF Proizvodjaci");
            Console.WriteLine("6. Post lager");

            var res = Console.ReadLine();

            if (Int32.TryParse(res, out var broj))
            {
                try
                {
                    switch (broj)
                    {
                        case 1:
                            TestUstanove(); break;
                        case 2:
                            TestOrganizacioneJedinice(); break;
                        case 3:
                            TestJediniceMjere(); break;
                        case 4:
                            TestLijekoviLager(); break;
                        case 5:
                            TestProizvodjaci(); break;
                        case 6:
                            TestPostLager(); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Greska:");
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("============================");
            Start();
        }

        private static void TestPostLager()
        {
            var client = new FondZdravstvaWSClient(_config);
            var testData = GetTestData();
            var result = client.PostLager(testData);
            PrettyPrint(result);
        }

        private static void TestProizvodjaci()
        {
            var client = new FondZdravstvaWSClient(_config);
            var result = client.GetProizvodjaci();
            PrettyPrint(result);
        }

        private static void TestLijekoviLager()
        {
            var client = new FondZdravstvaWSClient(_config);
            var result = client.GetLijekoviLager();
            PrettyPrint(result);
        }

        private static void TestJediniceMjere()
        {
            var client = new FondZdravstvaWSClient(_config);
            var result = client.GetJediniceMjere();
            PrettyPrint(result);
        }

        private static void TestOrganizacioneJedinice()
        {
            var client = new FondZdravstvaWSClient(_config);
            var result = client.GetOrganizacioneJedinice();
            PrettyPrint(result);
        }

        static void TestUstanove()
        {
            var client = new FondZdravstvaWSClient(_config);
            var result = client.GetUstanove();
            PrettyPrint(result);
        }

        static void PrettyPrint(object data) {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            Console.Write(json);
            Console.WriteLine("============================");
        }

        static PostLagerRequest GetTestData()
        {
            var tempData = new PostLagerRequest {
                new Lager
                {
                    ApotekaId = ORG_JEDINICA,
                    SifraFond = "N04BX601002",
                    Sifra = "1",
                    Naziv = "Test- Tasmar tabl.",
                    JMFond = "kut.",
                    Kolicina = 100,
                    Datum = $"{DateTime.Now:dd.MM.yyyy}"
                },
                new Lager
                {
                    ApotekaId = ORG_JEDINICA,
                    SifraFond = "C02LA510203",
                    Sifra = "2",
                    Naziv = "Test- Brinedrin",
                    JMFond = "kut.",
                    Kolicina = 74,
                    Datum = $"{DateTime.Now:dd.MM.yyyy}"
                }
            };

            return tempData;
        }
    }
}
