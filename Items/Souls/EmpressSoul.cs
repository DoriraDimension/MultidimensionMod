using MultidimensionMod.Rarities.Souls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Souls
{
	public class EmpressSoul : SoulItem
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
        public override bool CanUseItem(Player player)
        {
            if (Synched)
                return true;
            else
                return false;
        }


        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Synched)
            {
                if (Main.keyState.PressingShift())
                {
                    TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.EmpressSoul.Lore"))
                    {
                        OverrideColor = Color.LightGray
                    };
                    tooltips.Add(line);
                }
                else
                {
                    TooltipLine line = new(Mod, "HoldShift", Language.GetTextValue("Mods.MultidimensionMod.MiscText.SpecialTooltips.Viewer"))
                    {
                        OverrideColor = Color.Gray,
                    };
                    tooltips.Add(line);
                }
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return MDColors.Rainbow;
        }

        public override string InsertDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EmpressSoulInsert");

        public override string SynchingDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EmpressSoulRead1");
        public override string SynchingDialogue2 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EmpressSoulRead2");
        public override string SynchingDialogue3 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EmpressSoulRead3");

        public override string SynchingEndDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EmpressSoulReadDone");
    }
}