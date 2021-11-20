using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Summons
{
	public class MartianCellphone : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Martian Cellphone");
			base.Tooltip.SetDefault("A cell phone with strange symbols on it, theres a phone number on the screen, call it?\nCalls the Martians.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 32;
			item.rare = 8;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.NPCHit39;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.invasionType == 0;
		}

		public override bool UseItem(Player player)
		{
			Main.StartInvasion(InvasionID.MartianMadness);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("AdamantiteBars", 8);
			recipe.AddIngredient(ItemID.LihzahrdPowerCell);
			recipe.AddIngredient(ItemID.Nanites, 36);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
