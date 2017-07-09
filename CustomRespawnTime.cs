using Terraria.ModLoader;
using Terraria;
using System;
using Terraria.DataStructures;

namespace CustomRespawnTime
{
	class CustomRespawnTime : Mod
	{
		public CustomRespawnTime()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		public override void Load()
		{
			Config.Load();
		}
	}
	public class CustomRespawnTimePlayer : ModPlayer
	{
		public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
		{
			if(Config.UseOnyxSteelPref)
			{
				player.respawnTimer = 600;
				return;
			}
			
			if(Config.UsePresetTime)
			{
				player.respawnTimer = (int)(Config.RespawnSeconds * 60);
				return;
			}
			
			if(Config.UseMultiplier)
			{
				player.respawnTimer = (int)(player.respawnTimer * Config.RespawnMultiplier);
			}
		}
	}
}