using System.Collections.Generic;
using Godot;
using Vector2 = Godot.Vector2;

namespace gooPlatformer.Scripts;

public partial class RootAnimation : Node2D
{
	[Export] public int SegmentCount = 2;
	[Export] public float SegmentLength = 50f;
	[Export] public float FollowTightness = 100f;
	[Export] public float WiggleAmplitude = 4f;
	[Export] public float WiggleSpeed = 2f;
	[Export] public Texture2D SpriteTexture = GD.Load<Texture2D>("res://Assets/Sprites/circle.png");
	
	private readonly List<Node2D> _segments = [];
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Create chain segments dynamically
		for (var i = 0; i < SegmentCount; i++)
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

	//Called every frame. 'delta' has been the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var time = Time.GetTicksMsec()/1000f;
		
		var target = GetParentGlobalPosition();
		SmoothFollowTargetWithFirstSegment(delta, target);
		ApplyWiggleEffectToSegment(time);
		
		for (var i = 1; i < _segments.Count; i++)
		{
			var prev = _segments[i - 1];
			var current = _segments[i];
			
			var dir = CalculateSegmentDirection(prev, current);
			var desiredPos = CalculateDesiredPosition(prev, ref dir);
			SmoothlyFollowToDesiredPosition(delta, current, desiredPos);
			RotateSegmentToFacePrevious(current, dir);
		}
	}

	private Vector2 GetParentGlobalPosition()
	{
		var target = GetParent<Node2D>().GlobalPosition;
		return target;
	}

	private void SmoothFollowTargetWithFirstSegment(double delta, Vector2 target)
	{
		_segments[0].GlobalPosition = _segments[0].GlobalPosition.Lerp(target, FollowTightness * (float)delta);
	}

	private void ApplyWiggleEffectToSegment(float time)
	{
		_segments[0].Position = new Vector2(0,Mathf.Sin(time * WiggleSpeed) * WiggleAmplitude);
	}

	private Vector2 CalculateDesiredPosition(Node2D prev, ref Vector2 dir)
	{
		dir = dir.Normalized();
		var desiredPos = prev.GlobalPosition - dir * SegmentLength;
		return desiredPos;
	}

	private static Vector2 CalculateSegmentDirection(Node2D prev, Node2D current)
	{
		var dir = prev.GlobalPosition - current.GlobalPosition;
		return dir;
	}

	private static void RotateSegmentToFacePrevious(Node2D current, Vector2 dir)
	{
		current.Rotation = dir.Angle();
	}

	private void SmoothlyFollowToDesiredPosition(double delta, Node2D current, Vector2 desiredPos)
	{
		current.GlobalPosition = current.GlobalPosition.Lerp(desiredPos, FollowTightness* (float)delta);
	}
}