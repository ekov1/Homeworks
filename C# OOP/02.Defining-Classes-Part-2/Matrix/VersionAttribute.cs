namespace Matrix
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
        public int Major
        {
            get
            {
                return this.major;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Major version cannot be a negative number!");
                }
                this.major = value;
            }
        }

        public int Minor
        {
            get
            {
                return this.minor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Minor version cannot be a negative number!");
                }
                this.minor = value;
            }
        }

        public string Version
        {
            get
            {
                return $"{this.Major}.{this.Minor}";
            }
        }
    }
}
