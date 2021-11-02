using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class EyeoftheHunter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of the Hunter");
			Tooltip.SetDefault("A true hunter can sense its prey. \nYou can now sense your enemies everywhere.");
			DisplayName.AddTranslation(GameCulture.German, "Auge des Jägers");
			Tooltip.AddTranslation(GameCulture.German, "Ein wahrer Jäger kann seine Beute spüren. \nDu kannst deine Gegner jetzt überall spüren.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 12;
			item.accessory = true;
			item.value = Item.sellPrice(copper: 60);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.detectCreature = true;
		}
	}
}