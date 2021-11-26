using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Messenger
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    public class EmailMessage : Message
    {
        public EmailMessage(string messageText, string destination, string source) : base(messageText, destination, source)
        {

        }

        /// <summary>
        /// метод отправки письма
        /// </summary>
        public override void SendMessage()
        {
            throw new NotImplementedException();
        }
    }
}
