using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using MultidimensionMod.Common.Players;
using MultidimensionMod.Utilities;

namespace MultidimensionMod.Items.Materials
{
	public class IceblossomItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 9999;
			Item.width = 12;
			Item.height = 14;
			Item.value = Item.sellPrice(0, 0, 0, 20);
			Item.rare = ItemRarityID.White;
			Item.useStyle = ItemUseStyleID.EatFood;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.UseSound = SoundID.Item2;
			Item.consumable = true;
			Item.buffType = 47; //Frozen
			Item.buffTime = 900;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			if (Main.LocalPlayer.HasInInventory(ModContent.ItemType<HerbGuide>()) || Main.LocalPlayer.HasInInventory(ModContent.ItemType<NatureGuide>()) || Main.LocalPlayer.GetModPlayer<MDPlayer>().herbBook)
			{
                if (Main.keyState.PressingShift())
                {
                    TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.IceblossomItem.BloomTip"))
                    {
                        OverrideColor = Color.SkyBlue
                    };
                    tooltips.Add(line);
                }
                else
                {
                    TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.MiscText.SpecialTooltips.Blooming"))
                    {
                        OverrideColor = Color.Gray,
                    };
                    tooltips.Add(line);
                }
            }
        }
    }
}