using System;
using System.Collections.Generic;
using System.Linq;

namespace Subtitles.Gui
{
    internal class SrtModel
    {
        private List<SrtItem> srtItems = new List<SrtItem>();
        private uint numberSelected = 0;

        public event EventHandler SrtItemsLoaded;
        public event EventHandler SrtItemsShifted;
        public event EventHandler<uint> NumberSelectedChanged;

        public void AddSrtItem(SrtItem srtItem)
        {
            this.srtItems.Add(srtItem);
        }

        public void ClearSrtItems()
        {
            this.srtItems.Clear();
            SrtItemsLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void AddSrtItems(IEnumerable<SrtItem> srtItems)
        {
            this.srtItems.AddRange(srtItems);
            SrtItemsLoaded?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<SrtItem> SrtItems
        {
            get { return this.srtItems; }
        }

        public uint NumberSelected
        {
            get { return this.numberSelected; }
            set
            {
                this.numberSelected = value;

                NumberSelectedChanged?.Invoke(this, value);
            }
        }

        public void ShiftSrtItem(uint number, int duration)
        {
            SrtHandler.ShiftSrtBeforeNumber(srtItems.Where(i => i.Number == number), number, duration);

            SrtItemsShifted?.Invoke(this, EventArgs.Empty);
        }

        public void ShiftSrtItems(uint number, int duration, bool before)
        {
            if (before)
            {
                SrtHandler.ShiftSrtBeforeNumber(srtItems, number, duration);
            }
            else
            {
                SrtHandler.ShiftSrtAfterNumber(srtItems, number, duration);
            }

            SrtItemsShifted?.Invoke(this, EventArgs.Empty);   
        }

        public void Save(System.IO.Stream stream)
        {
            SrtHandler.WriteSrt(this.srtItems, stream);
        }
    }
}