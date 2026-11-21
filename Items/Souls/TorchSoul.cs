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
    public class TorchSoul : SoulItem
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
            Item.rare = ItemRarityID.Master;
            Item.DefaultToTorch(TileID.Torches, 0, false);
            Item.consumable = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (Synched)
            {
                if (Main.keyState.PressingShift())
                {
                    TooltipLine line = new(Mod, "Lore", Language.GetTextValue("Mods.MultidimensionMod.Items.TorchSoul.Lore"))
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
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/TorchSoul").Value;
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

        public override string InsertDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.TorchSoulInsert");

        public override string SynchingDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.TorchSoulRead1");
        public override string SynchingDialogue2 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.TorchSoulRead2");
        public override string SynchingDialogue3 => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.TorchSoulRead3");

        public override string SynchingEndDialogue => Language.GetTextValue("Mods.MultidimensionMod.NPCs.Dialogue.Cultissima.TorchSoulReadDone");
    }
}