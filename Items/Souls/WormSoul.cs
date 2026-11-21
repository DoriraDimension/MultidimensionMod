using MultidimensionMod.Rarities.Souls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using Terraria.Localization;

namespace MultidimensionMod.Items.Souls
{
	public class WormSoul : SoulItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 28;
			Item.rare = ModContent.RarityType<WormSoulRarity>();
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
					TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.WormSoul.Lore"))
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

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/WormSoul").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}

        public override string InsertDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EaterSoulInsert");

        public override string SynchingDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EaterSoulRead1");
        public override string SynchingDialogue2 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EaterSoulRead2");
        public override string SynchingDialogue3 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EaterSoulRead3");

        public override string SynchingEndDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.EaterSoulReadDone");
    }
}