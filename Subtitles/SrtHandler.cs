using System;

namespace SrtTimeShift
{
    class SrtHandler
    {
        private enum State
        {
            Number,
            Duration,
            Text
        }

        public static void ShiftSrt(System.Collections.Generic.IEnumerable<SrtItem> srtItems, decimal multiplicator, int milliseconds)
        {
            foreach (var srtItem in srtItems)
            {
                srtItem.Shift(multiplicator, milliseconds);
            }
        }

        public static void ShiftSrt(System.Collections.Generic.IEnumerable<SrtItem> srtItems, int milliseconds)
        {
            foreach (var srtItem in srtItems)
            {
                srtItem.Shift(milliseconds);
            }
        }

        public static void ShiftSrtAfterFrom(System.Collections.Generic.IEnumerable<SrtItem> srtItems, uint fromMilliseconds, int milliseconds)
        {
            foreach (var srtItem in srtItems)
            {
                if (srtItem.From.TotalMilliseconds < fromMilliseconds) { continue; }
                srtItem.Shift(milliseconds);
            }
        }


        public static void ShiftSrtAfterNumber(System.Collections.Generic.IEnumerable<SrtItem> srtItems, uint number, int milliseconds)
        {
            foreach (var srtItem in srtItems)
            {
                if (srtItem.Number < number) { continue; }
                srtItem.Shift(milliseconds);
            }
        }


        public static void WriteSrt(System.Collections.Generic.IEnumerable<SrtItem> srtItems, System.IO.Stream stream)
        {
            using (var streamWriter = new System.IO.StreamWriter(stream, System.Text.Encoding.UTF8))
            {
                foreach (var srtItem in srtItems)
                {
                    streamWriter.WriteLine(srtItem);
                }

                streamWriter.Flush();
            }
        }


        public static System.Collections.Generic.IEnumerable<SrtItem> ReadSrt(System.IO.Stream stream)
        {
            using (var streamReader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
            {
                var srtItemList = new System.Collections.Generic.List<SrtItem>();

                State state = State.Number;
                uint number = 0;
                TimeSpan from = TimeSpan.MinValue;
                TimeSpan to = TimeSpan.MinValue;
                string text = string.Empty;

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        srtItemList.Add(new SrtItem(number, from, to, text));
                        text = string.Empty;
                        state = State.Number;
                        continue;
                    }

                    switch (state)
                    {
                        case State.Number:
                            number = uint.Parse(line);
                            state = State.Duration;
                            break;
                        case State.Duration:
                            string[] elements = line.Split(new string[] { " --> " }, StringSplitOptions.RemoveEmptyEntries);
                            from = TimeSpan.ParseExact(elements[0], @"hh\:mm\:ss\,fff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            to = TimeSpan.ParseExact(elements[1], @"hh\:mm\:ss\,fff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            state = State.Text;
                            break;
                        case State.Text:
                            text += string.Format("{0}\r\n", line);
                            break;
                    }
                }

                return srtItemList;
            }
        }
    }
}
