using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MultidimensionMod.Projectiles.Magic;
using MultidimensionMod.Common.Players;
using Terraria.DataStructures;
using Terraria.Audio;
using MultidimensionMod.NPCs.TownNPCs;

namespace MultidimensionMod.Common.Globals.Projectiles
{
    public class MDGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public bool CantHurtDapper;

        public override void AI(Projectile projectile)
        {

        }

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is EntitySource_Parent parent && parent.Entity is NPC npc && npc.type == ModContent.NPCType<MushroomHeir>())
            {
                SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/Gunshot"), projectile.position);
            }
            base.OnSpawn(projectile, source);
        }
    }
}