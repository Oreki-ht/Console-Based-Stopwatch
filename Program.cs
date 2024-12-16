class Stopwatch
{
    static bool isRunning = false;
    static DateTime startTime = DateTime.Now;
    static TimeSpan elapsedTime = TimeSpan.Zero;

    static void Main()
    {
        Console.WriteLine("Press 's' to start the stopwatch, 't' to stop, 'r' to reset, 'e' to exit.");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).KeyChar;

                if (key == 's')
                {
                    Start();
                }
                else if (key == 't')
                {
                    Stop();
                }
                else if (key == 'r')
                {
                    Reset();
                }
                else if (key == 'e')
                {
                    Console.WriteLine("\nExiting");
                    break;
                }
            }

            if (isRunning)
            {
                Tick();
            }

            Thread.Sleep(100);
        }
    }

    static void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = DateTime.Now;
            Console.WriteLine("Started");
        }
    }

    static void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            elapsedTime += DateTime.Now - startTime;
            Console.WriteLine("\nStopped. Press 's' to resumee");
        }
    }

    static void Reset()
    {
        isRunning = false;
        elapsedTime = TimeSpan.Zero;
        Console.WriteLine("\nReset");
    }

    static void Tick()
    {
        var currentElapsed = elapsedTime + (DateTime.Now - startTime);
        Console.Write($"\rElapsed time: {currentElapsed.TotalSeconds:F2} seconds");
    }
}