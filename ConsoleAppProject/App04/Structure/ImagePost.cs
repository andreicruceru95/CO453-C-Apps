using ConsoleAppProject.App04.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// An image post is a type of post that represents a real life image.
    /// </summary>
    [Serializable]
    public class ImagePost : Post
    {
        /// <summary>
        /// Variables
        /// </summary>
        #region Properties
        
        public string Caption { get; set; }
        public string Image = "\t\t|---------------|\n" +
                              "\t\t|    Cannot     |\n" +
                              "\t\t|               |\n" +
                              "\t\t|     Load      |\n" +
                              "\t\t|               |\n" +
                              "\t\t|     Image     |\n" +
                              "\t\t|               |\n" +
                              "\t\t|       X       |\n" +
                              "\t\t|---------------|\n";

        #endregion

        /// <summary>
        /// Initialize class.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="reaction"></param>
        /// <param name="caption"></param>
        public ImagePost(User author, Reactions reaction, string caption) : base(author, reaction)
        {
            this.Caption = caption;
        }

        /// <summary>
        /// Print Image on terminal.
        /// </summary>
        public override void Print()
        {
            ConsoleHelper.PrintString(IndentLevel.Level2, $"User\t{Author.Username}");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Feeling\t{Reaction}");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Time\t{Timestamp} GMT\n");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Caption: {Caption}\n");
            ConsoleHelper.PrintString(IndentLevel.Level0, $"{Image}\n");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Likes: {Likes}");
            ConsoleHelper.PrintString(IndentLevel.Level2, $"Comments: {Comments.Count}");
        }
    }
}
