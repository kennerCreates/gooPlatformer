using System.Collections.Generic;
using Godot;

namespace gooPlatformer.Scripts;

public partial class ProceduralAnimation : Node2D
{
	[Export] public int SegmentCount = 3;
	[Export] public float SegmentLength = 20;
	[Export] public Texture2D SpriteTexture = GD.Load<Texture2D>("res://Assets/Sprites/circle.png");
	[Export] public float MoveSpeed = 100;
	[Export] public float CollisionRadius = 10;
	[Export] public float Damping = .5f;
	[Export] public float SpringStrength = 2;
	[Export] public float RestReturnSpeed = 2;

	private readonly List<CharacterBody2D> _bodySegments = [];
	private readonly List<Vector2> _restPositions = [];

	// Begin Play
	public override void _Ready()
	{
		for (var i = 0; i < SegmentCount; i++)
		{
			var segment = new CharacterBody2D();

			var sprite = new Sprite2D
			{
				Texture = SpriteTexture,
				Scale = Scale * (1 - i * (float).1),
				Centered = true,
			};
			var collider = new CollisionShape2D();
			collider.Shape = new CircleShape2D { Radius = CollisionRadius * sprite.Scale.X };

			segment.AddChild(sprite);
			segment.AddChild(collider);
			AddChild(segment);

			segment.CollisionLayer = 1;
			segment.CollisionMask = 0;

			segment.Position = Position + new Vector2(i * SegmentLength + SegmentLength, 0);
			_bodySegments.Add(segment);
			_restPositions.Add(segment.Position);
		}
	}

	// On Tick
	public override void _Process(double delta)
	{
		var dt = (float)delta;

		for (var i = 0; i < _bodySegments.Count; i++)
		{
			var segment = _bodySegments[i];
			Vector2 targetPosition;
			var prev = i > 0 ? _bodySegments[i - 1] : null;
			
			if (i > 0)
			{
				var direction = segment.GlobalPosition.DirectionTo(prev.GlobalPosition);
				var distance = segment.GlobalPosition.DistanceTo(prev.GlobalPosition);

				if (distance > SegmentLength)
					segment.GlobalPosition = prev.GlobalPosition - direction * SegmentLength;

				targetPosition = prev.GlobalPosition - direction * SegmentLength;
			}
			else
			{
				targetPosition = GetParent<Node2D>().GlobalPosition;
			}

			var restTarget = _restPositions[i];
			var desiredPosition = targetPosition.Lerp(restTarget, 0.1f);
			var force = (desiredPosition - segment.GlobalPosition) * SpringStrength - segment.Velocity * Damping;

			segment.Velocity += force * dt;
			segment.MoveAndSlide();

			// var toTarget = targetPosition - segment.GlobalPosition;
			// var desiredVelocity = toTarget.Normalized() * MoveSpeed;
			//
			// segment.Velocity = segment.Velocity.Lerp (desiredVelocity, (float)(Damping * delta));
			//
			// segment.MoveAndSlide();

			// if (i == 0)
			// { 
			// 	var direction = (segment.GlobalPosition - GetParent<Node2D>().GlobalPosition).Normalized();
			// 	targetPosition = GetParent<Node2D>().GlobalPosition + direction * SegmentLength;
			// }
			// else
			// {
			// 	var prev = _bodySegments[i - 1];
			// 	var direction = (segment.GlobalPosition - prev.GlobalPosition).Normalized();
			// 	targetPosition = prev.GlobalPosition + direction * SegmentLength;
			// }
			//
			// var segment = _bodySegments[i];
			// var moveDirection = targetPosition - segment.GlobalPosition;
			// segment.Velocity = moveDirection.Normalized() * MoveSpeed;
			// segment.MoveAndSlide();

			// 	if (i <= 0) continue;
			// 	
			// 	var deltaPos = segment.GlobalPosition - prev.GlobalPosition;
			// 	var deltaDistance = deltaPos.Length();
			//
			// 	if (!(deltaDistance > SegmentLength)) continue;
			// 	segment.GlobalPosition =
			// 		segment.GlobalPosition.Lerp(prev.GlobalPosition + deltaPos.Normalized() * SegmentLength, 0.2f);
			//
			// }


		}
	}
}