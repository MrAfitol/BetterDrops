namespace BetterDrops
{
    using Features;
    using LabApi.Events.Handlers;
    using LabApi.Features;
    using LabApi.Loader.Features.Plugins;
    using System;

    public class BetterDrops : Plugin<Config>
    {
        public static BetterDrops Instance { get; private set; }

        public override string Name => "BetterDrops";

        public override string Description => "Plugin to summon and spawn drops.";

        public override string Author => "Jesus-QC, update by MrAfitol";

        public override Version Version => new Version(1, 1, 0);

        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;

        public EventsHandler EventHandler { get; private set; }

        public override void Enable()
        {
            Instance = this;
            EventHandler = new EventsHandler();
            ServerEvents.RoundRestarted += EventHandler.OnRoundRestarted;
            ServerEvents.RoundStarted += EventHandler.OnRoundStarted;
            ServerEvents.WaveRespawning += EventHandler.OnRespawningTeam;
        }

        public override void Disable()
        {
            ServerEvents.RoundRestarted -= EventHandler.OnRoundRestarted;
            ServerEvents.RoundStarted -= EventHandler.OnRoundStarted;
            ServerEvents.WaveRespawning -= EventHandler.OnRespawningTeam;
            EventHandler = null;
            Instance = null;
        }
    }
}