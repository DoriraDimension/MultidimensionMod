using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Tools
{
	public class PanaqueMalluris : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            Item.attackSpeedOnlyAffectsWeaponAnimation = true;
        }

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 4)
			.AddIngredient(ItemID.HallowedBar, 9)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}
