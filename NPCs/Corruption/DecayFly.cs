using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Corruption
{
	public class DecayFly : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Decay Fly");
			DisplayName.AddTranslation(GameCulture.German, "Verwesungsfliege");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Bee];
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Bee);
			npc.width = 18;
			npc.height = 18;
			npc.damage = 10;
			npc.defense = 4;
			npc.lifeMax = 10;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 5;
			aiType = NPCID.Bee;
			animationType = NPCID.Bee;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Corruption.Chance * 0.2f;
		}
	}
}