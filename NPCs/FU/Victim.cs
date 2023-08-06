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
using Mono.Cecil;
using MultidimensionMod.Projectiles.Magic;
using System.Diagnostics;

namespace MultidimensionMod.NPCs.FU
{
	public class Victim : ModNPC
	{
		public int Quadshot;

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.width = 50;
			NPC.height = 65;
			NPC.damage = 55;
			NPC.defense = 10;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 0, 1, 40);
			NPC.knockBackResist = 0.30f;
			NPC.lavaImmune = false;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
			Banner = NPC.type;
            BannerItem = ModContent.ItemType<VictimBanner>();
            SpawnModBiomes = new int[1] { ModContent.GetInstance<FrozenUnderworld>().Type };
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Victim")
			});
		}

		public int spawn;
		public override void AI()
		{
			if (NPC.velocity.X > 0)
			{
				NPC.spriteDirection = 1;
				NPC.direction = 1;
			}
			else if (NPC.velocity.X < 0)
			{
				NPC.spriteDirection = -1;
				NPC.direction = -1;
			}
			NPC.TargetClosest(true);
			NPC.netUpdate = true;
			Player player = Main.player[NPC.target];

			BaseAI.AISkull(NPC, ref NPC.ai, false, 4, 300, .011f, .020f);
			float distanceToPlayer = Vector2.Distance(player.Center, NPC.Center);
			if (distanceToPlayer <= 700) //Only runs the code below if the enemy is close enough
			{
				Quadshot++;
				if (Quadshot >= 100)
				{
					SoundEngine.PlaySound(SoundID.Item20 with { Volume = 0.5f }, NPC.position);
                    Vector2 velocity = Vector2.Normalize(player.Center - NPC.Center) * 10f;
                    for (int i = 0; i < 3; i++)
                    {
                        int numProj = 3;
                        float rotation = MathHelper.ToRadians(14f);
                        Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)(i / (numProj - 1))));
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<VictimPellet>(), NPC.damage, 0f, Main.myPlayer);
                    }
                    Quadshot = 0;
				}
			}
			if (NPC.life <= NPC.lifeMax / 2 && !Main.hardMode) //Main.hardMode Will later be replaced with the Grudge downed bool
			{
				spawn++;
				if (spawn <= 1)
				{
                    SoundEngine.PlaySound(SoundID.NPCDeath6 with { Volume = .2f }, NPC.position);
                    NPC.active = false;
					Item.NewItem(NPC.GetSource_Loot(), NPC.position, NPC.Size, ModContent.ItemType<DevilSilk>(), 1);
					spawn = 2;
				}
			}
			else if (NPC.life <= NPC.lifeMax / 2)
			{
				spawn++;
				if (spawn <= 1)
				{
					Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.width / 5f);
					NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<VictimsEye>());
					Item.NewItem(NPC.GetSource_Loot(), NPC.position, NPC.Size, ModContent.ItemType<DevilSilk>(), 1);
					spawn = 2;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
			{
				return 0.20f;
			}
			return base.SpawnChance(spawnInfo);
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/VictimGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/VictimGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/VictimGore3").Type, 1);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.rotation = NPC.velocity.X * 0.05f;
			NPC.frameCounter += 1.0;
			if (NPC.frameCounter >= 7.0)
			{
				NPC.frameCounter = 0.0;
				NPC.frame.Y += frameHeight;
                if (NPC.life >= NPC.lifeMax / 2)
				{
                    if (NPC.frame.Y >= 3 * frameHeight)
                    {
                        NPC.frame.Y = 0 * frameHeight;
                    }
                }
                else if (NPC.life <= NPC.lifeMax / 2 && Main.hardMode)
				{
                    if (NPC.frame.Y >= 11 * frameHeight)
                    {
                        NPC.frame.Y = 5 * frameHeight;
                    }
                    if (NPC.frame.Y < 5 * frameHeight)
                    {
                        NPC.frame.Y = 5 * frameHeight;
                    }
                }
                if (NPC.life >= NPC.lifeMax / 2 && Quadshot >= 95)
                {
                    NPC.frame.Y = 4 * frameHeight;
                }
            }
		}
	}
}