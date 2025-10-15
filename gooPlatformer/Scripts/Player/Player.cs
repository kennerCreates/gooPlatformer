using Godot;
using gooPlatformer.Configuration;

namespace gooPlatformer.Scripts.Player;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed { get; set; } = 150f;
	[Export] public float Acceleration { get; set; } = 50f;
	private MovementInputOptions InputOptions => new()
	{
		MouseInput = GetGlobalMousePosition(),
		PlayerLocation = GetGlobalPosition(),
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
		MoveAndSlide();
	}
}