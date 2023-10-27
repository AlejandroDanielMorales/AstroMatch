using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sign
    {
        public string Name { get; set; }
        public string Element { get; set; }

        public Sign(DateTime birthDate)
        {
            CalculateSignAndElement(birthDate);
        }

        private void CalculateSignAndElement(DateTime birthDate)
        {
            int month = birthDate.Month;
            int day = birthDate.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                Name = "Aries";
                Element = "Fire";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                Name = "Taurus";
                Element = "Earth";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                Name = "Gemini";
                Element = "Air";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                Name = "Cancer";
                Element = "Water";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                Name = "Leo";
                Element = "Fire";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                Name = "Virgo";
                Element = "Earth";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                Name = "Libra";
                Element = "Air";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                Name = "Scorpio";
                Element = "Water";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                Name = "Sagittarius";
                Element = "Fire";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                Name = "Capricorn";
                Element = "Earth";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                Name = "Aquarius";
                Element = "Air";
            }
            else
            {
                Name = "Pisces";
                Element = "Water";
            }
        }
    }
}
