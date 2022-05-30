using MultidimensionMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Magic.Guns
{
	public class Retilazor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Retilazor");
			Tooltip.SetDefault("Fires 4 lazors per shot.");
		}

		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 28;
			Item.useTime = 10;
			Item.useAnimation = 35;
			Item.reuseDelay = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item33;
			Item.mana = 11;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RedLazor>();
			Item.shootSpeed = 35f;
			Item.crit = 4;
		}
	}
}