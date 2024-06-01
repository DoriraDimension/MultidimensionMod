using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn)]
    public class ShadowBand : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 44;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.ShadowBand.Lore"))
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
            if (player.wet && !player.lavaWet && !player.honeyWet)
            {
                player.moveSpeed += .25f;
                Player.jumpHeight += 50;
                player.jumpSpeedBoost += 0.35f;
            }
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Shadow Band");
            //Tooltip.SetDefault(@"8% increased movement speed");
        }
    }
}