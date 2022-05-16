using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class XiphiasGladius : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xiphias Gladius");
			Tooltip.SetDefault("A sword created from old blueprints found at the shores. The ancient depictions show it being used to fend off preditory ocean creatures.");
		}

		public override void SetDefaults()
		{
			Item.damage = 94;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.crit = 11;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7)
			.AddIngredient(ItemID.HallowedBar, 15)
			.AddTile(134)
			.Register();
		}
	}
}