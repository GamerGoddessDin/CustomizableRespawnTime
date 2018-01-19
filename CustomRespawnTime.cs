using Terraria.ModLoader;
using Terraria;
using System;
using Terraria.DataStructures;
using System.IO;


namespace CustomRespawnTime {
	class CustomRespawnTime : Mod {
		public static string GithubUserName { get { return "GamerGoddessDin"; } }
		public static string GithubProjectName { get { return "CustomizableRespawnTime"; } }

		public static string ConfigFileRelativePath {
			get { return Config.SubConfigFolder + Path.DirectorySeparatorChar + Config.ConfigFileName; }
		}

		public static void ReloadConfigFromFile() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reload configs outside of single player." );
			}
			Config.Load();
		}


		////////////////

		public CustomRespawnTime() {
			Properties = new ModProperties() {
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
		public override void Load() {
			Config.Load();
		}
	}



	public class CustomRespawnTimePlayer : ModPlayer {
		public override void Kill( double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource ) {
			if( Config.UseOnyxSteelPref ) {
				player.respawnTimer = 600;
				return;
			}

			if( Config.UsePresetTime ) {
				player.respawnTimer = (int)( Config.RespawnSeconds * 60 );
				return;
			}

			if( Config.UseMultiplier ) {
				player.respawnTimer = (int)( player.respawnTimer * Config.RespawnMultiplier );
			}
		}
	}
}