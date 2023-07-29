
using Sandbox;
using System;
using System.Linq;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace MyGame;

/// <summary>
/// This is your game class. This is an entity that is created serverside when
/// the game starts, and is replicated to the client. 
/// 
/// You can use this to create things like HUDs and declare which player class
/// to use for spawned players.
/// </summary>
public partial class MyGame : Sandbox.GameManager
{
	/// <summary>
	/// Called when the game is created (on both the server and client)
	/// </summary>
	public MyGame()
	{
		if ( Game.IsClient )
		{
			Game.RootPanel = new Hud();
		}
	}

	private int SpawnIndex { get; set; } = 0;

	/// <summary>
	/// A client has joined the server. Make them a pawn to play with
	/// </summary>
	public override void ClientJoined( IClient client )
	{
		base.ClientJoined( client );

		// Create a pawn for this client to play with
		var pawn = new Pawn();
		client.Pawn = pawn;
		pawn.Respawn();
		pawn.DressFromClient( client );

		if (Game.IsServer)
		{
			// Get all of the spawnpoints
			// This will eventually get the spawn points for the player's assigned arena.
			var spawnpoints = Entity.All.OfType<DuelsSpawnPoint>();

			// chose a random one
			// This will eventually choose one in a way that both players don't have the same one.
			var guid = Guid.NewGuid();
			var randomSpawnPoint = spawnpoints.OrderBy( x => guid ).FirstOrDefault();

			client.SetValue( "spawnpointguid", guid.ToString() );
			client.SetInt( "spawnpoint", SpawnIndex );

			SpawnIndex++;

			// if it exists, place the pawn there
			if ( randomSpawnPoint != null )
			{
				var tx = randomSpawnPoint.Transform;
				tx.Position = tx.Position + Vector3.Up * 50.0f; // raise it up
				pawn.Transform = tx;
			}
		}
	}
}

