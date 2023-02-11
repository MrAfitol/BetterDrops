namespace BetterDrops
{
    using System.ComponentModel;
    using Configs;

    public class Config
    {
        [Description("How long to wait before drops open themselves.")]
        public float AutoOpen { get; set; } = 15f;

        [Description("The configs of the MTF drop waves.")]
        public DropConfig MtfDropWave { get; set; } = new DropConfig();

        [Description("The configs of the Chaos drop waves.")]
        public DropConfig ChaosDropWave { get; set; } = new DropConfig();

        [Description("The configs of random drops")]
        public RandomDropConfigs RandomDrops { get; set; } = new RandomDropConfigs();
    }
}