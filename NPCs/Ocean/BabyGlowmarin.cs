using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Critters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Ocean
{
	internal class BabyGlowmarin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baby Glowmarin");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Shark];
			Main.npcCatchable[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.width = 34;
			npc.height = 22;
			npc.aiStyle = 16;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 5;
			npc.HitSound = SoundID.NPCHit51;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.CloneDefaults(NPCID.Goldfish);
			npc.catchItem = (short)ModContent.ItemType<BabyGlowmarinItem>();
			npc.friendly = true; 
			aiType = NPCID.Goldfish;
			animationType = NPCID.Shark;
			banner = npc.type;
			bannerItem = ModContent.ItemType<BabyGlowmarinBanner>();
		}

		public override bool? CanBeHitByItem(Player player, Item item)
		{
			return true;
		}

		public override bool? CanBeHitByProjectile(Projectile projectile)
		{
			return true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerSafe && Main.hardMode && NPC.downedMechBossAny ? SpawnCondition.OceanMonster.Chance * 0.30f : 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int i = 0; i < 6; i++)
				{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 200, 2 * hitDirection, -2f);
					if (Main.rand.NextBool(2))
					{
						Main.dust[dust].noGravity = true;
						Main.dust[dust].scale = 1.2f * npc.scale;
					}
					else
					{
						Main.dust[dust].scale = 0.7f * npc.scale;
					}
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/BabyMarinGore1"), npc.scale);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Ocean/BabyMarinGore2"), npc.scale);
			}
		}

		public override void OnCatchNPC(Player player, Item item)
		{
			item.stack = 1;

			try
			{
				var npcCenter = npc.Center.ToTileCoordinates();
				if (!WorldGen.SolidTile(npcCenter.X, npcCenter.Y) && Main.tile[npcCenter.X, npcCenter.Y].liquid == 0)
				{
					Main.tile[npcCenter.X, npcCenter.Y].liquid = (byte)Main.rand.Next(50, 150);
					Main.tile[npcCenter.X, npcCenter.Y].lava(true);
					Main.tile[npcCenter.X, npcCenter.Y].honey(false);
					WorldGen.SquareTileFrame(npcCenter.X, npcCenter.Y, true);
				}
			}
			catch
			{
				return;
			}
		}
	}
}
