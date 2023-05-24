using MultidimensionMod.Common.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MultidimensionMod.Biomes
{
    public class MadnessMoon : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.Event;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Madness");

        public override bool IsBiomeActive(Player player)
        {
            return (player.ZoneSkyHeight || player.ZoneOverworldHeight) && MDWorld.MadnessMoon;
        }

        public override string BestiaryIcon => "MultidimensionMod/Biomes/MadnessIcon";


        public override Color? BackgroundColor => base.BackgroundColor;

        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (isActive)
            {
                if (Main.dayTime)
                {
                    player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", false);
                }
                SkyManager.Instance.Activate("MadnessMoonSky");
            }
        }

        public override void OnLeave(Player player)
        {
            SkyManager.Instance.Deactivate("MadnessMoonSky");
            player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", false);
        }
    }
}
