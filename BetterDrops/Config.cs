namespace BetterDrops
{
    using System.ComponentModel;
    using Configs;

    public class Config
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The configs of the MTF drop waves.")]
        public DropConfig MtfDropWave { get; set; } = new DropConfig();
        [Description("The configs of the Chaos drop waves.")]
        public DropConfig ChaosDropWave { get; set; } = new DropConfig();

        [Description("The configs of random drops")]
        public RandomDropConfigs RandomDrops { get; set; } = new RandomDropConfigs();
    }
}