using MyGame;
using Sandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Controllers
{
	internal class ArenaController
	{
		[ConVar.Client( "duels_reassign_arenas" )]
		[Change( "AssignAndSpawnAll" )]
		public static int DuelsReassignArenas { get; set; } = 0;

		List<DuelsSpawnPoint> SpawnPoints = new List<DuelsSpawnPoint>();


		Logger log = new Logger();

		public void AssignAndSpawnAll(IClient client)
		{
			var pawn = new Pawn();
			client.Pawn = pawn;
			pawn.Respawn();
			pawn.DressFromClient( client );

			if ( Game.IsServer )
			{
				Entity.All.OfType<DuelsSpawnPointEntity>().ToList().ForEach( e =>
				{
					var spawnPoint = new DuelsSpawnPoint( e, 0 );
					SpawnPoints.Add( spawnPoint );
				} );

				log.Info("Total spawnpoints founds: " + SpawnPoints.Count );

				var guid = Guid.NewGuid();
				var randomSpawnPoint = SpawnPoints.OrderBy( x => guid ).FirstOrDefault();

				client.SetValue( "spawnpointguid", guid.ToString() );
				client.SetInt( "spawnpoint", randomSpawnPoint.Index );
				client.SetInt( "arena", randomSpawnPoint.Entity.ArenaNumber );

				if ( randomSpawnPoint != null )
				{
					var tx = randomSpawnPoint.Entity.Transform;
					tx.Position = tx.Position + Vector3.Up * 50.0f; // Raise player spawn
					pawn.Transform = tx;

					log.Info( "spawn point " + randomSpawnPoint.Index );
				}
			}
		}
	}
}
