using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Critters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.NPCs.Critters
{
	internal class BabyGlowmarin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Baby Glowmarin");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Shark];
			Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Shimmerfly;
        }

		public override void SetDefaults()
		{
			NPC.width = 34;
			NPC.height = 22;
			NPC.aiStyle = 16;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit51;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.CloneDefaults(NPCID.Goldfish);
			NPC.catchItem = (short)ModContent.ItemType<BabyGlowmarinItem>();
			NPC.friendly = true; 
			AIType = NPCID.Goldfish;
			AnimationType = NPCID.Shark;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<BabyGlowmarinBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.BabyGlowmarin")
			});
		}

		public override bool? CanBeHitByItem(Player player, Item item)
		{
			return true;
		}

		public override bool? CanBeHitByProjectile(Projectile projectile)
		{
			return true;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.PlayerSafe && Main.hardMode && NPC.downedMechBossAny ? SpawnCondition.OceanMonster.Chance * 0.30f : 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				for (int i = 0; i < 6; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Worm, 2 * hit.HitDirection, -2f);
					if (Main.rand.NextBool(2))
					{
						Main.dust[dust].noGravity = true;
						Main.dust[dust].scale = 1.2f * NPC.scale;
					}
					else
					{
						Main.dust[dust].scale = 0.7f * NPC.scale;
					}
				}
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/BabyMarinGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/BabyMarinGore2").Type, 1);
			}
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D fish = ModContent.Request<Texture2D>(NPC.ModNPC.Texture).Value;
            Texture2D glow = ModContent.Request<Texture2D>(NPC.ModNPC.Texture + "_Glow").Value;
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(fish, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, drawColor, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            spriteBatch.Draw(glow, NPC.Center + new Vector2(0f, -5f) - screenPos, NPC.frame, Color.White, NPC.rotation, NPC.frame.Size() / 2, NPC.scale, effects, 0);
            return false;
        }

    }
}
