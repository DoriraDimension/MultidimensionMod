/*using MultidimensionMod.Backgrounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace MultidimensionMod
{
    public class ALMenu : ModMenu
    {
        public override Asset<Texture2D> Logo => base.Logo;

        public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/AeiosSun");

        public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/AeiosSun");

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/CaelisForever");

        public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<ExampleSurfaceBackgroundStyle>();

        public override string DisplayName => "Awakened Light Menu";

        public override void OnSelected()
        {
            SoundEngine.PlaySound(new (Mod, "Sounds/Custom/Glitch"));
        }
    }
}*/