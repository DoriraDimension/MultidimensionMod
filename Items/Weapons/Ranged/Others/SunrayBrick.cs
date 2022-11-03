using MultidimensionMod.Projectiles.Ranged;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Others
{
	public class SunrayBrick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunray Brick");
			Tooltip.SetDefault("Creates a google stock explosion gif on impact.");
		}


		public override void SetDefaults()
		{
			Item.damage = 56;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 70;
			Item.height = 70;
			Item.useTime = 56;
			Item.useAnimation = 56;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 10;
			Item.noUseGraphic = true;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SunrayBrickThrown>();
			Item.shootSpeed = 15f;
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

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<GolemSoul>())
			.AddIngredient(ModContent.ItemType<Dimensium>(), 12)
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}