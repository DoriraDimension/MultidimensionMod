using MultidimensionMod.Rarities.Souls;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class EyeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of the Eye");
			// Tooltip.SetDefault("Yes, this eye actually had a soul on its own.\nThe ever watching eye, true eye or not, it doesnt matter, it was just waiting for another being to grow stronger.\nSome people call it the Eye of Judgement, the first test.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 12));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 36;
			Item.rare = ModContent.RarityType<EyeSoulRarity>();
		}
	}
}
