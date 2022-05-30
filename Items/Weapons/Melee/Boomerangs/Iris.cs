using MultidimensionMod.Projectiles.Melee.Boomerangs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Boomerangs
{
	public class Iris : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Iris");
			Tooltip.SetDefault("Throws a homing Iris Disc.");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.EnchantedBoomerang);
			Item.shootSpeed *= 0.75f;
			Item.width = 26;
			Item.height = 26;
			Item.damage = 21;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<IrisDisc>();
		}
	}
}