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

        [Header("$Mods.MultidimensionMod.Configs.Headers.ConfigVisual")]
        [DefaultValue(false)]
        public bool ScreenshakeDisable { get; set; }

        [Header("$Mods.MultidimensionMod.Configs.Headers.ConfigUI")]
        [DefaultValue(true)]
        public bool ALTitleCards { get; set; }

        [Header("$Mods.MultidimensionMod.Configs.Headers.ConfigGameplay")]
        [DefaultValue(true)]
        public bool NPCItemSelling { get; set; }


    }
}