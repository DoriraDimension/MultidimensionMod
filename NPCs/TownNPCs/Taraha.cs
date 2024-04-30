using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Accessories;
using MultidimensionMod.Items.Summons;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.Items;
using MultidimensionMod.Common.Systems;
using MultidimensionMod.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.TownNPCs
{
	[AutoloadHead]
	class Taraha : ModNPC
	{
		//Yes, this is Example Mod code, shut the fish up!!!

		// Time of day for traveller to leave (6PM)
		public const double despawnTime = 48600.0;

		// the time of day the traveler will spawn (double.MaxValue for no spawn)
		// saved and loaded with the world in TravelingMerchantSystem
		public static double spawnTime = double.MaxValue;

		public override bool PreAI()
		{
			if ((!Main.dayTime || Main.time >= despawnTime) && !IsNpcOnscreen(NPC.Center)) // If it's past the despawn time and the NPC isn't onscreen
			{
				// Here we despawn the NPC and send a message stating that the NPC has despawned
				// LegacyMisc.35 is {0) has departed!
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Mods.MultidimensionMod.MiscNPCText.Taraha.Departing", NPC.FullName), 17, 113, 105);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.MultidimensionMod.MiscNPCText.Taraha.Departing", NPC.GetFullNetName()), new Color(17, 113, 105));
				NPC.active = false;
				NPC.netSkip = -1;
				NPC.life = 0;
				return false;
			}

			return true;
		}

		public static void UpdateTravelingMerchant()
		{
			bool travelerIsThere = NPC.FindFirstNPC(ModContent.NPCType<Taraha>()) != -1; // Find a Merchant if there's one spawned in the world

			// Main.time is set to 0 each morning, and only for one update. Sundialling will never skip past time 0 so this is the place for 'on new day' code
			if (Main.dayTime && Main.time == 0)
			{
				// insert code here to change the spawn chance based on other conditions (say, npcs which have arrived, or milestones the player has passed)
				// You can also add a day counter here to prevent the merchant from possibly spawning multiple days in a row.

				// NPC won't spawn today if it stayed all night
				if (!travelerIsThere && Main.rand.NextBool(4))
				{ // 4 = 25% Chance
				  // Here we can make it so the NPC doesnt spawn at the EXACT same time every time it does spawn
					spawnTime = GetRandomSpawnTime(5400, 8100); // minTime = 6:00am, maxTime = 7:30am
				}
				else
				{
					spawnTime = double.MaxValue; // no spawn today
				}
			}

			// Spawn the traveler if the spawn conditions are met (time of day, no events, no sundial)
			if (!travelerIsThere && CanSpawnNow())
			{
				int newTraveler = NPC.NewNPC(Terraria.Entity.GetSource_TownSpawn(), Main.spawnTileX * 16, Main.spawnTileY * 16, ModContent.NPCType<Taraha>(), 1); // Spawning at the world spawn
				NPC traveler = Main.npc[newTraveler];
				traveler.homeless = true;
				traveler.direction = Main.spawnTileX >= WorldGen.bestX ? -1 : 1;
				traveler.netUpdate = true;

				// Prevents the traveler from spawning again the same day
				spawnTime = double.MaxValue;

				// Annouce that the traveler has spawned in!
				if (Main.netMode == NetmodeID.SinglePlayer) Main.NewText(Language.GetTextValue("Mods.MultidimensionMod.MiscNPCText.Taraha.Arrival", traveler.FullName), 17, 198, 92);
				else ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.MultidimensionMod.MiscNPCText.Taraha.Arrival", traveler.GetFullNetName()), new Color(17, 198, 92));
			}
		}

		private static bool CanSpawnNow()
		{
			// can't spawn if any events are running
			if (Main.eclipse || Main.invasionType > 0 && Main.invasionDelay == 0 && Main.invasionSize > 0)
				return false;

			// can't spawn if the sun or moondial is active
			if (Main.IsFastForwardingTime())
				return false;

			if (!NPC.downedBoss2)
				return false;

            // can spawn if daytime, and between the spawn and despawn times
            return Main.dayTime && Main.time >= spawnTime && Main.time < despawnTime;
		}

		private static bool IsNpcOnscreen(Vector2 center)
		{
			int w = NPC.sWidth + NPC.safeRangeX * 2;
			int h = NPC.sHeight + NPC.safeRangeY * 2;
			Rectangle npcScreenRect = new Rectangle((int)center.X - w / 2, (int)center.Y - h / 2, w, h);
			foreach (Player player in Main.player)
			{
				// If any player is close enough to the traveling merchant, it will prevent the npc from despawning
				if (player.active && player.getRect().Intersects(npcScreenRect)) return true;
			}
			return false;
		}

		public static double GetRandomSpawnTime(double minTime, double maxTime)
		{
			// A simple formula to get a random time between two chosen times
			return (maxTime - minTime) * Main.rand.NextDouble() + minTime;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 1;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 4;
            NPCID.Sets.NoTownNPCHappiness[Type] = true;
            var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                CustomTexturePath = "MultidimensionMod/NPCs/Bestiary/TarahaBestiary",
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifier);
        }

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 60;
			NPC.height = 100;
			NPC.aiStyle = -1;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 1000;
			NPC.knockBackResist = 0f;
			TownNPCStayingHomeless = true;
			NPC.dontTakeDamage = true;
			NPC.noGravity = true;
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Taraha")
            });
        }

        public override bool UsesPartyHat()
        {
            return false;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			return false; // spawn manually so false
		}

		public override ITownNPCProfile TownNPCProfile()
		{
			return new TarahaProfile();
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Taraha Ceh'ronm",
			};
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int dor = NPC.FindFirstNPC(ModContent.NPCType<Dorira>());

			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.GenericDialogue1"));
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.GenericDialogue2"));
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.GenericDialogue3"));
			chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.GenericDialogue4"));
            if (dor >= 0)
            {
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.DoriraDialogue"));
			}
			if (Main.bloodMoon)
            {
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.BloodMoonDialogue"));
            }
			if (Main.slimeRain)
            {
				chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.SlimeRainDialogue"));
            }
			if (DownedSystem.downedSmiley)
			{
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.SmileyDialogue"));
            }
            /*Player player = Main.LocalPlayer;
            int shadeEye = player.FindItem(ModContent.ItemType<ShadeEye>());
            if (player.inventory[shadeEye].stack >= 0)
			{
                chat.Add(Language.GetTextValue("Mods.MultidimensionMod.Dialogue.Taraha.ShadeItemDialogue"));
            }*/

            string dialogueLine = chat; // chat is implicitly cast to a string.
			return dialogueLine;
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = "Trade";
		}

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                TradingUI.Visible = true;
            }
        }

        public override void AI()
		{
			NPC.homeless = true; // Make sure it stays homeless
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			Texture2D portalTexture = ModContent.Request<Texture2D>("MultidimensionMod/NPCs/TownNPCs/TarahaPortal").Value;
			Texture2D eyeTexture = ModContent.Request<Texture2D>("MultidimensionMod/NPCs/TownNPCs/Taraha").Value;
			Vector2 position = NPC.Center - Main.screenPosition;
			Rectangle rect = new(0, 0, portalTexture.Width, portalTexture.Height);
			Rectangle eyeRect = new(0, 0, eyeTexture.Width, eyeTexture.Height);
			Vector2 origin = new(portalTexture.Width / 2f, portalTexture.Height / 2f);
			Vector2 eyeOrigin = new(eyeTexture.Width / 2f, eyeTexture.Height / 2f);

			Main.EntitySpriteDraw(portalTexture, position, new Rectangle?(rect), NPC.GetAlpha(drawColor), NPC.rotation, origin, NPC.scale, SpriteEffects.None, 0);
			Main.EntitySpriteDraw(eyeTexture, position, new Rectangle?(eyeRect), NPC.GetAlpha(drawColor), NPC.rotation, eyeOrigin, NPC.scale, SpriteEffects.None, 0);

			return false;
		}
	}

	public class TarahaProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
		{
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("MultidimensionMod/NPCs/TownNPCs/Taraha");

			return ModContent.Request<Texture2D>("MultidimensionMod/NPCs/TownNPCs/Taraha");
		}

		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("MultidimensionMod/NPCs/TownNPCs/Taraha_Head");
	}
}
