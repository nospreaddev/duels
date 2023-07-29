using Sandbox;

namespace Duels;

public partial class Logger
{
	private Sandbox.Diagnostics.Logger Log { get; set; } = new Sandbox.Diagnostics.Logger( "MainLog" );

	public void Info( string message )
	{
		Log.Info( $"{(Game.IsServer ? "Server:" : "Client:")} {message}" );
	}
}
