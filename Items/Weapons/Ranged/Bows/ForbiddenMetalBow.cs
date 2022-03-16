using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ammo;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class ForbiddenMetalBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Metal Bow");
			Tooltip.SetDefault("A bow that was restored from old relics, it converts Wooden Arrows into Forbidden Arrows.");
			DisplayName.AddTranslation(GameCulture.German, "Verbotener Metall Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Ein Bogen der aus alten Relikten restauriert wurde, er konvertiert Holzpfeile in Verbotene Pfeile.");
		}

		public override void SetDefaults()
		{
			item.damage = 56;
			item.ranged = true;
			item.width = 34;
			item.height = 52;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 14f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 5;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ModContent.ProjectileType<ForbiddenArrow>();
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldDustyBowMiddlePiece>());
			recipe.AddIngredient(ModContent.ItemType<OldDustyBowArm>());
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}