namespace Subtitles.Gui.Command
{
    internal class CommandShiftSrtItems : ICommand
    {
        public SrtModel SrtModel { get; set; }
        public uint Number { get; set; }
        public int Duration { get; set; }
        public bool Before {  get; set; }

        public CommandShiftSrtItems(SrtModel srtModel, uint number, int duration, bool before)
        {
            this.SrtModel = srtModel;
            this.Number = number;
            this.Duration = duration;
            this.Before = before;
        }

        public void Redo()
        {
            this.SrtModel.ShiftSrtItems(Number, Duration, Before);
        }

        public void Undo()
        {
            this.SrtModel.ShiftSrtItems(Number, -Duration, Before);
        }
    }
}
