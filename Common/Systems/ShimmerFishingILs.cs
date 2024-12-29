using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.UI;

namespace MultidimensionMod.Common.Systems
{
    public class ShimmerFishingILs : ModSystem
    {
        //Code is based off of a mod called Auto Fisher
        /*public override void Load()
        {
            Terraria.IL_Projectile.AI_061_FishingBobber += IL_Projectile_AI_061_FishingBobber;
        }

        private void IL_Projectile_AI_061_FishingBobber(ILContext il)
        {
            ILCursor c = new(il);
            c.GotoNext(MoveType.After, i => i.MatchLdcI4(out int value) && value is 1);
            c.EmitDelegate(KillBobber);
            c.GotoNext(MoveType.After, i => i.MatchLdcI4(out int value) && value is 1);
            c.EmitDelegate(KillBobber);
            ILCursor c2 = new(il);
            c2.GotoNext(MoveType.After, i => i.MatchLdfld<Entity>(nameof(Entity.shimmerWet)));
            c2.EmitDelegate(ShimmerWet);
        }
        private static bool KillBobber(bool source)
        {
            return source;
        }
        private static bool ShimmerWet(bool source)
        {
            return false;
        }*/
    }
}