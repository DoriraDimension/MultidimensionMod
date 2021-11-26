using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
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
			DisplayName.SetDefault("Desert Eagle");
			Tooltip.SetDefault("Did someone squish this bird into a gun shape, wth?");
			DisplayName.AddTranslation(GameCulture.German, "Desert Eagle");
			Tooltip.AddTranslation(GameCulture.German, "Hatt jemand diesen Vogel in eine Pistolenform gequetscht, was zur Hölle?");
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.ranged = true;
			item.width = 60;
			item.height = 56;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 26);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item41;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Bullet;
			item.crit = 10;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -10);
		}
	}
}