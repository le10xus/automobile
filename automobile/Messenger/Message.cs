using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Messenger
{
    /// <summary>
    /// Объект сообщения для мессенджера
    /// </summary>
    public abstract class Message
    {
        public string MessageText { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }

        public Message(string messageText, string destination, string source)
        {
            MessageText = messageText;
            Destination = destination;
            Source = source;
        }

        /// <summary>
        /// отправить сообщение
        /// </summary>
        public abstract void SendMessage();
    }
}
