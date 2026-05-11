using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Items.Fishing
{
    public class GlitchFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Glitch Fish");
            Item.ResearchUnlockCount = 3;
            ItemID.Sets.CanBePlacedOnWeaponRacks[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.maxStack = 1;
            Item.width = 26;
            Item.height = 26;
            Item.uniqueStack = true;
            Item.rare = ItemRarityID.LightRed; 
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Main.keyState.PressingShift())
            {
                TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.GlitchFish.Lore"))
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
    }
}