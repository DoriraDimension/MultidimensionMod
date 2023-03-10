using MultidimensionMod.Biomes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;

namespace MultidimensionMod.Common.Globals
{
    public class MadnessMoonEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot("AAMod/Sounds/Music/DreadMoon");
        public override SceneEffectPriority Priority => SceneEffectPriority.Event;
        public override void SpecialVisuals(Terraria.Player player, bool isActive)
        {
            if (isActive)
            {
                player.ManageSpecialBiomeVisuals("MultidimensionMod:Madness", player.InModBiome(ModContent.GetInstance<MadnessMoon>()));
            }
        }
        public override bool IsSceneEffectActive(Terraria.Player player)
        {
            bool MadnessMoonActive = Main.LocalPlayer.InModBiome(ModContent.GetInstance<MadnessMoon>());

            return MadnessMoonActive && MDWorld.MadnessMoon;
        }
    }
}