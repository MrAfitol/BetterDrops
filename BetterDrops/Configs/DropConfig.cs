namespace BetterDrops.Configs
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class DropConfig
    {
        [Description("Is the drop wave enabled.")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("Number of drops in the spawn wave.")]
        public uint NumberOfDrops { get; set; } = 5;

        [Description("Items per drop, I suggest low values, if you do stupid things with this config it is your fault.")] 
        public uint ItemsPerDrop { get; set; } = 1;
        
        [Description("Drop color. (It accepts Random or hex values like '#ffffff')")]
        public string Color { get; set; } = "Random";

        [Description("Cassie message on spawn drop. (Leave blank to disable)")]
        public string Cassie { get; set; } = "pitch_0.2 .g4... pitch_1 Supply jam_020_2 has been arrival";

        [Description("Will the gun have a full ammo?")]
        public bool FillMaxAmmo { get; set; } = true;

        [Description("Will the gun have a random attachments?")]
        public bool RandomAttachments { get; set; } = true;

        [Description("The possible items inside the drop")]
        public List<ItemType> PossibleItems { get; set; } = new List<ItemType> {ItemType.Adrenaline, ItemType.Coin, ItemType.Medkit, ItemType.GrenadeFlash, ItemType.GrenadeHE, ItemType.Radio, ItemType.Painkillers, ItemType.ArmorCombat, ItemType.ArmorHeavy, ItemType.ArmorLight, ItemType.GunRevolver, ItemType.GunShotgun, ItemType.GunAK, ItemType.GunCOM15, ItemType.GunFSP9, ItemType.GunE11SR};
    }
}