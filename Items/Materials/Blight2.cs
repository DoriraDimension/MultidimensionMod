using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Blight2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reincarnated Soul");
			Tooltip.SetDefault("A long lost soul, revived with the power of 3 mighty essences.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 8));
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(silver: 6);
			Item.rare = ItemRarityID.Pink;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.SoulofFright)
			.AddIngredient(ItemID.SoulofSight)
			.AddIngredient(ItemID.SoulofMight)
			.AddTile(26)
			.Register();
		}
	}
}