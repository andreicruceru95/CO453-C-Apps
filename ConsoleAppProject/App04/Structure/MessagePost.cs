using ConsoleAppProject.App04.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04.Structure
{
    /// <summary>
    /// Message post is a type of post that allows an user to share its thoughts. 
    /// </summary>
    [Serializable]
    public class MessagePost : Post
    {
        /// <summary>
        /// Variables.
        /// </summary>
        #region Properties
        public string Message { get; set; }

        #endregion

        /// <summary>
        /// Initialize Class
        /// </summary>
        /// <param name="author"></param>
        /// <param name="reaction"></param>
        /// <param name="message"></param>
        public MessagePost(User author, Reactions reaction, string message) : base(author, reaction)
        {
            Message = message;
        }

        /// <summary>
        /// Print a post.
        /// </summary>
        public override void Print()
        {
            ConsoleHelper.PrintString(IndentLevel.Level2, $"User\t{Author.Username}");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Feeling\t{Reaction}");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Time\t{Timestamp} GMT\n");
            ConsoleHelper.PrintString(IndentLevel.Level3, $"{Message}\n");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Likes: {Likes}");
            ConsoleHelper.PrintString(IndentLevel.Level2,$"Comments: {Comments.Count}");
        }
    }
}
