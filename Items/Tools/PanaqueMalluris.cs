using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class PanaqueMalluris : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Panaque Malluris");
			Tooltip.SetDefault("A hamaxe created from old blueprints found at the shores. The ancient depictions show it being used to gather and shape wood.");
		}

		public override void SetDefaults()
		{
			Item.damage = 53;
			Item.DamageType = DamageClass.Melee;
			Item.width = 52;
			Item.height = 50;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.axe = 27;
			Item.hammer = 90;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 4)
			.AddIngredient(ItemID.HallowedBar, 9)
			.AddTile(134)
			.Register();
		}
	}
}
