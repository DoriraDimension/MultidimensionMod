using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Dusts
{
	public class Moondust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.scale = 1f;
			dust.alpha = 0;
		}

		public override bool Update(Dust dust)
		{
			dust.alpha--;
			dust.position += dust.velocity;
			dust.rotation += 6f;
			dust.scale -= 0.03f;
			if (dust.scale < 0.1f)
			{
				dust.active = false;
			}
			else
			{
				float strength = dust.scale / 2f;
				Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 255f * 0.5f * strength, dust.color.G / 255f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
			}
			return false;
		}
	}
}