using MultidimensionMod.Tiles.FrozenUnderworld;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Materials
{
	public class IceblossomItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iceblossom");
			Tooltip.SetDefault("A kind of flora found in the Frozen Underworld, its ancestor, the Fireblossom, adapted to the environment to survive.");
			DisplayName.AddTranslation(GameCulture.German, "Eisblüte");
			Tooltip.AddTranslation(GameCulture.German, "Eine Art von Flora die in der Gefrorenen Unterwelt gefunden wird, ihr vorfahre, die Feuerblüte, hat sich an die neue Umgebung angepasst um zu überleben.");
		}

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.width = 12;
			item.height = 14;
			item.value = 80;
		}
	}
}