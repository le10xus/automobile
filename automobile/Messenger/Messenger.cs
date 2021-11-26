using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automobile.Messenger
{
    /// <summary>
    /// Объект мессенджера (может быть почта или скайп и т.д.)
    /// </summary>
    public abstract class Messenger
    {
        /// <summary>
        /// логин
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// пароль
        /// </summary>
        public string Password { get; set; }

        public Messenger(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        /// <summary>
        /// Отправка сообщения, фабричный метод
        /// </summary>
        /// <returns></returns>
        public abstract Message CreateMessage(string messageText, string destination, string source);
    }
}
