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

namespace MultidimensionMod
{
	public class MDGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool Blaze;

		public bool Madness;

		public int MadnessTimer;

		public int MadnessCringe;

		public override void ResetEffects(NPC npc)
		{
			Blaze = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			Player player = Main.LocalPlayer;
			if (Blaze)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 32;
				if (damage < 2)
				{
					damage = 2;
				}
			}
			if (Madness)
			{
				MadnessTimer++;
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				if (MadnessTimer >= 220)
				{
					MadnessCringe += 10;
					MadnessTimer = 0;
				}
				if (MadnessCringe >= 50)
				{
					MadnessCringe = 50;
				}
				npc.lifeRegen -= MadnessCringe;
			}
			if (!Madness)
			{
				MadnessTimer = 0;
				MadnessCringe = 0;
				npc.lifeRegen = 0;
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (Blaze)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 6, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
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
		}
	}
}