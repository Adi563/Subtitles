namespace Subtitles.Gui.Command
{
    internal interface ICommand
    {
        void Redo();
        void Undo();
    }
}
