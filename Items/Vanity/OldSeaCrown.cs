using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class OldSeaCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Old Sea Crown");
			Tooltip.SetDefault("A old crown found in the ocean, it is guessed that it didnt belong to a king as there are many of these found.");
			DisplayName.AddTranslation(GameCulture.German, "Alte Seekrone");
			Tooltip.AddTranslation(GameCulture.German, "Eine alte Krone die im Ocean gefunden wurde, es wirt vermutet das sie keinem König gehörte, da viele von ihnen gefunden wurden.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 20;
			item.value = Item.sellPrice(silver: 89);
			item.rare = ItemRarityID.LightRed;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return true;
		}
	}
}