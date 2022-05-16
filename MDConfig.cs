using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace MultidimensionMod
{
    public class MDConfig : ModConfig
    {
        public static MDConfig Instance;

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Town NPCs Sell New Items")]
        [DefaultValue(true)]
        [Tooltip("Adds new items to Town NPCs shops.")]

        public bool DisableNPCItemSelling { get; set; }


    }
}