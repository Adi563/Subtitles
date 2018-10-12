using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SrtTimeShift
{
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShiftWithMultiplierSrt()
        {
            const string filePath = @"C:\Users\Adrian\Downloads\The Last Unicorn 1080p.srt";
            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(filePath, System.IO.FileMode.Open));
            SrtHandler.ShiftSrt(srtItems, 23.976024m/24.000384m, 0);
            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(filePath, System.IO.FileMode.Create));
        }

        [TestMethod]
        public void ShiftSrt()
        {
            const string filePath = @"C:\Users\Adrian\Downloads\Rick and Morty S01E04  M. Night Shaym-Aliens! (Uncensored) (1920x1080) [Phr0stY].srt";
            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(filePath, System.IO.FileMode.Open));
            SrtHandler.ShiftSrt(srtItems, 1000);
            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(filePath, System.IO.FileMode.Create));
        }

        [TestMethod]
        public void ShiftSrtFrom()
        {
            uint seconds = 75*60+45;
            int shift = -1800;

            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(@"C:\Users\Adrian\Downloads\Expanse\S01E09E10.srt", System.IO.FileMode.Open));
            SrtHandler.ShiftSrtAfterFrom(srtItems, seconds * 1000, shift);
            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(@"C:\Users\Adrian\Downloads\Expanse\The.Expanse.S01E09E10.Anubis-Leviathan.erwacht.German.Dubbed.DD51.DL.2160p.AmazonUHD.x264-NIMA4K.srt", System.IO.FileMode.Create));
        }

        [TestMethod]
        public void ShiftSrtNumber()
        {
            const string filePath = @"C:\Users\Adrian\Downloads\jack\CD5\S03E07 Jack and the Creature.srt";
            const uint number = 919;

            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(filePath, System.IO.FileMode.Open));
            SrtHandler.ShiftSrtAfterNumber(srtItems, number, 0 * 60 * 1000 + 1 * 1000);
            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(filePath, System.IO.FileMode.Create));
        }

        [TestMethod]
        public void SplitSrt()
        {
            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(@"C:\Users\Adrian\Downloads\jack\CD5\CD5.srt", System.IO.FileMode.Open));

            uint groupNumber = 1;
            var from = TimeSpan.MinValue;
            var group = srtItems.GroupBy(f =>
            {
                if (from < f.From)
                {
                    from = f.From;
                    return groupNumber;
                }
                else
                {
                    from = TimeSpan.MinValue;
                    return ++groupNumber;
                }
            });

            foreach (var g in group)
            {
                var srtItemsFiltered = g.Where(s => s.From > new TimeSpan(0, 0, 0, 40, 0));

                SrtHandler.WriteSrt(srtItemsFiltered, new System.IO.FileStream(string.Format(@"C:\Users\Adrian\Downloads\jack\CD5\Jack{0}.srt", g.Key), System.IO.FileMode.Create));
            }
        }

        [TestMethod]
        public void ReplacePointsWithCommas()
        {
            const string filePath = @"Z:\Shared\Videos\Samurai Jack\S03\S03E01 Chicken Jack.srt";
            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(filePath, System.IO.FileMode.Open));

            srtItems.ToList().ForEach(s =>
            {
                if (!s.Text.Contains('.')) { return; }

                var indexOfPoint = s.Text.IndexOf('.');

                if (s.Text.Length < indexOfPoint + 2) { return; }

                var indexOfFirstLetterOfNextSentence = s.Text[indexOfPoint + 1] == '\r' && (s.Text.Length > indexOfPoint + 3) ? indexOfPoint + 3 : indexOfPoint + 2;
                var firstLetterOfNextSentence = s.Text[indexOfFirstLetterOfNextSentence];
                if (!(firstLetterOfNextSentence >= 97 && firstLetterOfNextSentence <= 122)) { return; }
                
                var textFixed = s.Text.ToCharArray();
                textFixed[indexOfPoint] = ',';
                var stringFixed = new string(textFixed);

                System.Diagnostics.Debug.WriteLine(s.Text);
                System.Diagnostics.Debug.WriteLine(stringFixed);

                s.Text = stringFixed;
            });

            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(filePath, System.IO.FileMode.Create));
        }

        [TestMethod]
        public void DateDifference()
        {
            var dateFrom = System.DateTime.ParseExact("01:09:18.76", "hh:mm:ss.ff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            var dateTo = System.DateTime.ParseExact("01:31:31.76", "hh:mm:ss.ff", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            var diff = dateTo - dateFrom;
            var duration = $"{diff.Hours:D2}:{diff.Minutes:D2}:{diff.Seconds:D2}.{diff.Milliseconds:D2}";
        }
    }
}