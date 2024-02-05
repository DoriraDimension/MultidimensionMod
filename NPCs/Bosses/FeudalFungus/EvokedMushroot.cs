using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    public class EvokedMushroot : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0) { Hide = true };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 100;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 0, 0, 0);
            NPC.aiStyle = -1;
            NPC.width = 16;
            NPC.height = 18;
            NPC.npcSlots = 0f;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.AL().CantHurtDapper = true;
        }

        public override void AI()
        {
            int Feudal = NPC.FindFirstNPC(ModContent.NPCType<FeudalFungus>());
            if (Feudal <= 0)
            {
                NPC.active = false;
            }
            NPC.frameCounter++;
            int FrameSpeed = 6;
            if (NPC.frameCounter >= FrameSpeed)
            {
                NPC.frame.Y += 28;
                NPC.frameCounter = 0;
                if (NPC.frame.Y > (28 * 5))
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y = 100 * 5;
                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                //Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/RedMushGore1").Type, 1);
            }
        }
    }
}