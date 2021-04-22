using ConsoleAppProject.App04.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04.Structure
{
    /// <summary>
    /// Message class is used to send a message between users.
    /// </summary>
    [Serializable]
    public class Message
    {
        public User Sender { get; set; }
        public string TextMessage { get; set; }

        public Message(User sender, string message)
        {            
            this.TextMessage = message;
            this.Sender = sender;
        }
        /// <summary>
        /// Print a message on screen.
        /// </summary>
        public virtual void Print()
        {
            ConsoleHelper.PrintString(IndentLevel.Level1, $"{Sender.Username}\n");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"{TextMessage}\n");
        }
    }
}
