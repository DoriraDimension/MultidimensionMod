using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NeroShellHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nero Shell Helmet");
			Tooltip.SetDefault("A helmet created from old blueprints found at the shores. The ancient depictions show brave warriors defending their home.\nIncreases melee damage by 18%.");
			DisplayName.AddTranslation(GameCulture.German, "Nero Panzer Helm");
			Tooltip.AddTranslation(GameCulture.German, "Ein Helm der mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen tapfere Krieger die ihr zuhause verteidigen.\nErhöht Nahkampfschaden um 18%.");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 18;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Yellow;
			item.defense = 25;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<NeroBreastplate>() && legs.type == ModContent.ItemType<NeroGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases max life by 40 gives the ability to swim and you can move through water freely.\nIncreases movement speed by 15% and defense by 10 when submerged in liquid.";
			player.statLifeMax2 += 40;
			player.accFlipper = true;
			player.ignoreWater = true;
			if (player.wet)
			{
				player.moveSpeed += 15f;
				player.statDefense += 10;
            }
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.18f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 6);
			recipe.AddIngredient(ItemID.HallowedBar, 7);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}