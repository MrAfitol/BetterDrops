namespace BetterDrops.Commands
{
    using CommandSystem;
    using Features.Extensions;
    using PlayerRoles;
    using System;

    public class ChaosCommand : ICommand
    {
        public static ChaosCommand Instance { get; } = new ChaosCommand();

        public string Command { get; } = "chaos";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Spawn a drop";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.FacilityManagement))
            {
                response = "You don't have perms to do that!";
                return false;
            }

            Team.ChaosInsurgency.SpawnDrops(BetterDrops.Instance.Config.ChaosDropWave, BetterDrops.Instance.Config.ChaosDropWave.NumberOfDrops);

            response = "Spawned!";
            return true;
        }
    }
}