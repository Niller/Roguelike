//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MeleeAttackComponent meleeAttack { get { return (MeleeAttackComponent)GetComponent(GameComponentsLookup.MeleeAttack); } }
    public bool hasMeleeAttack { get { return HasComponent(GameComponentsLookup.MeleeAttack); } }

    public void AddMeleeAttack(float newRange) {
        var index = GameComponentsLookup.MeleeAttack;
        var component = (MeleeAttackComponent)CreateComponent(index, typeof(MeleeAttackComponent));
        component.Range = newRange;
        AddComponent(index, component);
    }

    public void ReplaceMeleeAttack(float newRange) {
        var index = GameComponentsLookup.MeleeAttack;
        var component = (MeleeAttackComponent)CreateComponent(index, typeof(MeleeAttackComponent));
        component.Range = newRange;
        ReplaceComponent(index, component);
    }

    public void RemoveMeleeAttack() {
        RemoveComponent(GameComponentsLookup.MeleeAttack);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMeleeAttack;

    public static Entitas.IMatcher<GameEntity> MeleeAttack {
        get {
            if (_matcherMeleeAttack == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MeleeAttack);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMeleeAttack = matcher;
            }

            return _matcherMeleeAttack;
        }
    }
}