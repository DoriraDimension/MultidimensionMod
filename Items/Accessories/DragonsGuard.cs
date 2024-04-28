using MultidimensionMod.Common.Players;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class DragonsGuard : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 22;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.defense = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MDPlayer>().DragonsGuard = true;
            if (player.HasBuff(BuffID.OnFire))
            {
                player.statDefense += 10;
                player.GetDamage(DamageClass.Generic) += 0.08f;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.DragonsGuard.Lore"))
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
            //DisplayName.SetDefault("Dragon's Guard");
            //Tooltip.SetDefault(@"Enemies that strike you are set ablaze");
        }
    }
}
