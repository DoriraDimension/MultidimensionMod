using MultidimensionMod.Projectiles.Summon.Whips;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Weapons.Summon
{
	public class Tendril : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.width = 30;
			Item.height = 34;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.Blue;
			Item.DefaultToWhip(ModContent.ProjectileType<TendrilWhip>(), 12, 1, 2);
			Item.shootSpeed = 4;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<EyeTendril>(), 4)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override bool MeleePrefix()
		{
			return true;
		}
	}
}
