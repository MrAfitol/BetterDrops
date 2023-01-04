namespace BetterDrops
{
    using Features;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using PluginAPI.Events;

    public class BetterDrops
    {
        public static BetterDrops Instance { get; private set; }

        [PluginConfig("configs/better_drops.yml")]
        public Config Config;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("BetterDrops", "1.0.1", "Plugin to summon and spawn drops.", "Jesus-QC, update by MrAfitol")]
        public void LoadPlugin()
        {
            Instance = this;
            EventManager.RegisterEvents<EventHandler>(this);

            var handler = PluginHandler.Get(this);
            handler.SaveConfig(this, nameof(Config));
        }
    }
}