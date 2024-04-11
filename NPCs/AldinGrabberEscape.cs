using MultidimensionMod.Common.Systems;
using MultidimensionMod.Items.Permabuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.Audio;
using MultidimensionMod.Base;
using Terraria.GameContent.Bestiary;
using System;
using MultidimensionMod.Items.Materials;
using Terraria.GameContent.ItemDropRules;

namespace MultidimensionMod.NPCs
{
    public class AldinGrabberEscape : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 10;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 86;
            NPC.lifeMax = 1;
            NPC.dontTakeDamage = true;
            NPC.noGravity = true;
        }

        public int AldinTimer = 0;
        public override void AI()
        {
            Player player = Main.LocalPlayer;
        }

        public override void FindFrame(int frameHeight)
        {
            if (++NPC.frameCounter >= 5)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y > 9 * frameHeight)
                {
                    NPC.active = false;
                    Item.NewItem(NPC.GetSource_Loot(), NPC.position, NPC.Size, ModContent.ItemType<Mushrune>(), 1);
                }
            }
        }
    }
}