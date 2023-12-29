﻿using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    public class GlowSentry : ModNPC
    {

        public override void SetStaticDefaults()
        {
            //Main.npcFrameCount[NPC.type] = 7;
            NPCID.Sets.DontDoHardmodeScaling[Type] = true;
            NPCID.Sets.CantTakeLunchMoney[Type] = true;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 150;
            NPC.damage = 10;
            NPC.defense = 10;
            NPC.knockBackResist = 0f;
            NPC.value = Item.sellPrice(0, 0, 0, 0);
            NPC.aiStyle = -1;
            NPC.width = 40;
            NPC.height = 30;
            NPC.npcSlots = 0f;
            NPC.netAlways = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {

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