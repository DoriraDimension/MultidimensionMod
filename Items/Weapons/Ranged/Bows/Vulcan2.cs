using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class Vulcan2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lost Gen Repeater, Vulca");
			Tooltip.SetDefault("A long lost repeater, forgotten in ancient times.\nConverts Wooden Arrows into Hellfire Arrows");
			DisplayName.AddTranslation(GameCulture.German, "Verlorener Repetierer, Vulca");
			Tooltip.AddTranslation(GameCulture.German, "Ein lange verlorener Repetierer, vergessen in uralten Zeiten. \nKonvertiert Holzpfeile zu Höllenfeuer Pfeile.");
		}

		public override void SetDefaults()
		{
			item.damage = 68;
			item.ranged = true;
			item.width = 48;
			item.height = 22;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 28f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedRepeater);
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
				type = ProjectileID.HellfireArrow;
			}
			return true;
		}
	}
}
