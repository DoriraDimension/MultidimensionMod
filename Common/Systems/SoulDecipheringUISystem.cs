using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using Terraria.ModLoader;
using System.Collections.Generic;
using MultidimensionMod.UI.SoulDeciphering;

namespace MultidimensionMod.Common.Systems
{
    public class SoulDecipheringUISystem : ModSystem
    {
        internal static UserInterface SoulInterface;
        internal static SoulDecipheringUI SoulUI;
        private static bool closeNpcChatNextUpdate;
        private static int activeNPC = -1;
        private const float MaxDistance = 300f;

        private static bool uiOpen;

        public override void Load()
        {
            if (Main.dedServ)
                return;

            SoulUI = new SoulDecipheringUI();
            SoulUI.Activate();

            SoulInterface = new UserInterface();
            uiOpen = false;
        }

        public static void OpenUI(int npcWhoAmI)
        {
            if (Main.dedServ)
                return;

            activeNPC = npcWhoAmI;

            Main.npcChatText = "";
            Main.playerInventory = true;

            SoulInterface.SetState(SoulUI);
            uiOpen = true;

            closeNpcChatNextUpdate = true;
            SoulUI.BeginSession();
            SoulInterface.SetState(SoulUI);
        }

        public static void CloseUI()
        {
            if (Main.dedServ || !uiOpen)
                return;

            SoulUI.ReturnSoulToPlayer();
            SoulUI.ResetProgressBar();

            SoulInterface.SetState(null);
            Main.playerInventory = false;
            activeNPC = -1;
            uiOpen = false;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (closeNpcChatNextUpdate)
            {
                closeNpcChatNextUpdate = false;
                Main.CloseNPCChatOrSign();
            }

            if (uiOpen)
            {
                // Check whether the NPC still exists.
                if (activeNPC < 0 || activeNPC >= Main.maxNPCs || !Main.npc[activeNPC].active)
                {
                    CloseUI();
                    return;
                }

                // Check the distance between the player and NPC.
                float distanceSquared = Vector2.DistanceSquared(Main.LocalPlayer.Center, Main.npc[activeNPC].Center);

                if (distanceSquared > MaxDistance * MaxDistance)
                {
                    CloseUI();
                    return;
                }

                // Close if the inventory was closed manually.
                if (!Main.playerInventory)
                {
                    CloseUI();
                    return;
                }
            }

            SoulInterface?.Update(gameTime);
        }

        public static bool IsNPCBeingUsed(int npcWhoAmI)
        {
            return uiOpen && activeNPC == npcWhoAmI;
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name == "Vanilla: Mouse Text");

            if (mouseTextIndex == -1)
                return;

            layers.Insert(
                mouseTextIndex,
                new LegacyGameInterfaceLayer(
                    "MultidimensionMod: Soul Deciphering",
                    delegate
                    {
                        SoulInterface?.Draw(
                            Main.spriteBatch,
                            new GameTime()
                        );

                        return true;
                    },
                    InterfaceScaleType.UI
                )
            );
        }

        public override void Unload()
        {
            SoulInterface = null;
            SoulUI = null;
            uiOpen = false;
        }
    }
}