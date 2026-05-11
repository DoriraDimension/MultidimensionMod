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
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Common.Globals;
using Terraria.GameContent.Bestiary;

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
		public bool hazed;
		public bool mildBurn;
		public bool MadnessEmpower;

		public override void ResetEffects(NPC npc)
		{
			Blaze = false;
			Madness = false;
			DrakePoison = false;
			Nihil = false;
			Accursed = false;
			DimensionalShock = false;
			hazed = false;
			mildBurn = false;
			MadnessEmpower=false;
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

		//Here we rewrite bestiary entries for vanilla enemies to fall in line with our own lore
        public override void SetBestiary(NPC npc, BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
			if (ModContent.GetInstance<MDConfig>().VanillaBestiaryRewrite)
			{
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.EyeofCthulhu")
                    });
                }
                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.EaterofWorlds")
                    });
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.BrainofCthulhu")
                    });
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Skeletron")
                    });
                }
                if (npc.type == NPCID.WallofFlesh)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.WallofFlesh")
                    });
                }
                if (npc.type == NPCID.Spazmatism)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Spazmatism")
                    });
                }
                if (npc.type == NPCID.Retinazer)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Retinazer")
                    });
                }
                if (npc.type == NPCID.TheDestroyer)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Destroyer")
                    });
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.SkeletronPrime")
                    });
                }
                if (npc.type == NPCID.Plantera)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Plantera")
                    });
                }
                if (npc.type == NPCID.HallowBoss)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.EmpressofLight")
                    });
                }
                if (npc.type == NPCID.MoonLordCore)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.MoonLord")
                    });
                }
                if (npc.type == NPCID.WyvernHead)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Wyvern")
                    });
                }
                if (npc.type == NPCID.Wraith)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Wraith")
                    });
                }
                if (npc.type == NPCID.SeekerHead)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.WorldFeeder")
                    });
                }
                if (npc.type == NPCID.Paladin)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Paladin")
                    });
                }
                if (npc.type == NPCID.ChaosElemental)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.ChaosElemental")
                    });
                }
                if (npc.type == NPCID.VoodooDemon)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.VoodooDemon")
                    });
                }
                if (npc.type == NPCID.UndeadViking)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.UndeadViking")
                    });
                }
                if (npc.type == NPCID.Harpy)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Harpy")
                    });
                }
                if (npc.type == NPCID.TacticalSkeleton)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.TacticalSkeleton")
                    });
                }
                if (npc.type == NPCID.SkeletonCommando)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.SkeletonCommando")
                    });
                }
                if (npc.type == NPCID.SkeletonSniper)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.SkeletonSniper")
                    });
                }
                if (npc.type == NPCID.Demolitionist)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Demolitionist")
                    });
                }
                if (npc.type == NPCID.GoblinTinkerer)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.GoblinTinkerer")
                    });
                }
                if (npc.type == NPCID.ArmsDealer)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.ArmsDealer")
                    });
                }
                if (npc.type == NPCID.Mechanic)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Mechanic")
                    });
                }
                if (npc.type == NPCID.Steampunker)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Steampunker")
                    });
                }
                if (npc.type == NPCID.Cyborg)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Cyborg")
                    });
                }
                if (npc.type == NPCID.Princess)
                {
                    bestiaryEntry.Info.RemoveAll(e => e is FlavorTextBestiaryInfoElement);
                    bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
                    {
                        new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.VanillaBestiaryEdits.Princess")
                    });
                }
            }
        }

        public override void ModifyHitPlayer(Terraria.NPC npc, Terraria.Player target, ref Terraria.Player.HurtModifiers modifiers)
        {
            if (hazed)
                modifiers.IncomingDamageMultiplier *= 0.85f;
			if(MadnessEmpower)
				modifiers.IncomingDamageMultiplier *= 1.2f;
        }
        public override void ModifyHitNPC(Terraria.NPC npc, Terraria.NPC target, ref Terraria.NPC.HitModifiers modifiers)
        {
            if (hazed)
                modifiers.FinalDamage *= 0.85f;
        }

        public override void ModifyIncomingHit(Terraria.NPC npc, ref Terraria.NPC.HitModifiers modifiers)
        {
			if(MadnessEmpower)
				modifiers.FinalDamage *= .3f;
            if (mildBurn)
                modifiers.Defense *= .90f;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if(MadnessEmpower)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, Main.rand.NextBool(2) ? DustID.YellowTorch : 54);
            	Dust.NewDust(npc.position, npc.width, npc.height, Main.rand.NextBool(2) ? DustID.YellowTorch : 54);
			}
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
            if (hazed)
            {
                if (Main.rand.NextBool(60))
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<MoonpowderDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 0.7f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                }
            }
            if (mildBurn)
            {
                if (Main.rand.NextBool(60))
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<SunpowderDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 0.7f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
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
            if (spawnInfo.Player.InModBiome<FrozenUnderworld>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
			{
				pool.Clear();
				//pool.Add(ModContent.NPCType<IceDemon>(), 0.3f);
				pool.Add(ModContent.NPCType<Victim>(), 0.08f);
				//pool.Add(ModContent.NPCType<VeilImp>(), 0.2f);
				pool.Add(ModContent.NPCType<Dusty>(), 0.07f);
				if (Main.hardMode)
				{
                    pool.Add(ModContent.NPCType<Ashton>(), 0.06f);
                }
			}
			if (spawnInfo.Player.InModBiome<MadnessMoon>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
            {
				pool.Clear();
				pool.Add(ModContent.NPCType<MadnessBat>(), 1.0f);
				pool.Add(ModContent.NPCType<MadnessDog>(), 1.0f);
				pool.Add(ModContent.NPCType<Madman>(), 1.0f);
				if (Main.hardMode)
                {
					pool.Add(ModContent.NPCType<MadnessBat2>(), 1.0f);
					if(ModContent.GetInstance<MadnessBrainSpawnSystem>().CanBrainSpawn)
						pool.Add(ModContent.NPCType<AMindFromBeyond>(), 0.02f);
				}
			}
            if (spawnInfo.Player.InModBiome<ShroomForest>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
            {
                pool.Clear();
                pool.Add(ModContent.NPCType<CapBunny>(), 0.5f);
                pool.Add(ModContent.NPCType<Mushbug>(), 0.35f);
                pool.Add(ModContent.NPCType<MushbugBaby>(), 0.30f);
                pool.Add(ModContent.NPCType<Puffer>(), 0.25f);
                pool.Add(ModContent.NPCType<Hovercap>(), 0.35f);
                pool.Add(ModContent.NPCType<MushSlime>(), 0.40f);
                if (spawnInfo.Player.FindItem(ModContent.ItemType<IntimidatingMushroom>()) > 0)
				{
                    if ((Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<MyceliumSandPlaced>() || Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<Mycelium>()) && !NPC.AnyNPCs(ModContent.NPCType<MonarchSlep>()) && !NPC.AnyNPCs(ModContent.NPCType<MushroomMonarch>()) && spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()))
                        pool.Add(ModContent.NPCType<MonarchSlep>(), 0.35f);
                }
				else
				{
                    if ((Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<MyceliumSandPlaced>() || Main.tile[spawnInfo.SpawnTileX, spawnInfo.SpawnTileY].TileType == ModContent.TileType<Mycelium>()) && !NPC.AnyNPCs(ModContent.NPCType<MonarchSlep>()) && !NPC.AnyNPCs(ModContent.NPCType<MushroomMonarch>()) && spawnInfo.Player.InModBiome(ModContent.GetInstance<ShroomForest>()))
                        pool.Add(ModContent.NPCType<MonarchSlep>(), 0.12f);
                }
            }
            if (spawnInfo.Player.InModBiome<TheDragonHoard>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
			{
                pool.Clear();
            }
            if (spawnInfo.Player.InModBiome<TheDragonBurrow>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
			{
                pool.Clear();
            }
            if (spawnInfo.Player.InModBiome<TheShroudedMire>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
			{
                pool.Clear();
				if (!Main.dayTime)
				{
					if (NPC.CountNPCS(ModContent.NPCType<MireSkulker>()) < 4)
                        pool.Add(ModContent.NPCType<MireSkulker>(), .25f);
                    pool.Add(ModContent.NPCType<BogFrog>(), .08f);
                    pool.Add(ModContent.NPCType<Newt>(), .06f);
                    pool.Add(ModContent.NPCType<Mossling>(), 0.2f);
                    pool.Add(ModContent.NPCType<Mosster>(), 0.05f);
                    if (!spawnInfo.Water)
                    {
                        pool.Add(ModContent.NPCType<MoonMorpho>(), .08f);
                        if (NPC.downedBoss2)
                        {
                            pool.Add(ModContent.NPCType<Miresquito>(), .10f);
                        }
                    }
                    if (spawnInfo.Water)
                        pool.Add(ModContent.NPCType<FogAngler>(), 0.3f);
                }
				else if (Main.dayTime)
				{
                    pool.Add(ModContent.NPCType<Stalker>(), 0.2f);
                }
            }
            if (spawnInfo.Player.InModBiome<TheLakeDepths>() && !spawnInfo.Player.ZoneTowerNebula && !spawnInfo.Player.ZoneTowerSolar && !spawnInfo.Player.ZoneTowerStardust && !spawnInfo.Player.ZoneTowerVortex)
			{
                pool.Clear();
                pool.Add(ModContent.NPCType<LakeBat>(), 0.1f);
                pool.Add(ModContent.NPCType<Mossling>(), 0.2f);
                if (spawnInfo.Water)
				{
                    pool.Add(ModContent.NPCType<DrifterSpawner>(), 1f);
                    pool.Add(ModContent.NPCType<FogAngler>(), 0.3f);
                    if (NPC.CountNPCS(ModContent.NPCType<DepthAngler>()) < 3)
                        pool.Add(ModContent.NPCType<DepthAngler>(), 0.5f);
					pool.Add(ModContent.NPCType<Finfly>(), 0.2f);
					pool.Add(ModContent.NPCType<Biofeeder>(), 0.2f);
                    pool.Add(ModContent.NPCType<Bloatleech>(), 0.15f);
                    pool.Add(ModContent.NPCType<Lecharvis>(), 0.3f);
                }
            }
        }
	}
}