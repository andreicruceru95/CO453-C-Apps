using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppProject.App04
{
    /// <summary>
    /// This class will store and retrieve all the usable app menus.
    /// </summary>
    public class ChoiceList
    {
        public Dictionary<string, string[]> Choices = new Dictionary<string, string[]>();

        /// <summary>
        /// These variables are used to store different menu choices.
        /// </summary>
        #region List of choices

        private string[] authentificationOptions = new string[]
        {
            "Login", "Create new account"
        };
        private string[] generalOptions = new string[]
        {
            "See Your Posts",
            "See Other User's Posts",
            "See All Posts",            
            "Share Image",
            "Share your thoughts",
            "Select Post",
            "Social",
            "Log Out!",            
            "Exit App"
        };
        private string[] socialOptions = new string[]
        {
            "Add Friends",
            "See Friends info",
            "Accept Friend Request",
            "Send Mail",
            "Read Mail",
            "Exit Social"
        };
        private string[] postOptions = new string[]
        {
            "Leave a comment",
            "Like Post",
            "Dislike Post",
            "Delete Post",
            "See Comments",
            "Select Comment",
            "Exit post"
        };
        private string[] commentOptions = new string[]
        {
            "Like Comment",
            "Dislike Comment",
            "Delete Comment",
            "Exit comment"
        };
        private string[] reactionOptions = new string[]
        {
            Reactions.Angry.ToString(),
            Reactions.Happy.ToString(),            
            Reactions.Nervous.ToString(),
            Reactions.Sad.ToString()
        };

        #endregion

        /// <summary>
        /// Initialize class.
        /// </summary>
        #region initialize
        private static ChoiceList instance;
        public static ChoiceList Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChoiceList();
                return instance;
            }
        }
        public ChoiceList()
        {
            Choices.Add("authentification", authentificationOptions);
            Choices.Add("general", generalOptions);
            Choices.Add("comment", commentOptions);
            Choices.Add("post", postOptions);
            Choices.Add("reaction", reactionOptions);
            Choices.Add("social", socialOptions);
        }
        #endregion

        #region methods

        /// <summary>
        /// Retrieve and print a list of choices on the terminal, preceaded by a question for the user.
        /// </summary>
        /// <param name="question">A question for the user</param>
        /// <param name="optionName">The key for the menu list</param>
        /// <returns>The user's choice as an integer.</returns>
        public int GetOptionList(string question,string optionName)
        {
            return ConsoleHelper.SelectChoice(question, Choices[optionName]);
        }
        #endregion
    }
}
