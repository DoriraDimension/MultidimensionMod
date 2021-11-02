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
			DisplayName.AddTranslation(GameCulture.German, "Wiedergeborene Seele");
			Tooltip.AddTranslation(GameCulture.German, "Eine lang verlorene Seele, wiederbelebt mit der Kraft von 3 mächtigen Seelen.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 8));
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Pink;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}