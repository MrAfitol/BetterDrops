namespace BetterDrops.Configs
{
    using System.ComponentModel;

    public class RandomDropConfigs
    {
        [Description("The minimum time that has to happen until the first random drop.")] 
        public ushort FirstRandomDropOffset { get; set; } = 120;
        
        [Description("Minimum time between random drops.")]
        public ushort MinRandomDropsInterval { get; set; } = 120;
        
        [Description("Maximum time between random drops.")]
        public ushort MaxRandomDropsInterval { get; set; } = 240;
        
        [Description("Random drop wave settings. (Here you can disable them)")]
        public DropConfig WaveSettings { get; set; } = new DropConfig();
    }
}