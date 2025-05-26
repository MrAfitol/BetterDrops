namespace BetterDrops.Commands
{
    using CommandSystem;
    using System;

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class BetterDropsCommand : ParentCommand
    {
        public BetterDropsCommand() => LoadGeneratedCommands();

        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(SpawnCommand.Instance);
            RegisterCommand(ChaosCommand.Instance);
            RegisterCommand(MtfCommand.Instance);
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Please, specify a valid subcommand! Available ones: spawn, mtf, chaos";
            return false;
        }

        public override string Command { get; } = "BetterDrops";
        public override string[] Aliases { get; } = Array.Empty<string>();
        public override string Description { get; } = "BetterDrops parent command.";
    }
}