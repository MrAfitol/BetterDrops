namespace BetterDrops.Commands
{
    using System;
    using Features.Extensions;
    using CommandSystem;
    using PlayerRoles;

    public class MtfCommand : ICommand
    {
        public static MtfCommand Instance { get; } = new MtfCommand();
        
        public string Command { get; } = "mtf";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Spawn a drop";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(PlayerPermissions.FacilityManagement))
            {
                response = "You don't have perms to do that!";
                return false;
            }

            Team.FoundationForces.SpawnDrops(BetterDrops.Instance.Config.MtfDropWave, BetterDrops.Instance.Config.MtfDropWave.NumberOfDrops);

            response = "Spawned!";
            return true;
        }
    }
}