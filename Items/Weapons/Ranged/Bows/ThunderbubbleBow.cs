using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class ThunderbubbleBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunderbubble Bow");
			Tooltip.SetDefault("Shoots electrified bubbles that explode into small gravity affected electric bolts that inflict electrified.");
		}

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 28;
			Item.height = 42;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Arrow;
			Item.crit = 15;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			{
				type = ModContent.ProjectileType<Thunderbubble>();
			}
		}
	}
}