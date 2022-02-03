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
			Tooltip.SetDefault("A kind of flora found in the Frozen Underworld, its ancestor, the Fireblossom, adapted to the environment to survive.\nThe influence of the icy magic made this plant dangerous to eat.");
			DisplayName.AddTranslation(GameCulture.German, "Eisblüte");
			Tooltip.AddTranslation(GameCulture.German, "Eine Art von Flora die in der Gefrorenen Unterwelt gefunden wird, ihr vorfahre, die Feuerblüte, hat sich an die neue Umgebung angepasst um zu überleben.\nDie auswirkungen der eisigen Magie haben die Pflanze gefährlich gemacht zu essen.");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.width = 12;
			item.height = 14;
			item.value = 80;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 15;
			item.useTime = 15;
			item.UseSound = SoundID.Item2;
			item.consumable = true;
			item.buffType = (47); //Frozen
			item.buffTime = 900;
		}
	}
}