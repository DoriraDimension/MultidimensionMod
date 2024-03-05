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

namespace MultidimensionMod.NPCs.Madness
{
    public class MadnessBat2 : ModNPC
    {
        int Ambush = 1;
        int AmbushTimer = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 8;
        }
        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 40;
            NPC.damage = 50;
            NPC.defense = 30;
            NPC.lifeMax = 550;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 0.5f;
            NPC.value = Item.sellPrice(0, 0, 8, 30);
            NPC.lavaImmune = true;
            NPC.netAlways = true;
            NPC.aiStyle = 14;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<MadnessBat2Banner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<MadnessMoon>().Type };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.MadnessGazer")
            });
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            if (player.Center.X > NPC.Center.X)
            {
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.spriteDirection = 1;
            }
            BaseAI.AIFlier(NPC, ref NPC.ai, true, 0.1f, 0.04f, 4f, 1.5f, true, 300);
            if (Ambush == 1)
            {
                if (AmbushTimer == 120)
                {
                    Vector2 victor = new(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
                    {
                        SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/MadnessScream"), NPC.position);
                        float rotation = (float)Math.Atan2(victor.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), victor.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                        NPC.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
                        NPC.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
                        for (int m = 0; m < 20; m++)
                        {
                            int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<MadnessY>(), 0f, 0f, 100, Color.White, 1.6f);
                            Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                            Main.dust[dustID].noLight = false;
                            Main.dust[dustID].noGravity = true;
                        }
                    }
                    NPC.netUpdate = true;
                }
                if (AmbushTimer == 160)
                {
                    Vector2 victor = new(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
                    {
                        SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/MadnessScream"), NPC.position);
                        float rotation = (float)Math.Atan2(victor.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), victor.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                        NPC.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
                        NPC.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
                        for (int m = 0; m < 20; m++)
                        {
                            int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<MadnessY>(), 0f, 0f, 100, Color.White, 1.6f);
                            Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                            Main.dust[dustID].noLight = false;
                            Main.dust[dustID].noGravity = true;
                        }
                    }
                    NPC.netUpdate = true;
                }
                if (AmbushTimer == 200)
                {
                    Vector2 victor = new(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
                    {
                        SoundEngine.PlaySound(new("MultidimensionMod/Sounds/NPC/MadnessScream"), NPC.position);
                        float rotation = (float)Math.Atan2(victor.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), victor.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                        NPC.velocity.X = (float)(Math.Cos(rotation) * 10) * -1;
                        NPC.velocity.Y = (float)(Math.Sin(rotation) * 10) * -1;
                        for (int m = 0; m < 20; m++)
                        {
                            int dustID = Dust.NewDust(new Vector2(NPC.Center.X - 1, NPC.Center.Y - 1), 2, 2, ModContent.DustType<MadnessY>(), 0f, 0f, 100, Color.White, 1.6f);
                            Main.dust[dustID].velocity = BaseUtility.RotateVector(default, new Vector2(6f, 0f), m / (float)20 * 6.28f);
                            Main.dust[dustID].noLight = false;
                            Main.dust[dustID].noGravity = true;
                        }
                    }
                    NPC.netUpdate = true;
                    AmbushTimer = 0;
                }
                AmbushTimer++;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome(ModContent.GetInstance<MadnessMoon>()) && Main.hardMode)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.12f;
            }
            return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.rotation = NPC.velocity.X * 0.05f;
            NPC.frameCounter += 1.0;
            if (NPC.frameCounter >= 7.0)
            {
                NPC.frameCounter = 0.0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int k = 0; k < 3; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, Main.rand.NextBool(2) ? ModContent.DustType<MadnessP>() : ModContent.DustType<MadnessB>(), hit.HitDirection, -1f, 0);
            }
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 15; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, Main.rand.NextBool(2) ? ModContent.DustType<MadnessP>() : ModContent.DustType<MadnessB>(), hit.HitDirection, -1f, 0);
                }
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GazerGore1").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GazerGore2").Type, 1);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GazerGore3").Type, 1);
            }
        }

        public override void ModifyNPCLoot(NPCLoot NPCloot)
        {
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<MadnessFragment>(), 3, 1, 2));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<Blight2>(), 20));
            NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<ShadeEye>(), 100));
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Debuffs.Madness>(), 300);
        }
    }
}