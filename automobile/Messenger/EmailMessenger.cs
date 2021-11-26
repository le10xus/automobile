using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Messenger
{
    public class EmailMessenger : Messenger
    {
        public EmailMessenger(string userName, string password): base (userName, password)
        {

        }

        public override Message CreateMessage(string messageText, string destination, string source)
        {
            return new EmailMessage(messageText, destination, source);            
        }
    }
}
