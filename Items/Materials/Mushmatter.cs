using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class Mushmatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushmatter");
			Tooltip.SetDefault("A juicy piece of Fungi infested flesh, could be useful.\nIt's somewhat terrifying how these glowing mushrooms can infect every living thing if they arent careful enough,\nmaybe a problem that should be dealed with before it gets out of hand.");
			DisplayName.AddTranslation(GameCulture.German, "Pilz Materie");
			Tooltip.AddTranslation(GameCulture.German, "Ein saftiges stück Fungi befallenes Fleisch.\nEs ist irgendwie erschreckend wie diese glühenden Pilze jedes lebende Wesen infizieren können wenn sie nicht genug aufpassen,\nvieleicht ein problem das beseitigt werden sollte befor es ausser kontrolle gerät.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 32;
			item.maxStack = 999;
			item.value = Item.sellPrice(copper: 8);
			item.rare = ItemRarityID.Blue;
		}
	}
}
