using System.IO;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;
using Terraria;
using MultidimensionMod.NPCs.TownNPCs;
using MultidimensionMod.NPCs.TownPets;

namespace MultidimensionMod.Common.Globals.NPCs
{
    public class TownNPCRespawnSystem : ModSystem
    {
        public static bool metAdmin = false;
        public static bool adoptedDrake = false;

        public override void ClearWorld()
        {
            metAdmin = false;

            adoptedDrake = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag[nameof(metAdmin)] = metAdmin;

            tag[nameof(adoptedDrake)] = adoptedDrake;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            metAdmin = tag.GetBool(nameof(metAdmin));

            adoptedDrake = tag.GetBool(nameof(adoptedDrake));

            metAdmin |= NPC.AnyNPCs(ModContent.NPCType<Admin>());

            adoptedDrake |= NPC.AnyNPCs(ModContent.NPCType<TownDrake>());
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(metAdmin);

            writer.WriteFlags(adoptedDrake);
        }

        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out metAdmin);

            reader.ReadFlags(out adoptedDrake);
        }
    }
}
