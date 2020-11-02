using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorThings.Core
{
    public class DateTimeRange
    {
        public const string TimeFormat = "yyyy-MM-ddTHH\\:mm\\:ss.fffZ";

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool HasTime => Start.HasValue || End.HasValue;
        public bool HasRange => Start.HasValue && End.HasValue;

        public DateTimeRange(){}

        public DateTimeRange(DateTime start)
        {
            Start = start;
        }

        public DateTimeRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTimeRange(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var split = input.Split('/');
            Start = DateTime.Parse(split[0]);

            if (split.Length >= 2)
            {
                End = DateTime.Parse(split[1]);
            }
        }

        public override string ToString()
        {
            if (!HasTime)
            {
                return "";
            }

            var timeParts = new List<string>();
            if (Start.HasValue)
            {
                timeParts.Add(Start.Value.ToUniversalTime().ToString(TimeFormat));
            }

            if (End.HasValue)
            {
                timeParts.Add(End.Value.ToUniversalTime().ToString(TimeFormat));
            }

            return timeParts.Aggregate((x, y) => $"{x}/{y}");
        }
    }
}
