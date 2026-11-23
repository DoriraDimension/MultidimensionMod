using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Rarities.Souls;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MultidimensionMod.Items.Souls
{
    public abstract class SoulItem : ModItem
    {
        public bool Synched = false;
        public int SynchProgress;
        public int SynchDuration = 1800;
        public virtual bool RequiresHardmodeToDecipher => false;
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {

        }

        public override bool CanUseItem(Player player)
        {
            if (Synched)
                return true;
            else
                return false;
        }

        public virtual string InsertDialogue => "blank";

        public virtual string SynchingDialogue => "blank";
        public virtual string SynchingDialogue2 => "blank";
        public virtual string SynchingDialogue3 => "blank";

        public virtual string SynchingEndDialogue => "blank";

        public override void SaveData(TagCompound tag)
        {
            tag["Synched"] = Synched;
            tag["SynchProgress"] = SynchProgress;
        }

        public override void LoadData(TagCompound tag)
        {
            Synched = tag.GetBool("Synched");
            SynchProgress = tag.GetInt("SynchProgress");
        }

        //Advance the Synchronization process.
        public bool AdvanceSynch()
        {
            if (Synched)
                return true;

            SynchProgress++;

            if (SynchProgress >= 1800)
            {
                SynchProgress = 1800;
                Synched = true;
                return true;
            }

            return false;
        }
    }
}