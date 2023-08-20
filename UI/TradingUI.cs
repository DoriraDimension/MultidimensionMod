using MultidimensionMod.Items.Potions;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.NPCs.TownNPCs;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace MultidimensionMod.UI
{
    public class TradingUI : UIState
    {
        //This was achieved with help from Mod of Redemption
        private readonly UIImage BgSprite = new(ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/NoTexture"));
        public static bool Visible = false;
        public static bool EldritchWoman = false;
        public Vector2 lastScreenSize;

        public override void OnInitialize()
        {
            lastScreenSize = new Vector2(Main.screenWidth, Main.screenHeight);

            BgSprite.Width.Set(200, 0f);
            BgSprite.Height.Set(300, 0f);
            BgSprite.Top.Set((Main.screenHeight / 2f) - 164f, 0f);
            BgSprite.Left.Set((Main.screenWidth / 2f) - 103f, 0f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (ContainsPoint(Main.MouseScreen) && !PlayerInput.IgnoreMouseInterface)
                Main.LocalPlayer.mouseInterface = true;

            if (Main.LocalPlayer.talkNPC == -1)
            {
                Visible = false;
                return;
            }
            bool taraha = Main.npc[Main.LocalPlayer.talkNPC].type == ModContent.NPCType<Taraha>();
            if (!Main.LocalPlayer.releaseInventory || (!taraha))
                Visible = false;

            if (taraha && !EldritchWoman)
            {
                BgSprite.RemoveAllChildren();
                int pad = 40;
                BgSprite.Append(new TradingPanelUI(new Item(ItemID.Deathweed, 3), new Item(ModContent.ItemType<CalmingPills>()), 3));
                BgSprite.Append(new TradingPanelUI(new Item(ItemID.BeeWax), new Item(ItemID.FallenStar)) { Top = new StyleDimension(pad, 0) });
                pad += 40;
                BgSprite.Append(new TradingPanelUI(new Item(ItemID.Acorn, 15), new Item(ModContent.ItemType<MadnessCaller>()), 15) { Top = new StyleDimension(pad, 0) });
                pad += 40;
                BgSprite.Append(new TradingPanelUI(new Item(ItemID.HellstoneBar, 10), new Item(ModContent.ItemType<CerebroAlloy>()), 10) { Top = new StyleDimension(pad, 0) });
                pad += 40;
                BgSprite.Append(new TradingPanelUI(new Item(ItemID.PygmyStaff), new Item(ModContent.ItemType<marcO>())) { Top = new StyleDimension(pad, 0) });
                pad += 40;
                BgSprite.Append(new TradingPanelUI(new Item(ItemID.Keybrand), new Item(ModContent.ItemType<TundranaScythe>())) { Top = new StyleDimension(pad, 0) });
                Append(BgSprite);
                EldritchWoman = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Visible)
                return;

            if (lastScreenSize != new Vector2(Main.screenWidth, Main.screenHeight))
            {
                lastScreenSize = new Vector2(Main.screenWidth, Main.screenHeight);
                BgSprite.Left.Pixels = (Main.screenWidth / 2f) - 103f;
                BgSprite.Top.Pixels = (Main.screenHeight / 2f) - 164f;
                BgSprite.Recalculate();
            }
            base.Draw(spriteBatch);
        }
    }
}