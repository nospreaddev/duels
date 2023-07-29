using Sandbox;
using Editor;
using System.Collections.Generic;

[Library( "duels_spawnpoint" ), HammerEntity]
[Title( "Duels Spawnpoint" ), Category( "Player" ), Icon( "place" )]
[EditorModel( "models/editor/playerstart.vmdl" )]
public class SpawnPoint : Entity
{
	/// <summary>
	/// Arena Number
	/// </summary>
	[Property( Title = "Arena Number" )]
	public int ArenaNumber { get; set; } = 0;

	/// <summary>
	/// The side this spawn point is on in it's arena. Each arena should have an A and B spawnpoint.
	/// </summary>
	[Property( Title = "Arena Side" )]
	public List<string> ArenaSide { get; set; } = new List<string>
	{
		"A",
		"B",
	};
}
