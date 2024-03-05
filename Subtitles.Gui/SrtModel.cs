using System;
using System.Collections.Generic;
using System.Linq;

namespace Subtitles.Gui
{
    internal class SrtModel
    {
        List<SrtItem> srtItems = new List<SrtItem>();

        public event EventHandler SrtItemsLoaded;
        public event EventHandler SrtItemsShifted;

        public void AddSrtItem(SrtItem srtItem)
        {
            this.srtItems.Add(srtItem);
        }

        public void AddSrtItems(IEnumerable<SrtItem> srtItems)
        {
            this.srtItems.AddRange(srtItems);
            SrtItemsLoaded.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<SrtItem> SrtItems
        {
            get { return this.srtItems; }
        }

        public void ShiftSrtItems(uint number, int duration)
        {
            SrtHandler.ShiftSrtAfterNumber(srtItems, number, duration);
            SrtItemsShifted.Invoke(this, EventArgs.Empty);   
        }
    }
}