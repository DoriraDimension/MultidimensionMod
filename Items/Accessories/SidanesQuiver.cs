using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class SidanesQuiver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sidane's Quiver");
			Tooltip.SetDefault("The magitech quiver owned by the creator Sidane.\nSidane is one of the less serious members of the creator council, he would sometimes fly around on a hoverboard and use others inventions as targets for training.\nIncreases arrow damage by 10%, ranged damage by 10% and greatly increases arrow speed \n20% chance to not consume arrows.");
			DisplayName.AddTranslation(GameCulture.German, "Sidane's Köcher");
			Tooltip.AddTranslation(GameCulture.German, "Der Magitech Köcher welcher dem Schöpfer Sidane gehört.\nSidane ist einer der weniger ernsten mitglieder des Rats der Schöpfer,\ner würde manchmal auf einem Hoverboard herumfliegen und anderer Leute erfindungen als Zielscheiben werwenden.\nErhöt Pfeil und fernkampfschaden um 10% und erhöht Pfeilgeschwindigkeit stark. \n20% Chance keine Pfeile zu verbrauchen. \nErhöt Rüstungsdurchdringung um 10.");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 48;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 4);
			item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.rangedDamage += 0.10f;
			player.magicQuiver = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicQuiver);
			recipe.AddIngredient(ItemID.RangerEmblem);
			recipe.AddIngredient(ModContent.ItemType<Blight2>(), 2);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}