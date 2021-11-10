using MultidimensionMod.Projectiles.SwordProjectiles;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class LonelySword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lonely Sword");
			Tooltip.SetDefault("A sword of a dark warrior that was given to Smiley after said warroir fell in battle.\nIt shoots a dark orb straight from 1995.");
			DisplayName.AddTranslation(GameCulture.German, "Einsames Schwert");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert eines dunklen Kriegers das Smiley gegeben wurde nachdem besagter Krieger im Kampf fiel.\nEs schießt einen dunklen Orb direkt von 1995.");
		}

		public override void SetDefaults()
		{
			item.damage = 38;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<OGMatterBall>();
			item.shootSpeed = 8f;
		}
	}
}