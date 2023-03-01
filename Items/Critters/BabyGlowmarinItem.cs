using MultidimensionMod.NPCs.Critters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Critters
{
	internal class BabyGlowmarinItem : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 34;
			Item.height = 22;
			Item.makeNPC = 360;
			Item.noUseGraphic = true;
			Item.CloneDefaults(ItemID.GlowingSnail);
			Item.bait = 45;
			Item.makeNPC = (short)ModContent.NPCType<BabyGlowmarin>();
		}
	}
}