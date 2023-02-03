using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Weapons.Typeless;
using MultidimensionMod.Items.Potions;
using MultidimensionMod.NPCs.TownPets;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Tundra
{
	public class IceDrakeJuvenile : ModNPC
	{
		public bool hasBeenFed;
		public bool isAdoptable;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Drake Juvenile");
			Main.npcFrameCount[NPC.type] = 14;
			NPCID.Sets.ActsLikeTownNPC[Type] = true;
		}

		public override void SetDefaults()
		{
			NPC.friendly = true;
			NPC.dontTakeDamageFromHostiles = true;
			NPC.width = 34;
			NPC.height = 22;
			NPC.damage = 16;
			NPC.defense = 13;
			NPC.lifeMax = 50;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 90);
			NPC.knockBackResist = 0f;
			NPC.aiStyle = -1;
			NPC.noGravity = false;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<BbyDrakeBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
			   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.UndergroundSnow,
				new FlavorTextBestiaryInfoElement("Juvenile Ice Drakes usually reside underground where they hunt down prey via ambush. They can be approached savely when they are asleep.")
			});
		}

		public override void AI()
        {
			NPC.TargetClosest(true);
			NPC.netUpdate = true;
			Player player = Main.player[NPC.target];

			if (!hasBeenFed && NPC.life < NPC.lifeMax)
            {
				NPC.width = 54;
				NPC.height = 56;
				NPC.friendly = false;
				NPC.knockBackResist = 0.6f;
				Vector2 victor = new(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
				{
					float rotation = (float)Math.Atan2(victor.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), victor.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(rotation) * 4) * -1;
					NPC.velocity.Y = (float)(Math.Sin(rotation) * 4) * -1;
				}
				if (NPC.velocity.X > -0.1)
				{
					NPC.spriteDirection = -1;

				}
				else if (NPC.velocity.X < 0.1)
				{
					NPC.spriteDirection = 1;
				}
			}
		}

		public override bool? CanBeHitByProjectile(Projectile projectile)
		{
			//Gives the player the ability to hurt the Drake with projectiles even while it is set to friendly.
			//Removes that ability if it was fed already. It is now immortal
			if (!hasBeenFed)
			{
				return projectile.friendly && projectile.owner < 255;
			}
			return false;
		}

		public override bool CanChat()
		{
			if (!hasBeenFed && NPC.life < NPC.lifeMax == false)
			{
				return true;
			}
			return false;
		}

		public override string GetChat()
        {
			if (Main.rand.NextBool(3333))
            {
				return "We are inside your walls, always watching";
            }
			return "*snore*";
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			//gives the option to feed the Drake, does not work if it was already fed or is currently hostile.
			if (!hasBeenFed)
			{
				button = Language.GetTextValue("Feed");
			}
			if (Main.LocalPlayer.HasItem(ModContent.ItemType<KFC>()) && !NPC.AnyNPCs(ModContent.NPCType<TownDrake>()))
            {
				button = Language.GetTextValue("Adopt");
				isAdoptable = true;
            }
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			//Makes the Drake drop an item upon feeding it
			if (firstButton && !isAdoptable)
			{
				hasBeenFed = true;
				SoundEngine.PlaySound(SoundID.NPCDeath13 with { Volume = 0.5f }, NPC.position);
				int commonDrop = Main.rand.Next(2);
				int uncommonDrop = Main.rand.Next(2);
				if (Main.rand.NextFloat() < .0500f)
				{
					if (uncommonDrop == 0)
					{
						Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<FrozenGeode>(), 1);
					}
					if (uncommonDrop == 1)
					{
						Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<DrakeCrystal>(), 1);
					}
					return;
				}
				else
				    if (commonDrop == 0)
				    {
					    Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ItemID.ShiverthornSeeds, 1);
				    }
				    if (commonDrop == 1)
				    {
					    Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ItemID.FlinxFur, 1);
				    }
				    return;
			}
			else if (firstButton && isAdoptable)
            {
				Vector2 spawnAt = NPC.Center + new Vector2(0f, (float)NPC.height / 2f);
				NPC.NewNPC(NPC.GetSource_FromAI(), (int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<TownDrake>());
				NPC.active = false;
			}
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<FrostScale>(), 1, 1, 3));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.Player.ZoneSnow && spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY > Main.rockLayer)
            {
				return 0.13f;
            }
			else if (spawnInfo.Player.ZoneSnow && spawnInfo.Player.ZoneRain)
			{
				return 0.80f;
			}
			return 0f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/JuvenileDrakeGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/JuvenileDrakeGore2").Type, 1);
			}
		}

		private int frame;
		public override void FindFrame(int frameHeight)
		{
			if (++NPC.frameCounter > 8)
			{
				frame++;
				NPC.frameCounter = 0;
				if (frame > 13)
				{
					frame = 8;
				}
			}
			if (!hasBeenFed && NPC.life < NPC.lifeMax)
			{
				if (++NPC.frameCounter > 4)
				{
					frame++;
					NPC.frameCounter = 0;
					if (frame > 7)
					{
						frame = 0;
					}
				}
			}
			NPC.frame.Y = frame * frameHeight;
		}
	}
}
