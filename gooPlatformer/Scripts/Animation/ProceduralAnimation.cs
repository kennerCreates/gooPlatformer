using System.Net.Mime;
using Godot;
using gooPlatformer.Configuration;
using gooPlatformer.GodotInterface;
using gooPlatformer.GodotInterface.Models;

namespace gooPlatformer.Scripts.Animation;

public partial class ProceduralAnimation : Node2D
{
	private ProceduralAnimOptions InputOptions => new()
	{
		LimbCount = 1,
		LimbSegmentCount = 4,
		SegmentTargetSize = 24,
		SpriteFilepath = "res://Assets/Sprites/circle.png",
		CollisionRadius = 12
	};
	public override void _Ready()
	{
		BeginPlay();
	}
	
	public override void _Process(double delta)
	{
		var dt = (float)delta;
		OnTick(dt);
	}

	private void BeginPlay()
	{
		// var collisionCircle = ProceduralAnimUtils.CreateCollisionCircle(InputOptions);
		// var godotVersion = collisionCircle.ToGodotCollisionShape2D();
	}

	private void OnTick(float dt)
	{
		
	}
}