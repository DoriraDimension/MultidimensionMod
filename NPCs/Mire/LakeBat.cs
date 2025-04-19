using MultidimensionMod.Items.Materials;
using MultidimensionMod.Dusts;
using MultidimensionMod.Biomes;
using MultidimensionMod.Base;
using MultidimensionMod.Items;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;
using MultidimensionMod.Items.Placeables.Banners;

namespace MultidimensionMod.NPCs.Mire
{
    public class LakeBat : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5;
        }
        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 35;
            NPC.damage = 18;
            NPC.defense = 6;
            NPC.lifeMax = 25;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 0.7f;
            NPC.value = Item.sellPrice(0, 0, 8, 30);
            NPC.netAlways = true;
            NPC.aiStyle = 14;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            //Banner = NPC.type;
            //BannerItem = ModContent.ItemType<LakeBatBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<TheLakeDepths>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.LilTerror")
            });
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            if (player.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.spriteDirection = -1;
            }
            BaseAI.AIFlier(NPC, ref NPC.ai, true, 0.1f, 0.04f, 4f, 1.5f, true, 300);
        }
        /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
        }*/

        public override void FindFrame(int frameHeight)
        {
            NPC.rotation = NPC.velocity.X * 0.05f;
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 6.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= (NPC.frame.Y = frameHeight * 3))
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, hit.HitDirection, -1f, 0);
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {

        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(BuffID.Slow, 180);
        }
    }
}