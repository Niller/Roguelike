using System.Numerics;
using Client.Configs.View;
using Entitas;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ViewComponent : IComponent
{ 
    public GameObject Value;
}

public class ViewSourceComponent : IComponent
{
    public ViewType ViewType;
}

public class PositionComponent : IComponent
{
    public Vector2 Value;
}

public class RotationComponent : IComponent
{
    public float Value;
}

public class SyncViewComponent : IComponent
{

}

public class MovementComponent : IComponent
{
    public float Speed;
    public bool Move;
}

public class DirectionComponent : IComponent
{
    public Vector2 Value;
}

public class PlayerComponent : IComponent
{

}

public class TestComponent : IComponent
{
    public int X;
}
