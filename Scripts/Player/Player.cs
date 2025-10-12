using Godot;

namespace gooPlatformer.Scripts.Player;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 300.0f;
	[Export] public float Acceleration = 500.0f;
	[Export] public float Friction = 1200.0f;
	[Export] public float JumpVelocity = -400.0f;
	[Export] public float AirAcceleration = 0.5f;

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;

		var inputDir = InputDir();

		var isMoving = inputDir != Vector2.Zero;

		// 4 Way movement
		if (isMoving)
		{
			// Context aware Acceleration
			var currentAccel = IsOnFloor() ? Acceleration : Acceleration * AirAcceleration;
			
			// Accelerate toward target speed
			var targetVelocity = inputDir * Speed;
			velocity = velocity.MoveToward(targetVelocity, currentAccel * (float)delta);
			
		}
		else
		{
			// Decelerate smoothly to zero
			velocity = velocity.MoveToward(Vector2.Zero, Friction * (float)delta);
		}

		var sprite = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
		if (sprite != null && inputDir.X != 0)
			sprite.FlipH = inputDir.X < 0;
		
		// Move
		Velocity = velocity;
		MoveAndSlide();
	}

	private static Vector2 InputDir()
	{
		var inputX = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		var inputY = Input.GetActionStrength("down") - Input.GetActionStrength("up");
		var inputDir = new Vector2(inputX, inputY).Normalized();
		return inputDir;
	}
}