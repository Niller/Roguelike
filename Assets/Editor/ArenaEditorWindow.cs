using Assets.Scripts.Configs.Arena;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class ArenaEditorWindow : EditorWindow
{
    private static ArenaEditorWindow _window;

    private ArenaConfig _arenaConfig;
    private int _currentArenaIndex;
    private ArenaData _currentArenaData;
    private int[] _arenaIndexes;
    private string[] _arenaIndexDisplays;

    [UsedImplicitly]
    [MenuItem("Tools/Roguelike/Arena editor")]
    private static void Open()
    {
        if (_window != null)
        {
            _window.Focus();
            return;
        }

        _window = GetWindow<ArenaEditorWindow>();
        _window.titleContent = new GUIContent("Arena Editor", EditorGUIUtility.FindTexture("d_ViewToolOrbit On"));
    }

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        _arenaConfig =
            EditorGUILayout.ObjectField("Arena config", _arenaConfig, typeof(ArenaConfig), false) as ArenaConfig;
        if (EditorGUI.EndChangeCheck())
        {
            if (_arenaConfig != null)
            {
                _arenaIndexes = new int[_arenaConfig.Arenas.Length];
                _arenaIndexDisplays = new string[_arenaConfig.Arenas.Length];
                for (int i = 0; i < _arenaIndexes.Length; i++)
                {
                    _arenaIndexes[i] = i;
                    _arenaIndexDisplays[i] = i.ToString();
                }
            }
        }

        if (_arenaConfig == null || _arenaConfig.Arenas.Length == 0)
        {
            return;
        }

        _currentArenaIndex = EditorGUILayout.IntPopup("Arena", _currentArenaIndex, _arenaIndexDisplays, _arenaIndexes);
        _currentArenaData = _arenaConfig.Arenas[_currentArenaIndex];

        if (GUILayout.Button("Open editor"))
        {
            CellsEditorWindow.Open(_currentArenaData);
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(_arenaConfig);
            AssetDatabase.Refresh();
        }
  
    }

}
