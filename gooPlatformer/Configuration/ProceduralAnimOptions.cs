using System.Numerics;
using Godot;
using Vector2 = Godot.Vector2;

namespace gooPlatformer.Configuration;

public class ProceduralAnimOptions
{
    public int LimbCount { get; init; }
    public int LimbSegmentCount { get; init; }
    public int SegmentTargetSize { get; init; }
    public string SpriteFilepath { get; init; }
    public int CollisionRadius { get; init; }
}