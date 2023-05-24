using MultidimensionMod.Rarities.Souls;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class BrainSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 6));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 28;
			Item.rare = ModContent.RarityType<BrainSoulRarity>();
		}
	}
}