using ConsoleAppProject.App04.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppProject.App04.Social_Network
{
    /// <summary>
    /// Social Media application that allows users to:
    ///     -Create new account.
    ///     -Log in acounts.
    ///     -Post a status message.
    ///     -Post an image.
    ///     -Like/Dislike a post.
    ///     -Like/Dislike a comment.
    ///     -Comment on posts.
    ///     -Delete owned posts/comments.
    ///     -Add other users as friends.
    ///     -Send messages to other users.
    ///     -Remove friends from friend list.
    ///     -Other functions..
    /// </summary>
    public class SocialNetwork
    {
        private User CurrentUser;
        private int postID = 0;
        private Dictionary<int, Post> totalPosts = new Dictionary<int, Post>();
        
        /// <summary>
        /// Main method.
        /// </summary>
        public void Run()
        {
            CurrentUser = Authentification.Instance.Run() as User;

            if (CurrentUser == null)
            {
                Run();
            }
            RefreshPosts();

            RunGeneralOptions();
        }

        #region Menus

        /// <summary>
        /// General options is the menu that contains the main app functions and 
        /// allows an user to explore other menu branches.
        /// </summary>
        private void RunGeneralOptions()
        {
            var finished = false;

            while (!finished)
            {
                ConsoleHelper.PrintString("Social Network", true);

                var choice = ChoiceList.Instance.GetOptionList("Please select an action from bellow!", "general");

                if (choice == 9) finished = true;

                else ReturnGeneralOptions(choice);
            }
        }

        /// <summary>
        /// Respond to a user's choice.
        /// </summary>
        /// <param name="choice">user's choice</param>
        private void ReturnGeneralOptions(int choice)
        {
            var reaction = Reactions.Happy;
            switch (choice)
            {
                #region See All Individual user posts
                case 1:
                    var posts = CurrentUser.GetPosts();

                    if (posts.Count == 0)
                    {
                        ConsoleHelper.PrintString(IndentLevel.Level2, "You have no posts!");
                        break;
                    }
                    var totalUserPosts = new List<Post>();

                    foreach (var p in posts)
                        totalUserPosts.Add(p as Post);

                    totalUserPosts.OrderByDescending(p => p.Timestamp).ToList();

                    foreach (Post p in totalUserPosts)
                        p.Print();

                    break;
                #endregion

                #region See Other Users Posts
                case 2:
                    string username = ConsoleHelper.InputString("\tPlease enter username!\n");

                    User user = FindUser(username);
                    if (user != null)
                    {
                        var userPosts = user.GetPosts();

                        if (userPosts.Count == 0)
                        {
                            ConsoleHelper.PrintString(IndentLevel.Level2, $"{user.Username} has no posts!");
                            break;
                        }
                        var totalPosts = new List<Post>();

                        foreach (var p in userPosts)
                            totalPosts.Add(p as Post);

                        totalPosts.OrderByDescending(p => p.Timestamp).ToList();

                        foreach (Post p in totalPosts)
                            p.Print();
                    }
                    break;

                #endregion

                #region See total posts for all users
                case 3:
                    foreach (var p in totalPosts)
                    {
                        ConsoleHelper.PrintString(IndentLevel.Level2, $"\n\n\t\tPost ID: {p.Key}");
                        p.Value.Print();
                    }
                    break;
                #endregion

                #region Create Image Post
                case 4:
                    reaction = GetReaction(ChoiceList.Instance.GetOptionList("\tHow are you feeling?", "reaction"));
                    var caption = ConsoleHelper.InputString("\tAdd caption to your image:\n");

                    CurrentUser.CreateImagePost(reaction, caption);

                    RefreshPosts();

                    break;
                #endregion

                #region Create message post
                case 5:
                    reaction = GetReaction(ChoiceList.Instance.GetOptionList("\tHow are you feeling?", "reaction"));
                    string message = ConsoleHelper.InputString("\tPlease enter message:\n");

                    CurrentUser.CreateMessagePost(reaction, message);

                    RefreshPosts();

                    break;
                #endregion

                #region Enter post menu
                case 6:
                    var postID = ConsoleHelper.InputNumber("\tPlease enter Post ID:\n", 0, totalPosts.Count);
                    Post post = GetPostByID((int)postID);

                    RunPostOptions(post);

                    break;
                #endregion

                #region Social
                case 7:
                    RunSocialOptions();
                    break;
                #endregion

                #region LogOut
                case 8:
                    CurrentUser = null;
                    Run();
                    break;
                    #endregion
            }
        }

        /// <summary>
        /// Social options that include comunication and friendship between users.
        /// </summary>
        private void RunSocialOptions()
        {
            bool finished = false;
            while (!finished)
            {
                var choice = ChoiceList.Instance.GetOptionList("\tPlease select a choice","social");
                User friend;

                switch (choice)
                {
                    #region Add Friend
                    case 1:
                        string username = ConsoleHelper.InputString("\tPlease enter your friend's username!");

                        friend = FindUser(username);
                        if(friend != null)
                        {
                            friend.RecieveFriendRequest(CurrentUser);
                            CurrentUser.RequestFriendship(friend);
                        }                        

                        break;
                    #endregion

                    #region Friend List
                    case 2:
                        CurrentUser.DisplayFriends();
                        break;
                    #endregion

                    #region Accept Friend Request
                    case 3:
                        username = ConsoleHelper.InputString("\tPlease enter friend name!\n");

                        friend = FindUser(username);

                        if(friend != null)
                        {
                            CurrentUser.AcceptFriendRequest(friend);
                        }                                               

                        break;
                    #endregion

                    #region Send Mail

                    case 4:
                        username = ConsoleHelper.InputString("\tPlease enter username!\n");

                        friend = FindUser(username);
                        if(friend != null)
                        {
                            CurrentUser.SendMail(friend);
                        }                       

                        break;

                    #endregion

                    #region See Mail
                    case 5:
                        CurrentUser.PrintMail();
                        break;
                    #endregion

                    #region Exit Social
                    case 6:
                        finished = true;
                        break;
                    #endregion
                }
            }
        }

        /// <summary>
        /// Post options allows an user to explore individual posts.
        /// </summary>
        /// <param name="post"></param>
        private void RunPostOptions(Post post)
        {
            bool finished = false;
            while(!finished)
            {
                int choice = ChoiceList.Instance.GetOptionList("\tPlease select an option:\n", "post");

                switch(choice)
                {
                    case 1:
                        string message = ConsoleHelper.InputString("\tPlease enter comment:\n");
                        Comment comment = new Comment(CurrentUser, message);

                        post.AddComment(comment);
                        post.Author.SaveProgress(post);

                        break;
                    case 2:
                        if (CurrentUser.LikePost(post))
                        {
                            post.Likes++;
                            post.Author.SaveProgress(post);
                        }
                        break;
                    case 3:
                        if (CurrentUser.DislikePost(post))
                        {
                            post.Likes--;
                            post.Author.SaveProgress(post);
                        }
                        break;
                    case 4:
                        if(post.DeletePost(CurrentUser))
                        {
                            CurrentUser.DeletePost(post);
                            finished = true;
                        }                        
                        break;
                    case 5:
                        post.PrintComments();
                        break;
                    case 6:
                        var commentID = ConsoleHelper.InputNumber("\tPlease enter comment ID:\n", 0, post.Comments.Count);
                        var selectedComment = post.GetCommentByID((int)commentID);

                        if (selectedComment != null)
                            RunCommentOptions(post,selectedComment);
                        break;
                    case 7:
                        finished = true;
                        break;
                }
                RefreshPosts();
            }            
        }

        /// <summary>
        /// Comment options allows an user to expore individual comments.
        /// </summary>
        /// <param name="post"></param>
        /// <param name="comment"></param>
        private void RunCommentOptions(Post post,Comment comment)
        {
            bool finished = false;
            while(!finished)
            {
                var choice = ChoiceList.Instance.GetOptionList("\tPlease select an option: ", "comment");

                switch(choice)
                {
                    case 1:
                        if (CurrentUser.LikeComment(comment))
                        {
                            comment.Likes++;
                            post.Author.SaveProgress(post);
                        }
                        break;
                    case 2:
                        if (CurrentUser.DislikeComment(comment))
                        {
                            comment.Likes--;
                            post.Author.SaveProgress(post);
                        }
                        break;
                    case 3:
                        if(post.DeleteComment(CurrentUser,comment))
                        {
                            post.Author.SaveProgress(post);
                            finished = true;
                        }
                        break;
                    case 4:
                        finished = true;
                        break;
                }
            }
            RefreshPosts();
        }

        #endregion

        #region Other Methods
        /// <summary>
        /// Find and retrieve a post with a given ID.
        /// </summary>
        /// <param name="id">post id</param>
        /// <returns></returns>
        private Post GetPostByID(int id)
        {
            foreach(var post in totalPosts)
            {
                if(id == post.Key)
                {
                    return post.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// 'Translate' an integer input to an enumeration type reaction.
        /// </summary>
        /// <param name="reaction">integer that represents user's reaction choice.</param>
        /// <returns></returns>
        private Reactions GetReaction(int reaction)
        {
            switch (reaction)
            {
                case 1:
                    return Reactions.Angry;
                case 2:
                    return Reactions.Happy;
                case 3:
                    return Reactions.Nervous;
                case 4:
                    return Reactions.Sad;
                default:
                    return Reactions.Null;
            }
        }

        /// <summary>
        /// Find and retrieve a user by a given username.
        /// </summary>
        /// <param name="username">user's username</param>
        /// <returns></returns>
        private User FindUser(string username)
        {
            var users = Streamer.ReadFile(Authentification.UsersFile);

            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }

            ConsoleHelper.PrintString(IndentLevel.Level3,"User not found!\n");
            return null;
        }

        /// <summary>
        /// Refresh posts and order them by date.
        /// </summary>
        private void RefreshPosts()
        {
            totalPosts.Clear();
            postID = 0;

            var userList = Streamer.ReadFile(Authentification.UsersFile);
            var posts = new List<Post>();

            foreach (User user in userList)
            {
                var userPosts = user.GetPosts();

                foreach (var p in userPosts)
                {
                    posts.Add(p as Post);
                }
            }
            posts = posts.OrderByDescending(p => p.Timestamp).ToList();
            
            foreach(Post p in posts)
            {
                totalPosts.Add(postID, p);
                postID++;
            }
        }
        #endregion
    }
}
