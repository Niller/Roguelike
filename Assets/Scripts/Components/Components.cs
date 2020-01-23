using Assets.Scripts.Configs.Arena;
using Assets.Scripts.Gui;
using Client.Configs.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;

public class ViewComponent : IComponent
{ 
    public GameObject Value;
}

public class RigidbodyComponent : IComponent
{
    public Rigidbody Value;
}

public class ViewSourceComponent : IComponent
{
    public ViewType ViewType;
}

public class ViewParentComponent : IComponent
{
    public Transform Parent;
}

public class PositionComponent : IComponent
{
    public Vector2 Value;
}

public class RotationComponent : IComponent
{
    public float Value;
}

public class SyncViewPositionComponent : IComponent
{

}

public class SyncViewRotationComponent : IComponent
{

}

public class SyncModelPositionComponent : IComponent
{

}

public class MovementComponent : IComponent
{
    public float Speed;
    public bool Move;
}

public class ArenaComponent : IComponent
{
    public ArenaData ArenaData;
    public Rect Rect;
    public float CellSize;
}

public class DirectionComponent : IComponent
{
    public Vector2 Value;
}

public class PlayerComponent : IComponent
{

}

public class NavMeshAgentComponent : IComponent
{
    public NavMeshAgent Agent;
}

public class CameraComponent : IComponent
{
    public Camera Camera;
}

public class FractionComponent : IComponent
{
    [EntityIndex]
    public int Fraction;
    public int EnemyFraction;
}

public class MeleeAttackComponent : IComponent
{
    public float Range;
}

public class MoveToTargetComponent : IComponent
{

}

public class TargetComponent : IComponent
{
    public GameEntity Value;
}

public class HealthComponent : IComponent
{
    public int MaxHealth;
    public int CurrentHealth;
}

public class HealthBarComponent : IComponent
{
    public HealthBarController HealthBar;
}