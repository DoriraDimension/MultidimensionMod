using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Tools
{
	public class ScarusFossores : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Melee;
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 5;
			Item.useAnimation = 13;
			Item.pick = 220;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 4);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.tileBoost += 3;
		}

		public override void AddRecipes()
		{
			 CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 5)
			.AddIngredient(ItemID.HallowedBar, 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}