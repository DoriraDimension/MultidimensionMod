using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class SlimeSpreader : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 20;
			Item.useTime = 2;
			Item.useAnimation = 32;
			Item.reuseDelay = 41;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.3f;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<GelCloud>();
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Gel;
			Item.consumeAmmoOnLastShotOnly = true;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Gel, 34)
			.AddRecipeGroup(Recipes.GoldPlatinum, 16)
			.AddTile(TileID.Solidifier)
			.Register();
		}
	}
}
