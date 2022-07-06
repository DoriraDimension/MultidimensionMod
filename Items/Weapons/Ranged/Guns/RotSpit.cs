using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Guns
{
	public class RotSpit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rot Spit");
			Tooltip.SetDefault("Spits out a big ball of rotten flesh that attracts small devourers. Devourer will poison enemies on hit.");
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
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.NPCDeath13;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<RottenSpit>();
			Item.shootSpeed = 50f;
			Item.crit = 13;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine Item in list)
			{
				if (Item.Mod == "Terraria" && Item.Name == "ItemName")
				{
					Item.OverrideColor = MDRarity.BossItem;
				}
			}
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<WormSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 10)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}