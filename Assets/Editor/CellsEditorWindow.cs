using System;
using Assets.Scripts.Configs.Arena;
using UnityEditor;
using UnityEngine;

public class CellsEditorWindow : EditorWindow
{
    private const int CellSize = 20;
    private const int LeftSideWidth = 150;
    private static CellsEditorWindow _window;
    private ArenaData _arenaData;
    private ArenaCell _currentCell;

    public static void Open(ArenaData arenaData)
    {
        if (_window != null)
        {
            _window.Focus();
            return;
        }

        _window = GetWindow<CellsEditorWindow>();
        _window.titleContent = new GUIContent("Cells Editor", EditorGUIUtility.FindTexture("d_ViewToolOrbit On"));
        _window._arenaData = arenaData;
        _window.minSize = _window.maxSize = arenaData.Size * CellSize + new Vector2(LeftSideWidth, 0);
        
    }

    private void OnGUI()
    {
        var fullRect = new Rect(0, 0, position.width - LeftSideWidth, position.height);
        Handles.DrawSolidRectangleWithOutline(fullRect, Color.white, Color.black);
        var lines = new Vector3[_arenaData.Size.x * 2 + _arenaData.Size.y * 2]; 
        for (int i = 0; i < _arenaData.Size.x; i++)
        {
            lines[i*2] = new Vector3(CellSize * i, 0, 0);
            lines[i*2 + 1] = new Vector3(CellSize * i, fullRect.yMax, 0);
        }

        var offset = _arenaData.Size.x * 2;
        for (int i = 0; i < _arenaData.Size.y; i++)
        {
            lines[offset + i * 2] = new Vector3(0, CellSize * i, 0);
            lines[offset + i * 2 + 1] = new Vector3(fullRect.xMax, CellSize * i, 0);
        }

        Handles.color = Color.black;
        Handles.DrawLines(lines);

        for (int i = 0; i < _arenaData.Cells.Length; i++)
        {
            var index = TransformCellIndex(new Vector2Int(i % _arenaData.Size.x, i / _arenaData.Size.x));

            var cell = _arenaData.Cells[i];

            Color? color = null;
            switch (cell.Type)
            {
                case ArenaCellType.PlayerSpawn:
                    color = Color.green;
                    break;
                case ArenaCellType.Obstacle:
                    color = Color.gray;
                    break;
            }

            if (color != null)
            {
                Handles.color = color.Value;
                Handles.DrawSolidRectangleWithOutline(
                    new Rect(index.x * CellSize, index.y * CellSize, CellSize, CellSize), 
                    color.Value, Color.black);
            }

            if (_currentCell != null)
            {
                GUILayout.BeginArea(new Rect(fullRect.xMax, 0, LeftSideWidth, fullRect.height));
                DrawCellInfo();
                GUILayout.EndArea();
            }

            var evt = Event.current;
            if (evt.type == EventType.MouseUp && evt.button == 0)
            {
                var pos = evt.mousePosition;
                if (!fullRect.Contains(pos))
                {
                    return;
                }

                var cellIndex = TransformCellIndex(new Vector2Int((int)(pos.x / CellSize), (int)(pos.y / CellSize)));
                var newCell = _arenaData.Cells[cellIndex.x + cellIndex.y * _arenaData.Size.x];

                if (evt.control)
                {
                    newCell.Type = _currentCell.Type;
                }

                _currentCell = newCell;

                evt.Use();
            }
        }
    }

    private void DrawCellInfo()
    {
        _currentCell.Type = (ArenaCellType)EditorGUILayout.EnumPopup(_currentCell.Type);
    }

    private Vector2Int TransformCellIndex(Vector2Int cellIndex)
    {
        return new Vector2Int(cellIndex.x, _arenaData.Size.y - cellIndex.y - 1);
    }
}