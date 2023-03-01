using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Biomes;
using MultidimensionMod.Items.Materials;
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
	public class Ashton : ModNPC
	{
		public int Blargh;

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.width = 54;
			NPC.height = 110;
			NPC.damage = 60;
			NPC.defense = 10;
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
			SpawnModBiomes = new int[1] { ModContent.GetInstance<FrozenUnderworld>().Type };
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				new FlavorTextBestiaryInfoElement("A weird creature that roams the frozen section of the underworld, hovering as if hanging on strings. They spit burning cold ash at everything that doesn't belong.")
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
			}

			float distanceToPlayer = Vector2.Distance(player.Center, NPC.Center);
			if (distanceToPlayer <= 150) //Only runs the code below if the enemy is close enough
			{
				Blargh++;
				if (Blargh >= 100)
				{
					SoundEngine.PlaySound(SoundID.DD2_SonicBoomBladeSlash with { Volume = 0.4f }, NPC.position);
					Vector2 velocity = Vector2.Normalize(player.Center - NPC.Center) * 10f;
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, ModContent.ProjectileType<Dungeon.DarklingShot>(), (int)((double)((float)NPC.damage) * 1.5), 0f, Main.myPlayer);
					Blargh = 0;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.InModBiome(ModContent.GetInstance<FrozenUnderworld>()))
			{
				return SpawnCondition.Underworld.Chance * 0.10f;
			}
			return base.SpawnChance(spawnInfo);
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<AbyssalHellstoneBar>(), 1, 1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/AshtonGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/AshtonGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/AshtonGore3").Type, 1);
			}
		}

		public override void FindFrame(int frameHeight)
		{
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
	}
}