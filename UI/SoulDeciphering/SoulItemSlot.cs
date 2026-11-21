using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;
using MultidimensionMod.Items.Souls;

namespace MultidimensionMod.UI.SoulDeciphering
{
    public class SoulItemSlot : UIElement
    {
        private Item item = new Item();
        private Texture2D slotTexture;
        private Texture2D glowTexture;

        private float glowTimer;
        private float glowOpacity;

        public SoulItem Soul =>
            item.ModItem as SoulItem;

        public SoulItemSlot()
        {
            Width.Set(52f, 0f);
            Height.Set(52f, 0f);
            slotTexture = ModContent.Request<Texture2D>("MultidimensionMod/UI/SoulDeciphering/SoulItemSlotUIPanel", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            glowTexture = ModContent.Request<Texture2D>("MultidimensionMod/UI/SoulDeciphering/SoulItemSlotUIPanelGlow", ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
            OnLeftClick += LeftClickSlot;
            OnRightClick += RightClickSlot;
        }

        private void LeftClickSlot(UIMouseEvent evt, UIElement listeningElement)
        {
            // Pick up the soul.
            if (Main.mouseItem.IsAir)
            {
                if (!item.IsAir)
                {
                    Main.mouseItem = item.Clone();
                    item.TurnToAir();
                }

                return;
            }

            // Reject anything that isn't a soul.
            if (Main.mouseItem.ModItem is not SoulItem)
                return;

            // Place a soul into an empty slot.
            if (item.IsAir)
            {
                item = Main.mouseItem.Clone();
                Main.mouseItem.TurnToAir();
                return;
            }

            // Swap the two souls.
            if (item.ModItem is SoulItem)
            {
                Item oldItem = item.Clone();

                item = Main.mouseItem.Clone();
                Main.mouseItem = oldItem;
            }
        }

        private void RightClickSlot(
            UIMouseEvent evt,
            UIElement listeningElement)
        {
            // Souls should not be split.
            if (!Main.mouseItem.IsAir && Main.mouseItem.ModItem is not SoulItem)
            {
                return;
            }

            ItemSlot.RightClick(ref item, ItemSlot.Context.InventoryItem
            );
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();

            if (ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            // Draw custom slot background.
            spriteBatch.Draw(slotTexture, dimensions.ToRectangle(), Color.White);

            // Draw the item itself, without Terraria's slot background.
            if (!item.IsAir)
            {
                Vector2 itemCenter = new Vector2(dimensions.X + dimensions.Width / 2f, dimensions.Y + dimensions.Height / 2f);

                ItemSlot.DrawItemIcon(item, ItemSlot.Context.InventoryItem, spriteBatch, itemCenter, 1f, 32f, Color.White);
                if (glowOpacity > 0.05f)
                {
                    spriteBatch.Draw(glowTexture, dimensions.ToRectangle(), Color.White * glowOpacity);
                }
            }
        }

        public void ReturnSoul()
        {
            if (item.IsAir)
                return;

            Player player = Main.LocalPlayer;

            // Attempt to put the item into the inventory.
            Item leftover = player.GetItem(player.whoAmI, item.Clone(), GetItemSettings.InventoryEntityToPlayerInventorySettings);

            // Drop any leftover item if the inventory is full.
            if (!leftover.IsAir)
            {
                player.QuickSpawnItem(player.GetSource_Misc("SoulDeciphering"), leftover);
            }

            item.TurnToAir();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // No soul, or already synchronized: no glow.
            if (item.IsAir || Soul.Synched)
            {
                glowOpacity = MathHelper.Lerp(glowOpacity, 0f, 0.1f);
                return;
            }

            // Synchronization in progress: pulsating glow.
            if (Soul.SynchProgress > 0)
            {
                glowTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                glowOpacity = 0.55f +
                    (float)(System.Math.Sin(glowTimer * 3f) * 0.2f);

                return;
            }

            // Soul inserted, but not yet synchronized.
            glowOpacity = MathHelper.Lerp(glowOpacity, 0.4f, 0.1f);
        }

    }
}