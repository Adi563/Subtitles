using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SrtTimeShift
{
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShiftSrt()
        {
            const string filePath = @"C:\Users\Adrian\Downloads\jack\CD5\S03E07 Jack and the Creature.srt";
            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(filePath, System.IO.FileMode.Open));
            SrtHandler.ShiftSrt(srtItems, -79500);
            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(filePath, System.IO.FileMode.Create));
        }

        [TestMethod]
        public void ShiftSrtFrom()
        {
            ushort season = 4;
            ushort episode = 22;
            uint seconds = 77;

            var srtItems = SrtHandler.ReadSrt(new System.IO.FileStream(string.Format(@"Z:\Shared\Videos\Star Trek\Enterprise\S{0:D2}\S{0:D2}E{1:D2}.srt.org", season, episode), System.IO.FileMode.Open));
            SrtHandler.ShiftSrtAfterFrom(srtItems, seconds * 1000, -79500);
            SrtHandler.WriteSrt(srtItems, new System.IO.FileStream(string.Format(@"Z:\Shared\Videos\Star Trek\Enterprise\S{0:D2}\S{0:D2}E{1:D2}.srt", season, episode), System.IO.FileMode.Create));
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
    }
}