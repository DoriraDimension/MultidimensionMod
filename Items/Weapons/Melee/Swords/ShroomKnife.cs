using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class ShroomKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroom Knife");
			Tooltip.SetDefault("A small knife made of juicy fungus flesh.");
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Melee;
			Item.width = 34;
			Item.height = 36;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = 3;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 4);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<Mushmatter>(), 12)
			.AddIngredient(ItemID.GlowingMushroom, 16)
			.AddTile(16)
			.Register();
		}
	}
}