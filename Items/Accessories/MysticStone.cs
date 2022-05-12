using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class MysticStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystic Stone");
			Tooltip.SetDefault("This stone pulses with magical energy and increases max mana by 40.\nThe energy that surrounds the hallow has very potent magical capabilities,\nthe growing crystal shards can sometimes turn into even bigger crystals filled to the brim with magic.");
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 34;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statManaMax2 += 40;
		}
	}
}