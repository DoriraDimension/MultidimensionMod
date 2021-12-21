using MultidimensionMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Flamethrowers
{
	public class Spazmelter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spmazmelter");
			Tooltip.SetDefault("Shoots cursed flames.");
			DisplayName.AddTranslation(GameCulture.German, "Spazchmelzer");
			Tooltip.AddTranslation(GameCulture.German, "Schießt verfluchte Flammen.");
		}

		public override void SetDefaults()
		{
			item.damage = 46; 
			item.ranged = true;
			item.width = 42;
			item.height = 26;
			item.useTime = 6;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 0.3f;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<SpazmicFlame>();
			item.shootSpeed = 9f;
			item.useAmmo = AmmoID.Gel;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return player.itemAnimation >= player.itemAnimationMax - 4;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 42f;
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -2);
		}
	}
}
