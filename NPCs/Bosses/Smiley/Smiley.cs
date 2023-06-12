using MultidimensionMod.Items.Vanity;
using MultidimensionMod.Items.Bags;
using MultidimensionMod.Items.Pets;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Placeables.Trophies;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Weapons.Melee.Swords;
using MultidimensionMod.Items.Weapons.Ranged.Others;
using MultidimensionMod.Items.Weapons.Magic.Others;
using MultidimensionMod.Items.Weapons.Summon;
using MultidimensionMod.Common.Systems;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Bosses.Smiley

{
	[AutoloadBossHead]

	public class Smiley : ModNPC
	{
		public float Timer;
		int backupTimer = 0;
		bool canDie = false;
		int darkling;
		int expertDarkling;
		Vector2 moveTo;
		bool phase2 = false;
		Vector2 dashPos;
		bool animatedStart = false;
		int charges = 0;
		float shotType = -1;
		int nextTimeStamp = 60 * 5;
		int ProjectileTimeStamp;
		bool startLeft = Main.rand.NextBool();
		private bool phase1 = false;
		int fuckYou = 0;
		public static int phase2HeadSlot = -1;
		private int bossMode
		{
			get => (int)NPC.ai[0];
			set => NPC.ai[0] = value;
		}
		private int bossTime
		{
			get => (int)NPC.ai[1];
			set => NPC.ai[1] = value;
		}

		public override void Load()
		{
			// We want to give it a second boss head icon, so we register one
			string texture = BossHeadTexture + "2"; // Our texture is called "ClassName_Head_Boss_SecondStage"
			phase2HeadSlot = Mod.AddBossHeadTexture(texture, -1); // -1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
		}

		public override void BossHeadSlot(ref int index)
		{
			int slot = phase2HeadSlot;
			if (phase2 && slot != -1)
			{
				// If the boss is in its second stage, display the other head icon instead
				index = slot;
			}
		}

		public override void SetStaticDefaults()
        {
			Main.npcFrameCount[NPC.type] = 10;

		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 10000;
			NPC.damage = 20;
			NPC.defense = 0;
			NPC.knockBackResist = 0f;
			NPC.dontTakeDamage = true;
			NPC.alpha = 255;

			NPC.width = 88;
			NPC.height = 88;
			NPC.value = Item.buyPrice(0, 10, 0, 0);
			NPC.npcSlots = 5f;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.netUpdate = true;
			NPC.alpha = 255;
			//NPC.BossBar = ModContent.GetInstance<SmileyBossBar>();
			if (!Main.dedServ)
			{
				Music = MusicID.Boss2;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			int startFrame = 0;
			int finalFrame = 5;
			if (NPC.alpha >= 0)
			{

			}
			if (phase1)
			{
				int frameSpeed = 5;
				NPC.frameCounter += 0.5f;
				if (NPC.frameCounter > frameSpeed)
				{
					NPC.frameCounter = 0;
					NPC.frame.Y += frameHeight;

					if (NPC.frame.Y > finalFrame * frameHeight)
					{
						NPC.frame.Y = startFrame * frameHeight;
					}
				}
			}
			if (phase2)
			{
				startFrame = 6;
				finalFrame = Main.npcFrameCount[NPC.type] - 1;

				if (NPC.frame.Y < finalFrame * frameHeight)
				{
					NPC.frame.Y = startFrame * frameHeight;
				}
			}
		}

		public int visibilityTimer = 0;
		public int spawnThingie = 0;
		public override void AI()
        {
			//Starts off invisible, after a couple ticks, the NPC slowly becomes visible. When he reaches full visibility, the fight starts
			visibilityTimer++;
			if (visibilityTimer >= 100)
            {
				NPC.alpha--;
				visibilityTimer = 100;
            }
			if (NPC.alpha <= 0)
            {
				NPC.dontTakeDamage = false;
				phase1 = true;
            }
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
			{
				NPC.TargetClosest();
			}
			Player player = Main.player[NPC.target];
			if (!phase1)
            {
                spawnThingie++;
				if (spawnThingie >= 1)
                {
					NPC.position = new Vector2(Main.rand.NextBool(2) ? player.Center.X - 180 : player.Center.X + 180, player.Center.Y - 60);
					spawnThingie = 2;
				}
			}
			if (player.dead)
			{
				NPC.velocity.Y -= 0.04f;
				NPC.EncourageDespawn(10);
				return;
			}
			if (phase1)
            {
				if (NPC.life <= NPC.lifeMax / 2)
				{
					//phase1 = false;
					//NPC.dontTakeDamage = true;
				}
			}
			if (phase2)
            {

            }
		}

		private void shootTrackedProjAtPlayer(int type, int projAngle, float projSpeed, int damage, Vector2 position, Vector2 targetPosition, Player player)
		{
			Projectile.NewProjectile(NPC.GetSource_FromAI(), position, (NPC.DirectionTo(targetPosition + (player.velocity * 25)).RotatedBy(MathHelper.ToRadians(projAngle))) * projSpeed, type, damage, 0f, Main.myPlayer);
		}

		public override void OnKill()
		{
			NPC.SetEventFlagCleared(ref DownedSystem.downedSmiley, -1);
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.HealingPotion;
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			for (int i = 0; i < 15; i++)
			{
				NPCloot.Add(ItemDropRule.Common(ItemID.Heart));
			}
			Main.NewText("Smiley has been defeated!", Color.Purple);
			NPCloot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 11, 11));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DarkMatterClump>(), 1, 15, 20));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<SmileySoulshard>()));
			NPCloot.Add(ItemDropRule.BossBag(ModContent.ItemType<SmileyBag>()));
			if (Main.rand.NextBool(10))
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<SmileyTrophy>()));
			}
			if (Main.rand.NextBool(10))
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<LonelyWarriorsVisor>()));
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DarkCloak>()));
			}
			if (Main.rand.NextBool(8))
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<CuteEmoji>()));
			}
			int choice = Main.rand.Next(4);
			if (choice == 0)
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<LonelySword>()));
			}
			if (choice == 1)
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DarkMatterLauncher>()));
			}
			if (choice == 2)
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<SmileySmile>()));
			}
			if (choice == 3)
			{
				NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<DarkRebels>()));
			}
		}
	}
}