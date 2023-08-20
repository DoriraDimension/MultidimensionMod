using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class EuniceFlagellum : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 100;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.DefaultToWhip(ModContent.ProjectileType<Eunice>(), 100, 6, 26);
			Item.shootSpeed = 6;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SwordWhip)
				.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}