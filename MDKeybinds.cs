using Terraria.ModLoader;

namespace MultidimensionMod
{
	public class MDKeybinds : ModSystem
	{
		public static ModKeybind RoseScarfKey 
		{ 
			get; 
			private set; 
		}

		public override void Load()
		{
			RoseScarfKey = KeybindLoader.RegisterKeybind(Mod, "Rose Venom", "Y");
		}

		public override void Unload()
		{
			RoseScarfKey = null;
		}
	}
}