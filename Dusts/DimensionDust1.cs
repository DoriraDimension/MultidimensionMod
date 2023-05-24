using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
	public class DimensionDust1 : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
			dust.velocity.X *= 0.3f;
			dust.scale *= 0.7f;
		}

		public override bool Update(Dust dust)
		{
			if (dust.customData != null && dust.customData is int)
			{
				if ((int)dust.customData == 0)
				{
					if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
					{
						dust.scale *= 0.9f;
						dust.velocity *= 0.25f;
					}
				}
				else if ((int)dust.customData == 1)
				{
					dust.scale *= 0.98f;
					dust.velocity.Y *= 0.98f;
					if (Collision.SolidCollision(dust.position - Vector2.One * 5f, 10, 10) && dust.fadeIn == 0f)
					{
						dust.scale *= 0.9f;
						dust.velocity *= 0.25f;
					}
				}
			}
			if (!dust.noGravity)
			{
				dust.velocity.Y += 0.05f;
			}
			if (dust.type == 229 || dust.type == 228)
			{
				if (dust.customData != null && dust.customData is NPC)
				{
					NPC nPC = (NPC)dust.customData;
					dust.position += nPC.position - nPC.oldPos[1];
				}
				else if (dust.customData != null && dust.customData is Player)
				{
					Player player5 = (Player)dust.customData;
					dust.position += player5.position - player5.oldPosition;
				}
				else if (dust.customData != null && dust.customData is Vector2)
				{
					Vector2 vector3 = (Vector2)dust.customData - dust.position;
					if (vector3 != Vector2.Zero)
					{
						vector3.Normalize();
					}
					dust.velocity = (dust.velocity * 4f + vector3 * dust.velocity.Length()) / 5f;
				}
			}
			if (!dust.noGravity)
			{
				dust.velocity.Y += 0.05f;
			}
			if (dust.customData != null && dust.customData is NPC)
			{
				NPC nPC = (NPC)dust.customData;
				dust.position += nPC.position - nPC.oldPos[1];
			}
			else if (dust.customData != null && dust.customData is Player)
			{
				Player player5 = (Player)dust.customData;
				dust.position += player5.position - player5.oldPosition;
			}
			else if (dust.customData != null && dust.customData is Vector2)
			{
				Vector2 vector3 = (Vector2)dust.customData - dust.position;
				if (vector3 != Vector2.Zero)
				{
					vector3.Normalize();
				}
				dust.velocity = (dust.velocity * 4f + vector3 * dust.velocity.Length()) / 5f;
			}
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X;
			dust.scale -= 0.1f;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}