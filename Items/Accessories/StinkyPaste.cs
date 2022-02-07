using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace MultidimensionMod.Items.Accessories
{
	public class StinkyPaste : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stinky Paste");
			Tooltip.SetDefault("Some stinky weird paste from the jungle, it is weird how its bad smell attracts all kinds of little creatures.\nIncreases minion damage by 6%.\nYou can rub it onto your skin you to smell like shit.");
			DisplayName.AddTranslation(GameCulture.German, "Stinkende Paste");
			Tooltip.AddTranslation(GameCulture.German, "Stinkende paste aus dem Dschungel, es ist seltsam wie sein schlechter Geruch alle möglichen kleinen Kreaturen anzieht.\nErhöht Günstlingsschaden um 6%.\nDu kannst dich damit einreiben um nach scheiße zu riechen.");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 15;
			item.useTime = 15;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 6);
			item.rare = ItemRarityID.Green;
			item.buffType = (BuffID.Stinky);
			item.buffTime = 14400;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.06f;
		}
	}
}