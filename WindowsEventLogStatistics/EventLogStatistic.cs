using System.Collections.Generic;
using System.Diagnostics;

namespace WindowsEventLogStatistic
{
    class EventLogStatistic
    {
        EventLog eventLog;
        public EntryType ErrorType { get; } = new EntryType("Error");
        public EntryType FailureAuditType { get; } = new EntryType("Failure audit");
        public EntryType InformationType { get; } = new EntryType("Information");
        public EntryType SuccessAuditType { get; } = new EntryType("Success audit");
        public EntryType WarningType { get; } = new EntryType("Warning");
        public List<EntryType> AllEntryTypes { get; } = new List<EntryType>();

        public EventLogStatistic(EventLog eventLog)
        {
            this.eventLog = eventLog;
            AllEntryTypes.Add(ErrorType);
            AllEntryTypes.Add(FailureAuditType);
            AllEntryTypes.Add(InformationType);
            AllEntryTypes.Add(SuccessAuditType);
            AllEntryTypes.Add(WarningType);
            ParseEventLog();
        }

        private void ParseEventLog()
        {
            foreach (EventLogEntry entry in eventLog.Entries)
            {
                CheckEventType(entry);
            }
        }

        private void CheckEventType(EventLogEntry eventLogEntry)
        {
            switch (eventLogEntry.EntryType)
            {
                case EventLogEntryType.Error:
                    ErrorType.Count++;
                    ErrorType.LastEventTimeGenerated = eventLogEntry.TimeGenerated;
                    break;
                case EventLogEntryType.FailureAudit:
                    FailureAuditType.Count++;
                    FailureAuditType.LastEventTimeGenerated = eventLogEntry.TimeGenerated;
                    break;
                case EventLogEntryType.Information:
                    InformationType.Count++;
                    InformationType.LastEventTimeGenerated = eventLogEntry.TimeGenerated;
                    break;
                case EventLogEntryType.SuccessAudit:
                    SuccessAuditType.Count++;
                    SuccessAuditType.LastEventTimeGenerated = eventLogEntry.TimeGenerated;
                    break;
                case EventLogEntryType.Warning:
                    WarningType.Count++;
                    WarningType.LastEventTimeGenerated = eventLogEntry.TimeGenerated;
                    break;
            }
        }
        

    }
}
