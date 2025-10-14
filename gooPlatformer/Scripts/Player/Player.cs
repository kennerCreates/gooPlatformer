using Godot;
using gooPlatformer.Configuration;

namespace gooPlatformer.Scripts.Player;

public partial class Player : CharacterBody2D
{
	private MovementInputOptions InputOptions => new()
	{
		MouseInput = GetGlobalMousePosition(),
		PlayerLocation = GetGlobalPosition(),
		Speed = 150.0f,
		Acceleration = 50.0f,
		RotationSpeed = 25f
	};

	public override void _PhysicsProcess(double delta)
	{
		var dt = (float)delta;
		OnTick(dt);
	}

	private void OnTick(float dt)
	{
		Velocity = MovementInputUtils.VelocityForTick(Velocity, dt, InputOptions);
		LookAt(InputOptions.MouseInput);
		//Rotation = MovementInputUtils.InterpolatedLookAtLocation(InputOptions, dt);
		MoveAndSlide();
	}
}