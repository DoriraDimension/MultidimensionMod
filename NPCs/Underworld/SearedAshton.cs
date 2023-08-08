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

namespace MultidimensionMod.NPCs.Underworld
{
	public class SearedAshton : ModNPC
	{
		public int Blargh;

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 54;
			NPC.height = 110;
			NPC.damage = 65;
			NPC.defense = 20;
			NPC.lifeMax = 500;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 0, 1, 40);
			NPC.knockBackResist = 0.0f;
			NPC.lavaImmune = false;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<SearedAshtonBanner>();
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
				new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.SearedAshton")
			});
		}

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
			if (distanceToPlayer <= 250) //Only runs the code below if the enemy is close enough
			{
				Blargh++;
				if (Blargh >= 180)
				{
					SoundEngine.PlaySound(SoundID.NPCDeath13 with { Volume = 0.5f }, NPC.position);
					Vector2 velocity = Vector2.Normalize(player.Center - NPC.Center) * 10f;
					for (int i = 0; i < 5; i++)
					{
						Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                        perturbedSpeed *= 1f - Main.rand.NextFloat(0.3f);
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, perturbedSpeed, ModContent.ProjectileType<BurningAshCloud>(), (int)((double)((float)NPC.damage) * 1.5), 0f, Main.myPlayer);
					}
					Blargh = 0;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.hardMode)
			{
				return SpawnCondition.Underworld.Chance * 0.10f;
			}
			return 0f;
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/SearedAshtonGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/SearedAshtonGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/SearedAshtonGore3").Type, 1);
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
				if (NPC.frame.Y >= 4 * frameHeight)
				{
					NPC.frame.Y = 0;
				}
			}
            if (Blargh >= 160)
            {
                NPC.frame.Y = 5 * frameHeight;
            }
        }
	}
}