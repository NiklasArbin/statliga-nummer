using System.Linq;

namespace StatligaNummer
{
    public class Personnummer
    {
        private bool _hasCentury;
        private string _personNummer;

        /// <summary>
        ///     Parses personnummers in the formats:
        ///     YYYYMMDD-XXXX
        ///     YYMMDD-XXXX
        ///     YYMMDD+XXXX
        /// </summary>
        /// <param name="personNummer"></param>
        /// <exception cref="InvalidPersonnummerException"></exception>
        public Personnummer(string personNummer)
        {
            Parse(personNummer);
        }

        public Personnummer(int personNummer)
        {
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Födelsenummer { get; set; }
        public int Kontrollsiffra { get; set; }

        private void Parse(string personNummer)
        {
            personNummer = personNummer.Replace("-", string.Empty);
            personNummer = personNummer.Replace("+", string.Empty);

            switch (personNummer.Length)
            {
                case 12:
                    Year = int.Parse(personNummer.Substring(0, 4));
                    Month = int.Parse(personNummer.Substring(4, 2));
                    Day = int.Parse(personNummer.Substring(6, 2));
                    Födelsenummer = int.Parse(personNummer.Substring(8, 3));
                    Kontrollsiffra = int.Parse(personNummer.Substring(11, 1));
                    _hasCentury = true;
                    _personNummer = personNummer.Substring(2, 9);
                    break;
                case 10:
                    Year = int.Parse(personNummer.Substring(0, 2));
                    Month = int.Parse(personNummer.Substring(2, 2));
                    Day = int.Parse(personNummer.Substring(4, 2));
                    Födelsenummer = int.Parse(personNummer.Substring(6, 3));
                    Kontrollsiffra = int.Parse(personNummer.Substring(9, 1));
                    _personNummer = personNummer.Substring(0, 9);
                    break;
                default:
                    throw new InvalidPersonnummerException(personNummer);
            }
        }

        public bool IsValid()
        {
            for (int index = 0; index < _personNummer.Length; index++)
            {
                char c = _personNummer[index];
                var n = c - 48;
                var k = (index % 2 == 0 ? 1 : 2);
                var sum = k / 10 + k % 10;
            }
            return false;
            //var sum = _personNummer
            //        .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
            //        .Sum((e) => e / 10 + e % 10);
            //var kontroll = sum % 10;
            //return kontroll == Kontrollsiffra;
        }
    }
}