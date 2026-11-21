using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Common.Systems;
using Terraria.Localization;

namespace MultidimensionMod.UI.SoulDeciphering
{
    public class SoulDecipheringUI : UIState
    {
        private UIPanel mainPanel;

        private SoulItemSlot soulSlot;

        private UIText dialogueText;
        private UIText progressText;

        private UITextPanel<string> decipherButton;
        private UITextPanel<string> closeButton;

        private int currentDialogueStage = -1;
        private SoulDecipherPortrait portrait;

        private bool studyAnimationStarted;
        private SoulSynchProgressBar progressBar;

        public override void OnInitialize()
        {
            //UI background for UI backgrounding
            SoulSynchBackground background = new SoulSynchBackground();
            background.Width.Set(600f, 0f);
            background.Height.Set(300f, 0f);
            background.Left.Set(-300f, 0.5f);
            background.Top.Set(-150f, 0.5f);

            Append(background);

            //Main panel for handling UI usage
            mainPanel = new UIPanel();
            mainPanel.Width.Set(600f, 0f);
            mainPanel.Height.Set(300f, 0f);
            mainPanel.Left.Set(-300f, 0.5f);
            mainPanel.Top.Set(-150f, 0.5f);

            mainPanel.BackgroundColor = Color.Transparent;
            mainPanel.BorderColor = Color.Transparent;

            Append(mainPanel);

            //Portrait for intense studying
            portrait = new SoulDecipherPortrait();

            portrait.Width.Set(100f, 0f);
            portrait.Height.Set(160f, 0f);

            portrait.Left.Set(450f, 0f);
            portrait.Top.Set(30f, 0f);

            mainPanel.Append(portrait);

            //Item slot for souls
            soulSlot = new SoulItemSlot();

            soulSlot.Left.Set(40f, 0f);
            soulSlot.Top.Set(50f, 0f);

            mainPanel.Append(soulSlot);

            //Dialogue box within the UI
            dialogueText = new UIText(Language.GetTextValue("Mods.MultidimensionMod.MiscText.PlaceSoultext"), 0.8f, false);

            dialogueText.Left.Set(150f, 0f);
            dialogueText.Top.Set(50f, 0f);
            dialogueText.Width.Set(280f, 0f);
            dialogueText.Height.Set(100f, 0f);

            dialogueText.IsWrapped = true;

            mainPanel.Append(dialogueText);

            //Percentage text displayed above progress bar
            progressText = new UIText("");

            progressText.Left.Set(50f, 0f);
            progressText.Top.Set(150f, 0f);

            mainPanel.Append(progressText);
            //Progress bar that fills with... well... progress
            progressBar = new SoulSynchProgressBar();

            progressBar.Left.Set(40f, 0f);
            progressBar.Top.Set(175f, 0f);

            mainPanel.Append(progressBar);

            //Synchronization start button
            decipherButton = new UITextPanel<string>("Synchronize");

            decipherButton.Width.Set(250f, 0f);
            decipherButton.Height.Set(40f, 0f);

            decipherButton.Left.Set(20f, 0f);
            decipherButton.Top.Set(200f, 0f);
            decipherButton.BackgroundColor = Color.SeaGreen;
            decipherButton.BorderColor = Color.DarkSeaGreen;

            decipherButton.OnLeftClick += DecipherButtonClicked;

            mainPanel.Append(decipherButton);

            //Button to close UI
            closeButton = new UITextPanel<string>("Close");

            closeButton.Width.Set(250f, 0f);
            closeButton.Height.Set(40f, 0f);

            closeButton.Left.Set(310f, 0f);
            closeButton.Top.Set(200f, 0f);
            closeButton.BackgroundColor = Color.SeaGreen;
            closeButton.BorderColor = Color.DarkSeaGreen;
            closeButton.OnLeftClick += CloseButtonClicked;

            mainPanel.Append(closeButton);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (mainPanel != null && mainPanel.ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }

            SoulItem soul = soulSlot.Soul;

            if (soul == null)
            {
                currentDialogueStage = -1;
                progressBar.Reset();
                dialogueText.SetText(Language.GetTextValue("Mods.MultidimensionMod.MiscText.PlaceSoultext"));

                progressText.SetText("");

                return;
            }

            // Already Synched
            if (soul.Synched)
            {
                dialogueText.SetText(soul.SynchingEndDialogue);

                progressText.SetText(Language.GetTextValue("Mods.MultidimensionMod.MiscText.SynchDone"));

                return;
            }

            // Not currently Synch
            if (soul.SynchProgress <= 0)
            {
                studyAnimationStarted = false;
                portrait.PlayIdle();

                dialogueText.SetText(soul.InsertDialogue);
                progressText.SetText(Language.GetTextValue("Mods.MultidimensionMod.MiscText.SynchStart"));
                return;
            }

            // Currently Synch
            if (!studyAnimationStarted)
            {
                portrait.PlayStudying();
                studyAnimationStarted = true;
            }
            soul.SynchProgress++;

            int percentage = (int)MathHelper.Clamp((float)soul.SynchProgress / soul.SynchDuration * 100f, 0f, 100f);
            progressText.SetText($"{percentage}%");

            UpdateStudyDialogue(soul, percentage);

            // Finish Synch
            if (soul.SynchProgress >= soul.SynchDuration)
            {
                soul.SynchProgress =
                    soul.SynchDuration;
                portrait.PlayFinishing();
                soul.Synched = true;

                dialogueText.SetText(soul.SynchingEndDialogue);

                progressText.SetText(Language.GetTextValue("Mods.MultidimensionMod.MiscText.SynchDone"));
            }
            if (soul == null)
            {
                progressBar.Progress = 0f;
            }
            else if (soul.Synched)
            {
                progressBar.Progress = 1f;
            }
            else if (soul.SynchProgress <= 0)
            {
                progressBar.Progress = 0f;
            }
            else
            {
                progressBar.Progress = soul.SynchDuration > 0 ? (float)soul.SynchProgress / soul.SynchDuration : 0f;
            }

        }

        private void UpdateStudyDialogue(SoulItem soul, int percentage)
        {
            int stage = percentage < 34 ? 0 : percentage < 67 ? 1 : 2;

            if (stage == currentDialogueStage)
                return;

            currentDialogueStage = stage;

            string dialogue = stage switch
            {
                0 => soul.SynchingDialogue,
                1 => soul.SynchingDialogue2,
                _ => soul.SynchingDialogue3
            };

            if (dialogue.Length > 0)
            {
                dialogueText.SetText(dialogue);
            }
        }

        private void DecipherButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            currentDialogueStage = -1;
            SoulItem soul = soulSlot.Soul;

            if (soul == null)
                return;

            if (soul.Synched)
                return;

            if (soul.SynchProgress > 0)
                return;

            soul.SynchProgress = 1;

            dialogueText.SetText(soul.SynchingDialogue.Length > 0 ? soul.SynchingDialogue : "Beginning Synchronization...");

            progressText.SetText("Synch started!");
        }

        public void BeginSession()
        {
            studyAnimationStarted = false;

            portrait.PlayTalking();
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            SoulDecipheringUISystem.CloseUI();
            Main.playerInventory = false;
        }

        public void ReturnSoulToPlayer()
        {
            soulSlot.ReturnSoul();
        }

        public void ResetProgressBar()
        {
            progressBar.Reset();
        }
    }
}