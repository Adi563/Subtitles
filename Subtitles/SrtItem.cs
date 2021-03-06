﻿using System;

namespace Subtitles
{
    public class SrtItem
    {
        public uint Number { get; set; }
        public TimeSpan From { get; internal set; }
        public TimeSpan To { get; internal set; }
        public string Text { get; set; }

        public SrtItem(uint number, TimeSpan from, TimeSpan to, string text)
        {
            Number = number;
            From = from;
            To = to;
            Text = text;
        }

        public void Shift(decimal multiplicator, int milliseconds)
        {
            From = new TimeSpan((long)(From.Ticks * multiplicator)) + new TimeSpan(0, 0, 0, 0, milliseconds);
            To = new TimeSpan((long)(To.Ticks * multiplicator)) + new TimeSpan(0, 0, 0, 0, milliseconds);
        }

        public void Shift(int milliseconds)
        {
            From = From.Add(new TimeSpan(0, 0, 0, 0, milliseconds));
            To = To.Add(new TimeSpan(0, 0, 0, 0, milliseconds));
        }

        public override string ToString()
        {
            return string.Format("{0}\r\n{1:hh\\:mm\\:ss\\,fff} --> {2:hh\\:mm\\:ss\\,fff}\r\n{3}", Number, From, To, Text);
        }
    }
}
