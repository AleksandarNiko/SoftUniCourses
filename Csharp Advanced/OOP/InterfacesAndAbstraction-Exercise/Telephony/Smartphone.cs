using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone:ISmartphone
    {
        public void Call(string phoneNumber)
        {
            if (phoneNumber.Any(ch => !char.IsDigit(ch)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
        }

        public void BrowseURL(string url)
        {
            if (!ValidateURL(url))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }

        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(ch => char.IsDigit(ch));

        private bool ValidateURL(string url)
            => url.All(ch => !char.IsDigit(ch));
    }
}
