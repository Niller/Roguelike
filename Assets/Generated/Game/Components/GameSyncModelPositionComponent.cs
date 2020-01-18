//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SyncModelPositionComponent syncModelPositionComponent = new SyncModelPositionComponent();

    public bool isSyncModelPosition {
        get { return HasComponent(GameComponentsLookup.SyncModelPosition); }
        set {
            if (value != isSyncModelPosition) {
                var index = GameComponentsLookup.SyncModelPosition;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : syncModelPositionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherSyncModelPosition;

    public static Entitas.IMatcher<GameEntity> SyncModelPosition {
        get {
            if (_matcherSyncModelPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SyncModelPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSyncModelPosition = matcher;
            }

            return _matcherSyncModelPosition;
        }
    }
}
