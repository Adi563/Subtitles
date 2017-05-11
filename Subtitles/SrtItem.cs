using System;

namespace SrtTimeShift
{
    class SrtItem
    {
        public uint Number { get; set; }
        public TimeSpan From { get; internal set; }
        public TimeSpan To { get; internal set; }
        public string Text { get; }

        public SrtItem(uint number, TimeSpan from, TimeSpan to, string text)
        {
            Number = number;
            From = from;
            To = to;
            Text = text;
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
