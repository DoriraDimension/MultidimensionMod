using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class DarkMatterLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Launcher");
			Tooltip.SetDefault("You could basically shove the boss into this thing to use as ammo.");
		}

		public override void SetDefaults()
		{
			Item.damage = 44;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 54;
			Item.height = 26;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DarkMatterBlob>();
			Item.shootSpeed = 9f;
			Item.crit = 8;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}