using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Base;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.FU
{
    public class Dusty : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 32;
            NPC.damage = 10;
            NPC.defense = 5;
            NPC.lifeMax = 100;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            Vector2 velocity = player.Center - NPC.Center;
            velocity.Normalize();
            NPC.velocity = velocity * 10f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            // Create an explosion effect when the enemy is hit
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
            }

            // Remove the enemy from the game
            NPC.active = false;
        }
    }
}