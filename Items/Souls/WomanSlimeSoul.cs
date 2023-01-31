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
	public class WomanSlimeSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Queen Slime");
			Tooltip.SetDefault("Where a king is, there is a queen, and this queen is a angel.\nThe queen of all slimes resides in the hallow, where she augmented herself with the magical energy of the land by putting a crystal inside her.\nThis crystal has heavenly powers, even giving her angelic wings to fly.\nThe crystal constantly increases her powers so who knows what she could have become if not taken care off.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 7));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 48;
			Item.rare = ModContent.RarityType<WomanSlimeSoulRarity>();
		}
	}
}