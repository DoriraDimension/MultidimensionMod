using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Rarities.Souls;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Items.Souls
{
	public class KingSlimeSoul : SoulItem
	{
        public override void SetStaticDefaults()
		{
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 5));
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 36;
			Item.rare = ModContent.RarityType<KingSlimeSoulRarity>();
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 30;
            Item.useAnimation = 30;

        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Synched)
            {
                if (Main.keyState.PressingShift())
                {
                    TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.KingSlimeSoul.Lore"))
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

        public override bool CanUseItem(Player player)
        {
            if (Synched)
                return true;
            else
                return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/KingSlimeSoul").Value;
            Rectangle frame;
            frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            Vector2 origin = frame.Size() / 2f;
            spriteBatch.Draw(texture, Item.Center - Main.screenPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }

        public override string InsertDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SlimeSoulInsert");

        public override string SynchingDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SlimeSoulRead1");
        public override string SynchingDialogue2 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SlimeSoulRead2");
        public override string SynchingDialogue3 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SlimeSoulRead3");

        public override string SynchingEndDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SlimeSoulReadDone");
    }
}
