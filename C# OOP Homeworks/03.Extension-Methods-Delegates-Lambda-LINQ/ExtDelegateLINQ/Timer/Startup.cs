namespace Timer
{
    class Startup

    {
        static void Main()
        {
            Timer timer = new Timer(2); // <-- Change seconds here
            timer.Invoke();
        
        }
    }
}
