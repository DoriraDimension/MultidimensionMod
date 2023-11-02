using MultidimensionMod.NPCs.Tundra;
using MultidimensionMod.NPCs.FU;
using MultidimensionMod.NPCs.Madness;
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
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Projectiles.Melee.Swords;

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

		public override void ResetEffects(NPC npc)
		{
			Blaze = false;
			Madness = false;
			DrakePoison = false;
			Nihil = false;
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
		}
	}
}