using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Items.Weapons.Typeless;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
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
			NPC.width = 54;
			NPC.height = 56;
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

		public override void AI()
        {
			NPC.netUpdate = true;
			Player player = Main.player[NPC.target];

			if (!hasBeenFed && NPC.life < NPC.lifeMax)
            {
				//Placeholder AI
				NPC.friendly = false;
				NPC.knockBackResist = 0.6f;
				NPC.CloneDefaults(NPCID.FlyingSnake);
				NPC.aiStyle = 14;
				AIType = NPCID.FlyingSnake;
			}
		}

		public override bool? CanBeHitByItem(Player player, Item item)
		{
			//Gives the player the ability to hurt the Drake even while it is set to friendly.
			//Removes that ability if it was fed already. It is now immortal
			if (!hasBeenFed)
			{
				return true;
			}
			return false;
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
			return true;
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
			if (!hasBeenFed || NPC.life < NPC.lifeMax)
			{
				button = Language.GetTextValue("Feed");
			}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			//Makes the Drake drop an item upon feeding it
			if (firstButton)
			{
				hasBeenFed = true;
				SoundEngine.PlaySound(SoundID.NPCDeath13 with { Volume = 0.5f }, NPC.position);
				int commonDrop = Main.rand.Next(2);
				int uncommonDrop = Main.rand.Next(2);
				if (Main.rand.NextBool(2))
				{

					if (commonDrop == 0)
					{
						Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ItemID.ShiverthornSeeds, 1);
					}
					if (commonDrop == 1)
					{
						Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ItemID.FlinxFur, 1);
					}
				}
				else
					if (uncommonDrop == 0)
				    {
					    Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<FrozenGeode>(), 1);
				    }
				    if (uncommonDrop == 1)
				    {
				        Item.NewItem(new EntitySource_Loot(NPC), NPC.position, NPC.Size, ModContent.ItemType<DrakeCrystal>(), 1);
				    }
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

		public override void FindFrame(int frameHeight)
		{
			if (!hasBeenFed && NPC.life < NPC.lifeMax)
            {
				NPC.frameCounter += 1.0;
				if (NPC.frameCounter >= 0.0)
				{
					NPC.frameCounter = 9.0;
					NPC.frame.Y += frameHeight;
					if (NPC.frame.Y >= 7)
					{
						NPC.frame.Y = 0;
					}
				}
				return;
			}
			else
			    NPC.frameCounter += 1.0;
			    if (NPC.frameCounter >= 6.0)
			    {
				    NPC.frameCounter = 0.0;
				    NPC.frame.Y += frameHeight;
				    if (NPC.frame.Y >= Main.npcFrameCount[NPC.type])
				    {
					    NPC.frame.Y = 8;
				    }		
			    }
			    return;
		}
	}
}
