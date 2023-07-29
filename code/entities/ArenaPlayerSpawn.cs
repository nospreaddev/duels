using Sandbox;
using Editor;
using System.Collections.Generic;

[Library( "info_player_start" ), HammerEntity]
[Title( "Player Spawnpoint" ), Category( "Player" ), Icon( "place" )]
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
