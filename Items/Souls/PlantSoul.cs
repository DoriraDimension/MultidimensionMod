using MultidimensionMod.Rarities.Souls;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Souls
{
	public class PlantSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 10));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 36;
			Item.rare = ModContent.RarityType<PlantSoulRarity>();
		}
	}
}