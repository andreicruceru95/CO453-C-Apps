using ConsoleAppProject.App04.Structure;
using ConsoleAppProject.App04.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// The comment class allows users to attach their thoughts on a post. 
    /// </summary>
    [Serializable]
    public class Comment
    {
        /// <summary>
        /// Variables
        /// </summary>
        #region Properties

        public User Author { get; private set; }
        public int Likes { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; private set; }

        #endregion

        /// <summary>
        /// Initialize class.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="message"></param>
        public Comment(User author, string message)
        {
            this.Author = author;
            this.Message = message;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Print Comment
        /// </summary>
        public void Print()
        {
            ConsoleHelper.PrintString(IndentLevel.Level2, $"{Author.Username}\n");
            ConsoleHelper.PrintString(IndentLevel.Level3, $"{Message}\n");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Time: {Timestamp} GMT");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Likes: {Likes}\n");
        }
    }
}
