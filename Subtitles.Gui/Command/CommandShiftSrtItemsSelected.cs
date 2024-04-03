namespace Subtitles.Gui.Command
{
    internal class CommandShiftSrtItemsSelected : ICommand
    {
        public SrtModel SrtModel { get; set; }
        public System.Collections.Generic.IEnumerable<uint> Numbers { get; set; }
        public int Duration { get; set; }

        public CommandShiftSrtItemsSelected(SrtModel srtModel, System.Collections.Generic.IEnumerable<uint> numbers, int duration)
        {
            this.SrtModel = srtModel;
            this.Numbers = new System.Collections.Generic.List<uint>(numbers);
            this.Duration = duration;
        }

        public void Redo()
        {
            this.SrtModel.ShiftSrtItems(Numbers, Duration);
        }

        public void Undo()
        {
            this.SrtModel.ShiftSrtItems(Numbers, -Duration);
        }
    }
}
