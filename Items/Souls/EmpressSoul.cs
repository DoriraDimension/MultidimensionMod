using MultidimensionMod.Rarities.Souls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace MultidimensionMod.Items.Souls
{
	public class EmpressSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 38;
			Item.rare = ModContent.RarityType<EmpressSoulRarity>();
		}

        public override Color? GetAlpha(Color lightColor)
        {
            return MDColors.Rainbow;
        }
    }
}