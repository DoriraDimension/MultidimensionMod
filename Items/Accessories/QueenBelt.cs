using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class QueenBelt : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 26;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 5;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 0.5f;
			if (player.velocity.Y != 0f)
			{
				player.moveSpeed += 0.5f;
			}
			if (player.immune)
            {
				player.wingTime += 4;
            }
		}
	}
}