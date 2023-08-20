using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.DataStructures;

namespace MultidimensionMod.UI
{
    public class TradingPanelUI : UIPanel
    {
        //This was achieved with help from Mod of Redemption
        private Item InputItem;
        private Item OutputItem;
        private int InputStack;
        private int OutputStack;
        public TradingPanelUI(Item inputItem, Item outputItem, int inputStack = 1, int outputStack = 1)
        {
            this.InputItem = inputItem;
            this.OutputItem = outputItem;
            this.InputStack = inputStack;
            this.OutputStack = outputStack;

            SetPadding(0);
            PaddingLeft = 10;
            PaddingRight = 10;

            Width.Set(-14, 1);
            Height.Set(32, 0);
            Left.Set(5, 0);

            OnMouseOver += MouseOver;
            OnMouseOut += MouseOut;

            BorderColor = new Color(19, 24, 43);

            Append(new UIItemIcon(inputItem, false)
            {
                IgnoresMouseInteraction = true,
                HAlign = 0,
                Left = new StyleDimension(4, 0)
            });
            Append(new UIText(inputStack.ToString())
            {
                HAlign = 0.25f,
                Top = new StyleDimension(8, 0),
                Left = new StyleDimension(4, 0)
            });

            Append(new PanelPointer(-MathHelper.PiOver2)
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            });

            Append(new UIItemIcon(outputItem, false)
            {
                IgnoresMouseInteraction = true,
                HAlign = 1,
                Left = new StyleDimension(-4, 0)
            });
            Append(new UIText(outputStack.ToString())
            {
                HAlign = 0.75f,
                Top = new StyleDimension(8, 0),
                Left = new StyleDimension(-4, 0)
            });
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            if (IsMouseHovering)
            {
                Main.HoverItem = Main.mouseX <= GetDimensions().Center().X ? InputItem : OutputItem;
                Main.instance.MouseText("");
                Main.mouseText = true;
            }
        }

        private void MouseOver(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.LocalPlayer.mouseInterface = true;
            SoundEngine.PlaySound(SoundID.MenuTick);
            BorderColor = Color.Gold;
        }
        public override void LeftClick(UIMouseEvent evt)
        {
            int desiredObject = Main.LocalPlayer.FindItem(InputItem.type);
            if (desiredObject >= 0 && Main.LocalPlayer.inventory[desiredObject].stack >= InputStack)
            {
                Main.LocalPlayer.inventory[desiredObject].stack -= InputStack;
                if (Main.LocalPlayer.inventory[desiredObject].stack <= 0)
                    Main.LocalPlayer.inventory[desiredObject] = new Item();

                Main.LocalPlayer.QuickSpawnItem(new EntitySource_Misc("Trade"), OutputItem, OutputStack);
            }
        }

        private void MouseOut(UIMouseEvent evt, UIElement listeningElement)
        {
            BorderColor = new Color(17, 113, 105, 255);
        }
    }
    public class PanelPointer : UIElement
    {
        public float rotation;

        public PanelPointer(float rotation)
        {
            this.rotation = rotation;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureAssets.GolfBallArrow.Value, GetDimensions().Position(), new Rectangle(0, 0, 20, 32), Color.White, rotation, new Vector2(10, 16), 1, SpriteEffects.None, 0);
            spriteBatch.Draw(TextureAssets.GolfBallArrow.Value, GetDimensions().Position(), new Rectangle(20, 0, 20, 32), Color.Black, rotation, new Vector2(10, 16), 1, SpriteEffects.None, 0);
        }
    }
}