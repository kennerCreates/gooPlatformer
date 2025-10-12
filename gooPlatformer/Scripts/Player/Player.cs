using Godot;
using gooPlatformer.Configuration;

namespace gooPlatformer.Scripts.Player;

public partial class Player : CharacterBody2D
{
	private MovementInputOptions _inputOptions = new()
	{
		LeftInput = Input.GetActionStrength("left"),
		RightInput = Input.GetActionStrength("right"),
		DownInput = Input.GetActionStrength("down"),
		UpInput = Input.GetActionStrength("up")
	};

	public override void _PhysicsProcess(double delta)
	{
		OnTick(delta);
	}

	private void OnTick(double delta)
	{
		
	}
}