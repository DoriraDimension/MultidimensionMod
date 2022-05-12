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
			DisplayName.SetDefault("Desert Necklace");
			Tooltip.SetDefault("A magical necklace, created with the mana infused sand from a Lesser Sand Elemental.\nIt is unknown why the gem only reacts to the dry aura of deserts so are its actual origins.\nIncreases all damage and crit chance by 4% when in the Desert.");
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