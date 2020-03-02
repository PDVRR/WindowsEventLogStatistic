using System;
using System.Diagnostics;

namespace WindowsEventLogStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter log name: ");
                string eventLogName = Console.ReadLine();

                if (EventLog.SourceExists(eventLogName))
                {
                    EventLog eventLog = new EventLog(eventLogName);
                    EventLogStatistic eventLogStatistics = new EventLogStatistic(eventLog);
                    Console.WriteLine("{0,-20} {1,5} {2,25}\n", "Error type", "Count", "Last time generated");
                    foreach (var entry in eventLogStatistics.AllEntryTypes)
                    {
                        Console.WriteLine("{0,-20} {1,5} {2,20}", entry.Name, entry.Count, entry.LastEventTimeGenerated.ToLongTimeString());
                    }
                }
                else
                {
                    Console.WriteLine("Eventlog not exist");
                }
            }
        }
    }
}
