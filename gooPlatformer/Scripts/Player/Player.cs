using Godot;
using gooPlatformer.Configuration;

namespace gooPlatformer.Scripts.Player;

public partial class Player : CharacterBody2D
{
	private MovementInputOptions InputOptions => new()
	{
		MouseInput = GetGlobalMousePosition(),
		PlayerLocation = GetGlobalPosition(),
		Speed = 300.0f,
		Acceleration = 500.0f,
	};

	public override void _PhysicsProcess(double delta)
	{
		var dt = (float)delta;
		OnTick(dt);
	}

	private void OnTick(float dt)
	{
		Velocity = MovementInputUtils.VelocityForTick(Velocity, dt, InputOptions);
		MoveAndSlide();
	}
}