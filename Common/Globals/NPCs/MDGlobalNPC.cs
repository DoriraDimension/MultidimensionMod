using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Projectiles.Melee.Swords;
using MultidimensionMod.NPCs.Tundra;
using MultidimensionMod.NPCs.FU;
using MultidimensionMod.NPCs.Madness;
using MultidimensionMod.NPCs.MushBiomes;
using MultidimensionMod.NPCs.Mire;
//using MultidimensionMod.NPCs.Inferno;
using MultidimensionMod.NPCs.Bosses.MushroomMonarch;
using MultidimensionMod.Biomes;
using MultidimensionMod.Dusts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using MultidimensionMod.Tiles.Biomes.ShroomForest;

namespace MultidimensionMod
{
	public class MDGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool Blaze;
		public bool Madness;
		public int MadnessTimer;
		public int MadnessCringe;
		public bool DrakePoison;
		public bool MarysWrath;
		public bool Nihil;
		public bool CantHurtDapper;
		public bool Accursed;
		public bool DimensionalShock;

		public override void ResetEffects(NPC npc)
		{
			Blaze = false;
			Madness = false;
			DrakePoison = false;
			Nihil = false;
			Accursed = false;
			DimensionalShock = false;
		}

		public int AccursedTimer = 0;

		public override void AI(NPC npc)
		{
			Player player = Main.LocalPlayer;
			if (Accursed)
			{
				AccursedTimer++;
				if (AccursedTimer == 120)
				{
                    Projectile.NewProjectile(npc.GetSource_FromAI(), new Vector2(npc.Center.X + (float)Main.rand.Next(-300, 300), npc.Center.Y + (float)Main.rand.Next(-300, 300)), new Vector2(0, 0), ModContent.ProjectileType<AccursedStalker>(), 50, 0, Main.myPlayer);
					AccursedTimer = 0;
                }
			}
			if (!Accursed)
			{
				AccursedTimer = 0;
			}
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (Blaze)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 50;
			}
			if (Madness)
			{
				MadnessTimer++;
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				if (MadnessTimer >= 160)
				{
					MadnessCringe += 10; //Increases the damage this debuff does
					MadnessTimer = 0; //resets the time until the next level
				}
				if (MadnessCringe >= 50) //If the damage level would go above 50, it gets reset to 50 instead
				{
					MadnessCringe = 50; //Maximum damage the debuff can do
				}
				npc.lifeRegen -= MadnessCringe;
			}
			if (!Madness)
			{
				MadnessTimer = 0;
				MadnessCringe = 0; //Resets the damage level of the debuff if it runs out
			}
			if (DrakePoison)
			{
				if (npc.type == ModContent.NPCType<IceDrakeJuvenile>()) //Does more damage to these enemy types
				{
					if (npc.lifeRegen > 0)
					{
						npc.lifeRegen = 0;
					}
					npc.lifeRegen -= 24;
				}
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;
			}
			if (DimensionalShock)
			{
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 60;
            }
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (Blaze)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.CrimsonTorch, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4))
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
            if (MarysWrath)
            {
                if (Main.rand.Next(6) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.Blood, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
            }
            if (Nihil)
            {
                if (Main.rand.Next(6) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<DarkDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.8f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
            }
            if (DimensionalShock)
            {
                if (Main.rand.Next(6) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.Electric, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 0.7f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
            }
            if (Accursed)
			{
                if (Main.rand.NextBool(6))
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width, npc.height, ModContent.DustType<AccursedGhost>(), 0, -2, 30, default(Color), 1.0f);
                }
            }
        }

		public override Color? GetAlpha(NPC npc, Color drawColor)
		{
			if (Nihil)
			{
                return Color.Black;
            }
			if (Accursed)
			{
				return Color.Purple;
			}
			return null;
		}

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.Player.InModBiome<FrozenUnderworld>())
			{
				pool.Clear();
				//pool.Add(ModContent.NPCType<IceDemon>(), 0.3f);
				pool.Add(ModContent.NPCType<Victim>(), 0.1f);
				//pool.Add(ModContent.NPCType<VeilImp>(), 0.2f);
				pool.Add(ModContent.NPCType<Dusty>(), 0.1f);
				if (Main.hardMode)
				{
                    pool.Add(ModContent.NPCType<Ashton>(), 0.1f);
                }
			}
			if (spawnInfo.Player.InModBiome<MadnessMoon>())
            {
				pool.Clear();
				pool.Add(ModContent.NPCType<MadnessBat>(), 1.0f);
				pool.Add(ModContent.NPCType<MadnessDog>(), 1.0f);
				pool.Add(ModContent.NPCType<Madman>(), 1.0f);
				if (Main.hardMode)
                {
					pool.Add(ModContent.NPCType<MadnessBat2>(), 1.0f);
					//pool.Add(ModContent.NPCType<MadTitan>(), 0.2f);
				}
			}
            if (spawnInfo.Player.InModBiome<ShroomForest>())
            {
                pool.Clear();
                pool.Add(ModContent.NPCType<CapBunny>(), 0.5f);
                pool.Add(ModContent.NPCType<Mushbug>(), 0.35f);
                pool.Add(ModContent.NPCType<MushbugBaby>(), 0.30f);
                pool.Add(ModContent.NPCType<Puffer>(), 0.25f);
                pool.Add(ModContent.NPCType<Hovercap>(), 0.35f);
				if ((Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<MyceliumSandPlaced>() || Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<Mycelium>()) && !NPC.AnyNPCs(ModContent.NPCType<MonarchSlep>()) && !NPC.AnyNPCs(ModContent.NPCType<MushroomMonarch>()) && spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()))
				    pool.Add(ModContent.NPCType<MonarchSlep>(), 0.10f);
            }
            if (spawnInfo.Player.InModBiome<TheDragonHoard>())
			{
                pool.Clear();
            }
            if (spawnInfo.Player.InModBiome<TheDragonBurrow>())
			{
                pool.Clear();
            }
            if (spawnInfo.Player.InModBiome<TheShroudedMire>())
			{
                pool.Clear();
				if (!Main.dayTime && NPC.CountNPCS(ModContent.NPCType<MireSkulker>()) < 4)
				{
                    pool.Add(ModContent.NPCType<MireSkulker>(), .35f);
                }
            }
            if (spawnInfo.Player.InModBiome<TheLakeDepths>())
			{
                pool.Clear();
				if (spawnInfo.Water)
                pool.Add(ModContent.NPCType<DrifterSpawner>(), 1f);
            }
        }
	}
}