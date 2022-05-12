using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class ColdDesertShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Desert Shield");
			Tooltip.SetDefault("Combining both, desert and frost magic results in a strong protecting shield.\nIncreases all damage and crit chance by 4%, increases defense by 6 and damage reduction by 4% when in the Desert or Snow biome.\nIncreases defense by 4 when under 50% life");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 34);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneSnow || player.ZoneDesert)
			{
				player.GetDamage(DamageClass.Generic) += 0.4f;
				player.GetCritChance(DamageClass.Generic) += 4;
				player.statDefense += 6;
				player.endurance += 0.04f;
			}
			if (player.statLife <= player.statLifeMax2 * 0.5)
			{
				player.statDefense += 4;
            }

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DrakescaleShield>())
			.AddIngredient(ModContent.ItemType<DesertNecklace>())
			.AddTile(114)
			.Register();
		}
	}
}