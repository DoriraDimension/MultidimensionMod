using System.Collections.Generic;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class RegalSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Regal Saber");
			Tooltip.SetDefault("A sword born from the soul of the king of all slimes, it might not be a very powerful sword but it emits a regal aura.");
			DisplayName.AddTranslation(GameCulture.German, "Königlicher Säbel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert das aus der Seele des Königs aller Schleime geboren wurde, es mag zwar kein mächtiges Schwert sein aber es strahlt eine königliche Aura aus.");
		}

		public override void SetDefaults()
		{
			item.damage = 11;
			item.melee = true;
			item.width = 40;
			item.height = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 2;
			item.autoReuse = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.crit = 31;
		}

		public override void ModifyTooltips(List<TooltipLine> list)
		{
			foreach (TooltipLine item in list)
			{
				if (item.mod == "Terraria" && item.Name == "ItemName")
				{
					item.overrideColor = MDRarity.BossWeapon;
				}
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(137, 480);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<KingSlimeSoul>(), 4);
			recipe.AddIngredient(ModContent.ItemType<Dimensium>(), 10);
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}