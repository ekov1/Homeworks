namespace Matrix
{
    using System;

    [Version(2, 30)]
    public static class SampleForAttributes
    {
        static SampleForAttributes()
        {
            Message = "This class has a version attribute.";
        }

        public static string Message { get; private set; }
    }
}
