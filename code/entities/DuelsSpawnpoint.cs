using Sandbox;
using Editor;
using System.Collections.Generic;

[Library( "duels_spawnpoint" ), HammerEntity]
[Title( "Duels Spawnpoint" ), Category( "Player" ), Icon( "place" )]
[EditorModel( "models/editor/playerstart.vmdl" )]
public class SpawnPoint : Entity
{
	/// <summary>
	/// The arena numbner this spawnpoint is in. You can only assign 2 spawnpoints to an arena.
	/// </summary>
	[Property( Title = "Arena Number" )]
	public int ArenaNumber { get; set; } = 0;
}
