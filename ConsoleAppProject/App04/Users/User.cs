using ConsoleAppProject.App04.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppProject.App04.Users
{
    /// <summary>
    /// Represents a virtual representation of a human accessing this application.
    /// </summary>
    [Serializable]
    public class User
    {
        #region User Files
        public string FriendListFile { get; private set; }
        public string MessageListFile { get; private set; }
        public string RecievedFriendRequestFile { get; private set; }
        public string SentFriendRequestFile { get; private set; }
        public string LikedCommentsFile { get; private set; }
        public string DislikedCommentsFile { get; private set; }
        public string LikedPostsFile { get; private set; }
        public string DislikedPostsFile { get; private set; }
        public string OwnedPostsFile { get; private set; }

        #endregion

        #region Properties
        public string Username { get; set; }
        public string Password { get; set; }
        
        #endregion

        /// <summary>
        /// Initialize class.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password)
        {
            Username = username;
            Password = password;

            InitializeFilesPath();
            InitializeFiles();
        }

        /// <summary>
        /// Validate Login Attempt.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateLogin(string username, string password)
        {
            return username == Username && password == Password;
        }

        #region Files Management

        /// <summary>
        /// Create the file paths required to store user data.
        /// </summary>
        private void InitializeFilesPath()
        {
            FriendListFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "FriendList.bin");
            MessageListFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "MessageList.bin");
            RecievedFriendRequestFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "RecievedFriendRequestList.bin");
            SentFriendRequestFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "SentFriendRequestList.bin");
            LikedCommentsFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "LikedCommentsList.bin");
            DislikedCommentsFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "DislikedCommentsList.bin");
            LikedPostsFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "LikedPostsList.bin");
            DislikedPostsFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "DislikedPostsList.bin");
            OwnedPostsFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Bin", Username + "OwnedPostsList.bin");            
        }

        /// <summary>
        /// Initialize and create the binary files required for individual users.
        /// </summary>
        private void InitializeFiles()
        {
            List<object> initializer = new List<object>();

            Streamer.SaveFile(initializer, OwnedPostsFile);
            Streamer.SaveFile(initializer, LikedPostsFile);
            Streamer.SaveFile(initializer, DislikedPostsFile);
            Streamer.SaveFile(initializer, LikedCommentsFile);
            Streamer.SaveFile(initializer, DislikedCommentsFile);
            Streamer.SaveFile(initializer, FriendListFile);
            Streamer.SaveFile(initializer, SentFriendRequestFile);
            Streamer.SaveFile(initializer, RecievedFriendRequestFile);
            Streamer.SaveFile(initializer, MessageListFile);
        }
        #endregion       

        #region Friends Function
        /// <summary>
        /// Request friendship with another user.
        /// </summary>
        /// <param name="user"></param>
        public void RequestFriendship(User user)
        {
            var friendList = Streamer.ReadFile(FriendListFile);
            var sentRequest = Streamer.ReadFile(SentFriendRequestFile);

            if (user == null)
            {
                ConsoleHelper.PrintString(IndentLevel.Level3, "User doesn't exist!\n");
                
                return;
            }
            foreach(User friend in friendList)
            {
                if(friend.Username.Equals(user.Username))
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, $"You are already friend with {user.Username}\n");
                    break;
                }
            }            
             sentRequest.Add(user);             

            Streamer.SaveFile(sentRequest, SentFriendRequestFile);
        }

        /// <summary>
        /// Accept a user's friend request.
        /// </summary>
        /// <param name="user"></param>
        public void AcceptFriendRequest(User user)
        {
            var recievedRequests = Streamer.ReadFile(RecievedFriendRequestFile);
            var friendList = Streamer.ReadFile(FriendListFile);
            bool found = false;
            
            foreach (User friend in recievedRequests)
            {
                if(friend.Username.Equals(user.Username))
                {
                    recievedRequests.Remove(friend);

                    friendList.Add(friend);
                    friend.AddFriend(this);
                    found = true;
                    ConsoleHelper.PrintString(IndentLevel.Level2, $"{user.Username} added to your friend list!\n");

                    break;
                }                
            }
            if(found is false)
            {
                ConsoleHelper.PrintString(IndentLevel.Level1, $"{user.Username} did not sent you a request!\n");
            }

            Streamer.SaveFile(recievedRequests, RecievedFriendRequestFile);
            Streamer.SaveFile(friendList, FriendListFile);
        }

        /// <summary>
        /// Recieve a friend request.
        /// </summary>
        /// <param name="user"></param>
        public void RecieveFriendRequest(User user)
        {
            var recievedRequests = Streamer.ReadFile(RecievedFriendRequestFile);

            recievedRequests.Add(user);

            Streamer.SaveFile(recievedRequests, RecievedFriendRequestFile);
        }

        /// <summary>
        /// Add a new Friend
        /// </summary>
        /// <param name="user"></param>
        public void AddFriend(User user)
        {
            if (user == this) ConsoleHelper.PrintString(IndentLevel.Level3, "You cannot add yourself!\n");

            var friendList = Streamer.ReadFile(FriendListFile);            

            if (!friendList.Contains(user)) friendList.Add(user);

            else ConsoleHelper.PrintString(IndentLevel.Level3, $"{user.Username} is already your friend!\n");

            if(!friendList.Contains(this)) friendList.Add(this);

            Streamer.SaveFile(friendList, FriendListFile);
        }

        /// <summary>
        /// Remove a friend from friend list.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveFriend(User user)
        {
            var friendList = Streamer.ReadFile(FriendListFile);

            if (friendList.Contains(user))
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, $"{user.Username} has been removed from your Friends!\n");
                friendList.Remove(user);
            }
            else ConsoleHelper.PrintString(IndentLevel.Level2, $"{user.Username} is not your friend!\n");            

            Streamer.SaveFile(friendList, FriendListFile);
        }

        /// <summary>
        /// Display friends information
        /// </summary>
        public void DisplayFriends()
        {
            var friends = Streamer.ReadFile(FriendListFile);
            var sentRequests = Streamer.ReadFile(SentFriendRequestFile);
            var recievedRequests = Streamer.ReadFile(RecievedFriendRequestFile);

            ConsoleHelper.PrintString(IndentLevel.Level3, $"Your Friends:\n");
            foreach (User friend in friends)
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, $"{friend.Username}");
            }

            if (sentRequests.Count > 0)
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "Sent Friend Requests:\n");
                foreach (User user in sentRequests)
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, $"{user.Username}");
                }
            }
            if (recievedRequests.Count > 0)
            {
                ConsoleHelper.PrintString(IndentLevel.Level3, "Recieved Friend Requests:\n");
                foreach (User user in recievedRequests)
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, $"{user.Username}");
                }
            }
        }
        #endregion

        #region Like Function

        /// <summary>
        /// Like a comment.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool LikeComment(Comment comment)
        {
            if (comment.Author.Username.Equals(Username))
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "You cannot like this comment because you own it!\n");
                return false;
            }

            var likedComments = Streamer.ReadFile(LikedCommentsFile);
            var dislikedComments = Streamer.ReadFile(DislikedCommentsFile);

            foreach (Comment c in likedComments)
            {
                if (c.Author.Username == Username && c.Timestamp == comment.Timestamp)
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, "You already Liked this comment\n");
                    return false;
                }
            }
            foreach (Comment c in dislikedComments)
            {
                if (c.Author.Username == Username && c.Timestamp == comment.Timestamp)
                {
                    dislikedComments.Remove(c);
                    break;
                }
            }
            likedComments.Add(comment);            

            Streamer.SaveFile(likedComments, LikedCommentsFile);
            Streamer.SaveFile(dislikedComments, DislikedCommentsFile);
            return true;

        }

        /// <summary>
        /// Dislike a comment.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool DislikeComment(Comment comment)
        {
            if (comment.Author.Username.Equals(Username))
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "You cannot dislike this comment because you own it!\n");
                return false;
            }

            var likedComments = Streamer.ReadFile(LikedCommentsFile);
            var dislikedComments = Streamer.ReadFile(DislikedCommentsFile);

            foreach (Comment c in dislikedComments)
            {
                if (c.Author.Username == Username && c.Timestamp == comment.Timestamp)
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, "You already Disliked this comment\n");
                    return false;
                }
            }
            foreach (Comment c in likedComments)
            {
                if (c.Author.Username == Username && c.Timestamp == comment.Timestamp)
                {
                    likedComments.Remove(c);
                    break;
                }
            }
            dislikedComments.Add(comment);

            Streamer.SaveFile(likedComments, LikedCommentsFile);
            Streamer.SaveFile(dislikedComments, DislikedCommentsFile);

            return true;

        }

        /// <summary>
        /// Like a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public bool LikePost(Post post)
        {
            //Issue: object comparison and deep object comparison returns false.
            //I had to compare author usernames, as they are set to be unique.
            if (post.Author.Username.Equals(Username))
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "You cannot like this post because you own it!\n");
                return false;
            }

            var likedPosts = Streamer.ReadFile(LikedPostsFile);
            var dislikedPosts = Streamer.ReadFile(DislikedPostsFile);            

            foreach (Post p in likedPosts)
            {
                if (p.Reaction == post.Reaction && p.Timestamp == post.Timestamp)
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, "You already Liked this post");
                    return false;
                }
            }
            foreach (Post p in dislikedPosts)
            {
                if (p.Reaction == post.Reaction && p.Timestamp == post.Timestamp)
                {
                    dislikedPosts.Remove(p);
                    break;
                }
            }
            // Not Working!!
            //if (likedPosts.Contains(post))
            //{
            //    Console.WriteLine($"You already Liked this post");
            //    return false;
            //}
            likedPosts.Add(post);            

            Streamer.SaveFile(likedPosts, LikedPostsFile);
            Streamer.SaveFile(dislikedPosts, DislikedPostsFile);
            
            return true;
        }

        /// <summary>
        /// Dislike a post.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public bool DislikePost(Post post)
        {
            if (post.Author.Username.Equals(Username))
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "You cannot like this post because you own it!\n");
                return false;
            }
            var likedPosts = Streamer.ReadFile(LikedPostsFile);
            var dislikedPosts = Streamer.ReadFile(DislikedPostsFile);

            foreach (Post p in dislikedPosts)
            {
                if (p.Reaction == post.Reaction && p.Timestamp == post.Timestamp)
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, "You already Disliked this post\n");
                    return false;
                }
            }
            foreach (Post p in likedPosts)
            {
                if (p.Reaction == post.Reaction && p.Timestamp == post.Timestamp)
                {
                    likedPosts.Remove(p);
                    break;
                }
            }
            dislikedPosts.Add(post);            

            Streamer.SaveFile(likedPosts, LikedPostsFile);
            Streamer.SaveFile(dislikedPosts, DislikedPostsFile);
            
            return true;
        }

        #endregion

        #region Mail Function

        /// <summary>
        /// Send a mail message to another user.
        /// </summary>
        /// <param name="otherUser"></param>
        public void SendMail(User otherUser)
        {
            string message = ConsoleHelper.InputString($"\tPlease enter your message for {otherUser.Username}\n");

            Message mail = new Message(this, message);

            otherUser.RecieveMail(mail);
        }

        /// <summary>
        /// Manage recieved mail messages from other users.
        /// </summary>
        /// <param name="message"></param>
        public void RecieveMail(Message message)
        {
            var messages = Streamer.ReadFile(MessageListFile);

            messages.Add(message);

            Streamer.SaveFile(messages, MessageListFile);
        }

        /// <summary>
        /// Print mails.
        /// </summary>
        public void PrintMail()
        {
            var messages = Streamer.ReadFile(MessageListFile);


            if (messages.Count == 0)
            {
                ConsoleHelper.PrintString(IndentLevel.Level3, "You have no messages!\n");
            }
            else
            {
                foreach (Message message in messages)
                {
                    message.Print();
                }
            }
        }
        #endregion

        #region Post Function     
        /// <summary>
        /// Delete a post.
        /// </summary>
        /// <param name="post"></param>
        public void DeletePost(Post post)
        {
            var posts = GetPosts();
            posts.Remove(post);
            Streamer.SaveFile(posts, OwnedPostsFile);
        }

        /// <summary>
        /// Create an message post.
        /// </summary>
        /// <param name="reaction"></param>
        /// <param name="message"></param>
        /// 
        public void CreateMessagePost(Reactions reaction, string message)
        {
            var posts = Streamer.ReadFile(OwnedPostsFile);

            var messagePost = new MessagePost(this, reaction, message);

            posts.Add(messagePost);

            Streamer.SaveFile(posts, OwnedPostsFile);            
        }

        /// <summary>
        /// Create an image post.
        /// </summary>
        /// <param name="reaction"></param>
        /// <param name="caption"></param>
        public void CreateImagePost(Reactions reaction, string caption)
        {
            var posts = Streamer.ReadFile(OwnedPostsFile);
            
            var imagePost = new ImagePost(this, reaction, caption);

            posts.Add(imagePost);

            Streamer.SaveFile(posts, OwnedPostsFile);
        }        

        /// <summary>
        /// Return a list of user posts.
        /// </summary>
        /// <returns></returns>
        public List<object> GetPosts()
        {
            return Streamer.ReadFile(OwnedPostsFile);
        }

        /// <summary>
        /// Save posts.
        /// </summary>
        /// <param name="post"></param>
        public void SaveProgress(Post post)
        {
            var ownedPosts = Streamer.ReadFile(OwnedPostsFile);

            foreach(Post p in ownedPosts)
            {
                if (p.Author.Username.Equals(Username) && p.Timestamp == post.Timestamp)
                {
                    ownedPosts.Remove(p);
                    ownedPosts.Add(post);
                    Streamer.SaveFile(ownedPosts, OwnedPostsFile);

                    break;
                }
            }            
        }
        #endregion
    }
}
