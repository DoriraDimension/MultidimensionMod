using MultidimensionMod.Items.Permabuffs;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Common.Players
{
    public class PermabuffPlayer : ModPlayer
    {
        public int mushrune;

        public override void ModifyMaxStats(out StatModifier health, out StatModifier mana)
        {
            health = StatModifier.Default;
            mana = StatModifier.Default;
            mana.Base = mushrune * Mushrune.ManaPerCrystal;

        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)Player.whoAmI);
            packet.Write((byte)mushrune);
            packet.Send(toWho, fromWho);
        }

        public void ReceivePlayerSync(BinaryReader reader)
        {
            mushrune = reader.ReadByte();
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            PermabuffPlayer clone = (PermabuffPlayer)targetCopy;
            clone.mushrune = mushrune;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            PermabuffPlayer clone = (PermabuffPlayer)clientPlayer;

            if (mushrune != clone.mushrune)
                SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
        }

        public override void SaveData(TagCompound tag)
        {
            tag["mushrune"] = mushrune;
        }

        public override void LoadData(TagCompound tag)
        {
            mushrune = tag.GetInt("mushrune");
        }
    }
}
