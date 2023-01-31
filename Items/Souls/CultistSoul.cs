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
	public class CultistSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Lunatic Cultist");
			Tooltip.SetDefault("The weird cultist who worships the moon wanted to reawaken something that was sealed away for hundreds of years,\nbut he got interrupted and absorbed the energy used for the ritual to fight instead.\nThe absorbed celestial energy smashed his soul into 4 pieces driving him even more insane.\nThere was no hope for this guy anymore, or perhaps never was.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 8));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.rare = ModContent.RarityType<CultistSoulRarity>();
		}
	}
}