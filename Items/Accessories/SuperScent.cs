using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class SuperScent : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Scent");
			Tooltip.SetDefault("The combination of stinky paste and a aromatic Leaf created a scent that smells, to say it nicely, interesting.\nIncreases minion damage by 6% and gives +1 minion slot.\nRub it onto your skin to smell worse than the human mind can comprehend");
			DisplayName.AddTranslation(GameCulture.German, "Super Geruch");
			Tooltip.AddTranslation(GameCulture.German, "Die Kombination von stinkender Paste und einem aromatischen Blatt erschuf eine Geruch der, um es nett zu sagen, interessant riecht.\nErhöht Günstlingsschaden um 6% und gubt einen minion slot.\nReib dich damit ein um schlimmer zu riechen als das menschliche Gehirn voerstellen kann.");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 36;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 15;
			item.useTime = 15;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 14);
			item.rare = ItemRarityID.Orange;
			item.buffType = (BuffID.Stinky);
			item.buffTime = 28800;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.06f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<StinkyPaste>());
			recipe.AddIngredient(ModContent.ItemType<BaitLeaf>());
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 3);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}