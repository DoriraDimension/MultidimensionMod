using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace MultidimensionMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class BlackRoseScarf : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 46;
			Item.height = 50;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Yellow;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.BlackRoseScarf.Lore"))
                {
                    OverrideColor = Color.LightGray
                };
                tooltips.Add(line);
            }
            else
            {
                TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.SpecialTooltips.Viewer"))
                {
                    OverrideColor = Color.Gray,
                };
                tooltips.Add(line);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 1.70f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ThornScarf>())
			.AddIngredient(ItemID.VialofVenom, 2)
			.AddIngredient(ItemID.Deathweed, 3)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}
	}
}