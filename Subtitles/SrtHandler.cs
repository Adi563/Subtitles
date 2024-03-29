﻿using System;
using System.Linq;

namespace Subtitles
{
    public class SrtHandler
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

        public static void ShiftSrtBeforeNumber(System.Collections.Generic.IEnumerable<SrtItem> srtItems, uint number, int milliseconds)
        {
            ShiftSrt(srtItems.Where(i => i.Number <= number), milliseconds);
        }


        public static void ShiftSrtAfterNumber(System.Collections.Generic.IEnumerable<SrtItem> srtItems, uint number, int milliseconds)
        {
            ShiftSrt(srtItems.Where(i => i.Number >= number), milliseconds);
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

                string line = "";
                State state = State.Number;
                uint number = 0;
                TimeSpan from = TimeSpan.MinValue;
                TimeSpan to = TimeSpan.MinValue;
                string text = string.Empty;

                while (!streamReader.EndOfStream)
                {
                    String currentLine = streamReader.ReadLine();

                    //Prevent empty entries on multiple empty lines
                    if (string.IsNullOrEmpty(line) && string.IsNullOrEmpty(currentLine))
                    {
                        continue;
                    }
                    else { line = currentLine; }

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

                // In case no empty last line
                if (state == State.Text)
                {
                    srtItemList.Add(new SrtItem(number, from, to, text));
                }

                return srtItemList;
            }
        }
    }
}
