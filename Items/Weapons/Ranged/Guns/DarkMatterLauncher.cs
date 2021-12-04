using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Projectiles.Ranged;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class DarkMatterLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Launcher");
			Tooltip.SetDefault("You could basically shove the boss into this thing to use as ammo.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Materie Werfer");
			Tooltip.AddTranslation(GameCulture.German, "Du könntest einfach den Boss nehmen und in dieses ding stecken als Munition.");
		}

		public override void SetDefaults()
		{
			item.damage = 44;
			item.ranged = true;
			item.width = 54;
			item.height = 26;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DarkMatterBlob>();
			item.shootSpeed = 9f;
			item.crit = 8;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}