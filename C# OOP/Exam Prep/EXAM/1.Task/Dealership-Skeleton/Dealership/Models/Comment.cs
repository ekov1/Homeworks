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

                ValidatorCustom.StringValidation(value, Constants.MinCommentLength, Constants.MaxCommentLength,
                    "Content");
                this.content = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("    ----------");
            builder.AppendLine(String.Format("    {0}", this.Content));
            builder.AppendLine(String.Format("      User: {0}", this.Author));
            builder.AppendLine("    ----------");

            return builder.ToString();
        }
    }
}
