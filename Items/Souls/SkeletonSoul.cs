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
	public class SkeletonSoul : SoulItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 32;
			Item.rare = ModContent.RarityType<SkeletonSoulRarity>();
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
					TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.SkeletonSoul.Lore"))
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
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/SkeletonSoul").Value;
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

        public override string InsertDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SkeletonSoulInsert");

        public override string SynchingDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SkeletonSoulRead1");
        public override string SynchingDialogue2 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SkeletonSoulRead2");
        public override string SynchingDialogue3 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SkeletonSoulRead3");

        public override string SynchingEndDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.SkeletonSoulReadDone");
    }
}