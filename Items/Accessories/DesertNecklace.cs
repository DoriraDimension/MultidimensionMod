using MultidimensionMod.Items.Materials;
using MultidimensionMod.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Accessories
{
	public class DesertNecklace : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 40;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.rare = ItemRarityID.Blue;
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.DesertNecklace.Lore"))
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
			if (player.ZoneDesert)
			{
				player.GetDamage(DamageClass.Generic) += 0.04f;
				player.GetCritChance(DamageClass.Generic) += 4;
			}
			player.GetModPlayer<MDPlayer>().DesertNeck = true;
		}

        public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>(), 5)
			.AddIngredient(ItemID.Emerald)
			.AddTile(TileID.Anvils)
			.Register();
		}
	}
}