using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class AstralTitansEyeJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astral Titan's Eye Jewel");
			Tooltip.SetDefault("A jewel made to look like the eyes of the creation titan.\nDecreases the duration of the Potion Sickness debuff to 45 seconds and increases life regen by 2. \nIncreases invincibility time and rains down stars after getting hit.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 38;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pStone = true;
			player.starCloakItem = Item;
			player.longInvince = true;
			player.lifeRegen += 2;

		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(860)
			.AddIngredient(862)
			.AddIngredient(ModContent.ItemType<Blight2>(), 2)
			.AddTile(134)
			.Register();
		}
	}
}