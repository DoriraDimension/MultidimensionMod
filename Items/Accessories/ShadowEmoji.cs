using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class ShadowEmoji : ModItem
	{
		public override void SetStaticDefaults()
		{
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 5));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 58;
			Item.height = 54;
			Item.accessory = true;
			Item.expert = true;
			Item.value = Item.sellPrice(0, 2, 0, 0);
			Item.rare = ItemRarityID.Expert;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 2;
			player.GetDamage(DamageClass.Summon) += 0.5f;
			if (player.statLife <= player.statLifeMax2 * 0.3)
			{
				player.moveSpeed += 0.15f;
            }
		}
	}
}