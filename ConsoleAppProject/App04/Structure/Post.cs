using ConsoleAppProject.App04.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// The post class allows an user to connect with other users by sharing their thoughts or images.
    /// </summary>
    [Serializable]
    public class Post
    {
        /// <summary>
        /// Varianbles
        /// </summary>
        #region Properties
        public User Author { get; private set; }
        public List<Comment> Comments { get; private set; }
        public Reactions Reaction { get; private set; }
        public int Likes { get; set; }
        public DateTime Timestamp { get; private set; }

        #endregion

        /// <summary>
        /// Initialize class.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="reaction"></param>
        public Post(User author, Reactions reaction)
        {
            this.Author = author;
            this.Reaction = reaction;
            Timestamp = DateTime.Now;
            Comments = new List<Comment>();
        }

        #region Post Methods
        
        /// <summary>
        /// Print a post. Not used due to level of inheritance.
        /// </summary>
        public virtual void Print()
        {
            Console.WriteLine("Nothing to see..");
        }       

        /// <summary>
        /// Validate the posibility of a user removing a post.
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public bool DeletePost(User author)
        {
            if(author.Username == Author.Username)
            {
                return true;
            }
            else
            {
                ConsoleHelper.PrintString(IndentLevel.Level3, "You do not own this post!");
                return false;
            }
        }        
        #endregion

        #region Comments Methods
        /// <summary>
        /// Add a comment to post.
        /// </summary>
        /// <param name="comment"></param>
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        /// <summary>
        /// Remove a comment from this post.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool DeleteComment(User user, Comment comment)
        {
            if (comment is null)
            {
                ConsoleHelper.PrintString(IndentLevel.Level3, "Comment does not exist!\n");
                return false;
            }
            else if (user != comment.Author)
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "You cannot delete this comment because you do not own it!\n");
                return false;
            }
            else
            {
                Comments.Remove(comment);
                return true;
            }
        }

        /// <summary>
        /// Retrieve a comment by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Comment GetCommentByID(int id)
        {
            for(int i = 0; i < Comments.Count; i++)
            {
                if(id == i)
                {
                    return Comments[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Print comments on terminal.
        /// </summary>
        public void PrintComments()
        {
            if(Comments.Count == 0)
            {
                ConsoleHelper.PrintString(IndentLevel.Level3, "This post has no comments!\n");
                return;
            }
            int id = 0;
            foreach(Comment c in Comments)
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, $"Comment ID: {id}");
                c.Print();
                id++;
            }
        }
        #endregion
    }
}
