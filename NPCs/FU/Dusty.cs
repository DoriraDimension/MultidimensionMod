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
            NPC.damage = 50;
            NPC.defense = 5;
            NPC.lifeMax = 100;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCDeath6;
            NPC.DeathSound = SoundID.NPCDeath6;
            SpawnModBiomes = new int[1] { ModContent.GetInstance<FrozenUnderworld>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Piles of cooled ash given live by the potent magic of the Frozen Underworld. They have no mind or soul, they only fly around on the icy winds, exploding into ash on impact.")
            });
        }

        public override void AI()
        {
            NPC.TargetClosest(true);
            NPC.netUpdate = true;
            Player player = Main.player[NPC.target];

            Vector2 victor = new(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
            {
                float rotation = (float)Math.Atan2(victor.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), victor.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                NPC.velocity.X = (float)(Math.Cos(rotation) * 4) * -2;
                NPC.velocity.Y = (float)(Math.Sin(rotation) * 4) * -2;
            }
            NPC.rotation = NPC.velocity.ToRotation() + MathHelper.Pi;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
            }
            NPC.active = false;
        }

        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
            player.AddBuff(BuffID.Blackout, 300);

        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
            {
                return 0.01f;
            }
            return base.SpawnChance(spawnInfo);
        }
    }
}