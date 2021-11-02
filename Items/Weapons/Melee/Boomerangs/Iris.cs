using MultidimensionMod.Projectiles.Boomerangs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class Iris : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Iris");
			Tooltip.SetDefault("Shoots a homing Iris Disc.");
			DisplayName.AddTranslation(GameCulture.German, "Die Iris");
			Tooltip.AddTranslation(GameCulture.German, "Schießt eine verfolgene Iris Scheibe.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.EnchantedBoomerang);
			item.shootSpeed *= 0.75f;
			item.width = 26;
			item.height = 26;
			item.damage = 18;
			item.useTime = 25;
			item.useAnimation = 25;
			item.value = Item.sellPrice(silver: 25);
			item.rare = ItemRarityID.Green;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = ModContent.ProjectileType<IrisDisc>();
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}