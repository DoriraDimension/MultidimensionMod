using MultidimensionMod.NPCs.Ocean;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Critters
{
	internal class BabyGlowmarinItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baby Glowmarin");
			Tooltip.SetDefault("A juvenile Glowmarin, it's glow organs are already developed.");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.autoReuse = true;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.width = 34;
			item.height = 22;
			item.makeNPC = 360;
			item.noUseGraphic = true;

			item.CloneDefaults(ItemID.GlowingSnail);
			item.bait = 45;
			item.makeNPC = (short)ModContent.NPCType<BabyGlowmarin>();
		}
	}
}