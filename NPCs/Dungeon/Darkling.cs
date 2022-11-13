using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Dungeon
{
	public class Darkling : ModNPC
	{
		public int Shootsies;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkling");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 46;
			NPC.height = 46;
			NPC.damage = 45;
			NPC.defense = 3;
			NPC.lifeMax = 120;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 0, 1, 40);
			NPC.knockBackResist = 0.6f;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = -1;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<DarklingBanner>();
		}

		public override void AI()
        {
			NPC.TargetClosest(true);
			NPC.netUpdate = true;
			Player player = Main.player[NPC.target];

			Vector2 victor = new(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
			{
				float rotation = (float)Math.Atan2(victor.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), victor.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
				NPC.velocity.X = (float)(Math.Cos(rotation) * 4) * -1;
				NPC.velocity.Y = (float)(Math.Sin(rotation) * 4) * -1;
			}
			NPC.rotation = NPC.velocity.ToRotation() + MathHelper.Pi;

			float distanceToPlayer = Vector2.Distance(player.Center, NPC.Center);
			if (distanceToPlayer < 150) //stops the NPC from moving if it is close to the player
            {
				NPC.velocity.X = 0;
				NPC.velocity.Y = 0;
            }
			if (NPC.life < NPC.lifeMax) //Executes this code only if the enemy lost HP
            {
				Shootsies++;
				if (Shootsies >= 200)
				{
					SoundEngine.PlaySound(SoundID.DD2_SonicBoomBladeSlash with { Volume = 0.4f }, NPC.position);
					Vector2 velocity = Vector2.Normalize(player.Center - NPC.Center) * 10f;
					Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, velocity, ModContent.ProjectileType<DarklingShot>(), (int)((double)((float)NPC.damage) * 1.5), 0f, Main.myPlayer);
					Shootsies = 0;
				}
			}

			if (Main.dayTime && !player.ZoneDungeon) //despawns the enemy during daytime unless the player is inside the dungeon
			{
				SoundEngine.PlaySound(SoundID.NPCDeath6 with { Volume = .2f }, NPC.position);
				NPC.active = false;
				for (int i = 0; i < 5; i++) //spawns half the amount of dust than when the enemy gets hit
				{
					int dustType = Main.rand.Next(27, 27);
					int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Dungeon.Chance * 0.1f;
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
		    NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DarkMatterClump>(), 1, 1, 3));
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(27, 27);
				int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 1.0;
			if (NPC.frameCounter >= 5.0)
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