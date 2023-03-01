using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class DesertEagle : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Eagle");
			// Tooltip.SetDefault("Did someone squish this bird into a gun shape, wth?");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 60;
			Item.height = 56;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(silver: 26);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 30f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 10;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -10);
		}
	}
}