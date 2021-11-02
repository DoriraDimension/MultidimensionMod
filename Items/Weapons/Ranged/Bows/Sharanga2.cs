using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class Sharanga2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Bow, Sharan");
			Tooltip.SetDefault("A long lost bow, forgotten in ancient times.\nConverts Wooden Arrows into Cursed Arrows");
			DisplayName.AddTranslation(GameCulture.German, "verlorener Bogen, Sharan");
			Tooltip.AddTranslation(GameCulture.German, "Ein lange verlorener Bogen, vergessen in uralten Zeiten. \nKonvertiert Holzpfeile zu Verfluchten Pfeilen.");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 28;
			item.height = 52;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 7;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowFlameBow);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.CursedArrow;
			}
			return true;
		}
	}
}
