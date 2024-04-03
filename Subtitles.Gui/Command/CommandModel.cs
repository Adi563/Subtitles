using System.Linq;

namespace Subtitles.Gui.Command
{
    internal class CommandModel : ICommand
    {
        private System.Collections.Generic.List<ICommand> commands = new System.Collections.Generic.List<ICommand>();

        private ICommand lastCommand;

        public void Redo()
        {
            if (commands.LastOrDefault() == lastCommand) { return; }

            var nextCommand = commands.ElementAt(commands.IndexOf(lastCommand) + 1);

            nextCommand.Redo();

            lastCommand = nextCommand;
        }

        public void Undo()
        {
            if (null == lastCommand) { return; }

            lastCommand.Undo();

            lastCommand = lastCommand == commands.First() ? null : commands.ElementAt(commands.IndexOf(lastCommand) - 1);
        }

        public void AddCommmand(ICommand command)
        {
            this.commands.Add(command);
        }
    }
}
