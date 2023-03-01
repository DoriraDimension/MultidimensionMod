using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class DesertNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(silver: 2);
			Item.rare = ItemRarityID.Green;
			Item.defense = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.ZoneDesert)
			{
				player.GetDamage(DamageClass.Generic) += 0.4f;
				player.GetCritChance(DamageClass.Generic) += 4;
			}

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 5)
			.AddIngredient(ItemID.Emerald)
			.AddTile(16)
			.Register();
		}
	}
}