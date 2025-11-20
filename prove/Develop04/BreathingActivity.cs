using System;
using System.Diagnostics;
using System.Threading;

public class BreathingActivity : Activity
{
    private int _cycleSeconds = 4;

    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void PerformActivity()
    {
        Stopwatch sw = Stopwatch.StartNew();

        while (sw.Elapsed.TotalSeconds < _durationSeconds)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            int inSeconds = Math.Min(_cycleSeconds, SecondsRemaining(sw));
            ShowCountdownSeconds(inSeconds, sw);
            if (sw.Elapsed.TotalSeconds >= _durationSeconds) break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            int outSeconds = Math.Min(_cycleSeconds, SecondsRemaining(sw));
            ShowCountdownSeconds(outSeconds, sw);
        }
    }

    private void ShowCountdownSeconds(int secondsToShow, Stopwatch sessionStopwatch)
    {
        for (int s = secondsToShow; s >= 1; s--)
        {
            if (sessionStopwatch.Elapsed.TotalSeconds >= _durationSeconds) return;

            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
