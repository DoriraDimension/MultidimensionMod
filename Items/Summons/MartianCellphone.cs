using Terraria;
using Terraria.ID;
using Terraria.Audio;
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
			Item.width = 20;
			Item.height = 32;
			Item.rare = 8;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = 4;
			Item.UseSound = SoundID.NPCHit39;
		}

		public override bool CanUseItem(Player player)
		{
			return Main.invasionType == 0;
		}

		public override bool? UseItem(Player player)
		{
			Main.StartInvasion(InvasionID.MartianMadness);
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddRecipeGroup("AdamantiteBars", 8)
			.AddIngredient(ItemID.LihzahrdPowerCell)
			.AddIngredient(ItemID.Nanites, 36)
			.AddTile(134)
			.Register();
		}
	}
}
