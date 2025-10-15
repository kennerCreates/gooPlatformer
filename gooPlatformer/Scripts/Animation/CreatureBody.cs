using Godot;

namespace gooPlatformer.Scripts.Animation;

[GlobalClass]
public partial class CreatureBody : CharacterBody2D
{
    [Export] public int LimbCount = 1;
    [Export] public int LimbSegmentCount = 4;
    [Export] public int SegmentTargetSize = 24;
    [Export] public string SpriteFilepath = "res://Assets/Sprites/circle.png";
    [Export] public int CollisionRadius = 12;
}