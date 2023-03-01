using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class NeroBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 20;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 21;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Generic) += 15;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TidalQuartz>(), 10)
			.AddIngredient(ItemID.HallowedBar, 13)
			.AddTile(134)
			.Register();
		}
	}
}