using MultidimensionMod.Buffs.Debuffs;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Common.Players;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Accessories
{
    //[AutoloadEquip(EquipType.HandsOn)]
    public class OrnateBand : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().OrnateVeil = true;
            if (player.GetModPlayer<MDPlayer>().veilReset >= 600)
            {
                player.lifeRegen += 4;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.OrnateBand.Lore"))
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

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Ornate Band");
            //Tooltip.SetDefault("+50 Max Life");
        }

    }
}