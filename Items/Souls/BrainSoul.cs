using MultidimensionMod.Rarities.Souls;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class BrainSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of the Brain");
			// Tooltip.SetDefault("Like the related eye, this brain is supposed to test ones skills,\nbut rather than doing that it turned against its duty.\nIt resides in the bloody land of flesh, awaiting a new victim.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 6));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.rare = ModContent.RarityType<BrainSoulRarity>();
		}
	}
}