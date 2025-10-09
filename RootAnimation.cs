using Godot;
using System.Collections.Generic;
using Vector2 = Godot.Vector2;

namespace gooPlatformer;

public partial class RootAnimation : Node2D
{
	[Export] public int SegmentCount = 3;
	[Export] public float SegmentLength = 12f;
	[Export] public float FollowTightness = 10f;
	[Export] public float WiggleAmplitude = 4f;
	[Export] public float WiggleSpeed = 2f;
	[Export] public Texture2D SpriteTexture = GD.Load<Texture2D>("res://Assets/Sprites/circle.png");
	
	private List<Node2D> _segments = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Create chain segments dynamically
		for (int i = 0; i < SegmentCount; i++)
		{
			var segment = new Node2D();
			var sprite = new Sprite2D();
			sprite.Texture = SpriteTexture;
			sprite.Centered = true;
			segment.AddChild(sprite);
			AddChild(segment);
			_segments.Add(segment);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float time = (float)Time.GetTicksMsec()/1000f;
		
		// First segment follows target position
		// Next segments follow previous segment
		for (int i = 1; i < _segments.Count; i++)
		{
			var prev = _segments[i - 1];
			var current = _segments[i];
			
			// Get direction
			Vector2 dir = prev.GlobalPosition - current.GlobalPosition;
			float distance = dir.Length();

			if (distance > 0.001f)
			{
				dir = dir.Normalized();
				// Desired position keeps chain segmentLength apart
				Vector2 desiredPos = prev.GlobalPosition - dir * SegmentLength;
				
				// Smoothly follow towards desired position
				current.GlobalPosition = current.GlobalPosition.Lerp(desiredPos, FollowTightness* (float)delta);
				
				// Rotate to face previous
				current.Rotation = dir.Angle();
			}
		}
	}
}