namespace Dealership.Models
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comment : IComment
    {
        private string content;
        private string author;

        public Comment(string content)
        {
            this.Content = content;
        }

        public string Author { get; set; }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Validator.ValidateNull(value,
                    String.Format("{0} cannot be null or empty!", "Content"));

                Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, "Content",
                    Constants.MinCommentLength, Constants.MaxCommentLength));

                this.content = value;
            }
        }
    }
}
