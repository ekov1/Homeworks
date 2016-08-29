namespace Bunnies.Models
{
    using System;
    using System.Text;
    using Constracts;
    using Enums;
    using Utils;

    [Serializable]
    public class Bunny
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public FurType FurType { get; set; }

        public void Introduce(IWriter writer)
        {
            var bunnyFurType = this.FurType.ToString().SeparateDifferentWords();

            writer.WriteLine($@"{this.Name} - ""I am {this.Age} years old!""");
            writer.WriteLine($@"{this.Name} - ""And I am {bunnyFurType}");
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            var bunnyFurType = this.FurType.ToString().SeparateDifferentWords();

            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {bunnyFurType}");

            return builder.ToString();
        }
    }
}
