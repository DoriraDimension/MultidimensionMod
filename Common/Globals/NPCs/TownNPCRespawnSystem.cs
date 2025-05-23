using System.IO;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using MultidimensionMod.NPCs.TownNPCs;
using MultidimensionMod.NPCs.TownPets;

namespace MultidimensionMod.Common.Globals.NPCs
{
    // This class tracks if specific Town NPC have ever spawned in this world. If they have, then their spawn conditions are not required anymore to respawn in the same world. This behavior is new to Terraria v1.4.4 and is not automatic, it needs code to support it.
    // Spawn conditions that can't be undone, such as defeating bosses, would not require tracking like this since those conditions will still be true when the Town NPC attempts to respawn. Spawn conditions checking for items in the player inventory like ExamplePerson does, for example, would need tracking.
    public class TownNPCRespawnSystem : ModSystem
    {
        // Tracks if ExamplePerson has ever been spawned in this world
        public static bool metDorira = false;
        public static bool adoptedDrake = false;

        // Town NPC rescued in the world would follow a similar implementation, the only difference being how the value is set to true.
        // public static bool savedExamplePerson = false;

        public override void ClearWorld()
        {
            metDorira = false;

            adoptedDrake = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag[nameof(metDorira)] = metDorira;

            tag[nameof(adoptedDrake)] = adoptedDrake;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            metDorira = tag.GetBool(nameof(metDorira));

            adoptedDrake = tag.GetBool(nameof(adoptedDrake));

            metDorira |= NPC.AnyNPCs(ModContent.NPCType<Dorira>());

            adoptedDrake |= NPC.AnyNPCs(ModContent.NPCType<TownDrake>());
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(metDorira);

            writer.WriteFlags(adoptedDrake);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out metDorira);

            reader.ReadFlags(out adoptedDrake);
        }
    }
}
