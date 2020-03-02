using System;

namespace WindowsEventLogStatistic
{
    class EntryType
    {
        public string Name { get; set; }
        public int Count { get; set; } = 0;
        public DateTime LastEventTimeGenerated { get; set; }

        public EntryType(string typeName)
        {
            Name = typeName;
        }
    }
}
