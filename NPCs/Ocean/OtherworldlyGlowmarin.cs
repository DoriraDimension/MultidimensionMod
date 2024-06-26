﻿using MultidimensionMod.Items.Placeables.Banners;
using MultidimensionMod.Items.Hooks;
using MultidimensionMod.Items.Weapons.Melee.Others;
using MultidimensionMod.Items.Placeables;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;

namespace MultidimensionMod.NPCs.Ocean
{
	public class OtherworldlyGlowmarin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Otherworldly Glowmarin");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Shark];
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Shark);
			NPC.width = 134;
			NPC.height = 38;
			NPC.damage = 120;
			NPC.defense = 30;
			NPC.lifeMax = 350;
			NPC.HitSound = SoundID.NPCHit51;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 11);
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 16;
			AIType = NPCID.Shark;
			AnimationType = NPCID.Shark;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<GlowmarinBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("Mods.MultidimensionMod.Bestiary.Glowmarin")
			});
		}

		public override void ModifyNPCLoot(NPCLoot NPCloot)
		{
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<GlowingKelpHook>(), 7));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<OceanicGlowshard>(), 7));
			NPCloot.Add(ItemDropRule.Common(ModContent.ItemType<Glowseed>(), 5));
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.PlayerSafe && Main.hardMode && NPC.downedMechBossAny ? SpawnCondition.OceanMonster.Chance * 0.18f : 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GlowmarinGore1").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GlowmarinGore2").Type, 1);
				Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, ModContent.Find<ModGore>("MultidimensionMod/GlowmarinGore3").Type, 1);
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
