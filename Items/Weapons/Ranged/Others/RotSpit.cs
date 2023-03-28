using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class RotSpit : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 86;
			Item.height = 24;
			Item.useTime = 90;
			Item.useAnimation = 90;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(silver: 26);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.NPCDeath13;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RottenSpit>();
			Item.shootSpeed = 65f;
			Item.crit = 13;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}