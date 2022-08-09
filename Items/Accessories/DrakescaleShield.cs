using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class DrakescaleShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drakescale Shield");
			Tooltip.SetDefault("A shield reinforced with the scales of juvenile Ice Drakes.\nDrakescales are strengthened in the cold icy winds of the tundra, so theres no wonder that natives often use them as protection.\nIncreases defense by 4 and damage reduction by 4% when in the Snow biome.");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 24;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 2);
			Item.rare = ItemRarityID.Green;
			Item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
			if (player.ZoneSnow)
            {
				player.statDefense += 4;
				player.endurance += 0.04f;
			}

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FrostScale>(), 5)
			.AddRecipeGroup("IronBar", 10)
			.AddTile(16)
			.Register();
		}
	}
}