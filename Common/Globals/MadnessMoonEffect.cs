using MultidimensionMod.Biomes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using MultidimensionMod.NPCs.Madness;

namespace MultidimensionMod.Common.Globals
{
    public class MadnessMoonEffect : ModSceneEffect
    {
        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Madness");
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
    public class MadnessBrainSpawnSystem : ModSystem
    {
        public bool CanBrainSpawn=true;
        public override void PostUpdateNPCs()
        {
            if(!MDWorld.MadnessMoon)
            {
                CanBrainSpawn=true;
            }
            else
            {
                for(int i=0; i < Main.maxNPCs;i++)
                {
                    NPC n = Main.npc[i];
                    if(n.active && n.type == ModContent.NPCType<AMindFromBeyond>())
                        CanBrainSpawn=false;
                }
            }
        }
    }
}