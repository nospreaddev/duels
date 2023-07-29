﻿
using Sandbox;
using Sandbox.Controllers;
using Sandbox.Models;
using System.Collections.Generic;
using System.Linq;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace Duels;

/// <summary>
/// This is your game class. This is an entity that is created serverside when
/// the game starts, and is replicated to the client. 
/// 
/// You can use this to create things like HUDs and declare which player class
/// to use for spawned players.
/// </summary>
public partial class Duels : Sandbox.GameManager
{
	/// <summary>
	/// Called when the game is created (on both the server and client)
	/// </summary>
	public Duels()
	{
		if ( Game.IsClient )
		{
			Game.RootPanel = new Hud();
		}
	}

	ArenaController controller = new ArenaController();

	/// <summary>
	/// A client has joined the server. Make them a pawn to play with
	/// </summary>
	public override void ClientJoined( IClient client )
	{
		base.ClientJoined( client );

		controller.AssignAndSpawnAll(client);
	}
}

