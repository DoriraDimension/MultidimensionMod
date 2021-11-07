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
			DisplayName.AddTranslation(GameCulture.German, "Donnerblasen Bogen");
			Tooltip.AddTranslation(GameCulture.German, "Verschießt elektrifizierte Blasen welche in kleine von der Schwerkraft betroffene Funken explodieren, Funken verursachen den elektrisiert debuff.");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.ranged = true;
			item.width = 26;
			item.height = 46;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 15;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			{
				type = ModContent.ProjectileType<Thunderbubble>();
				return Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
		}
	}
}
