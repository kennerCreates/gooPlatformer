using Godot;

namespace gooPlatformer.Scripts;

public partial class ProceduralAnimation : Node2D
{
	public override void _Ready()
	{
		BeginPlay();
	}
	
	public override void _Process(double delta)
	{
		OnTick(delta);
	}

	private void BeginPlay()
	{

	}

	private void OnTick(double delta)
	{
		
	}
}