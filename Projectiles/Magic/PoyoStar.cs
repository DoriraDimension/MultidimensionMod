using MultidimensionMod.NPCs.Dungeon;
using MultidimensionMod.NPCs.Bosses.Smiley;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	public class PoyoStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			AIType = ProjectileID.FallingStar;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.FallingStar;
			return true;
		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.type >= ModContent.NPCType<Smiley>() || target.type >= ModContent.NPCType<Darkling>())
			{
				modifiers.FinalDamage += (int)5.0f;
			}
		}
	}
}