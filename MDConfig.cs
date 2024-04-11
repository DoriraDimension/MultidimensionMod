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

        [DefaultValue(true)]

        public bool NPCItemSelling { get; set; }

        [DefaultValue(true)]
        public bool ALTitleCards { get; set; }


    }
}