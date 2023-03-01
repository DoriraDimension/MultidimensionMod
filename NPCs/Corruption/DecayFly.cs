using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace MultidimensionMod.NPCs.Corruption
{
	public class DecayFly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Decay Fly");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Bee];
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.Bee);
			NPC.width = 18;
			NPC.height = 18;
			NPC.damage = 10;
			NPC.defense = 4;
			NPC.lifeMax = 10;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 10);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 5;
			AIType = NPCID.Bee;
			AnimationType = NPCID.Bee;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Corruption.Chance * 0.2f;
		}
	}
}