using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridFieldGenerator : MonoBehaviour
{
    public static GridFieldGenerator Instance { get; private set; }

    [SerializeField] private Transform[] gridFieldTilePrefab;

    private GridFieldGenerator[,] gridFieldGeneratorArray;

    //temporary code
    private int[,] data =
            {{0, 0, 0, 3, 3, 3, 3, 3, 3, 0, 0, 0}
            ,{0, 0, 3, 1, 1, 1, 1, 1, 3, 0, 0, 0}
            ,{0, 0, 3, 1, 1, 1, 1, 1, 1, 3, 0, 0}
            ,{0, 3, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0}
            ,{0, 3, 1, 2, 1, 1, 1, 1, 1, 1, 3, 0}
            ,{3, 1, 1, 1, 1, 2, 1, 1, 1, 1, 3, 0}
            ,{0, 3, 1, 1, 1, 1, 1, 2, 1, 1, 3, 0}
            ,{0, 3, 1, 1, 1, 1, 1, 1, 1, 3, 0, 0}
            ,{0, 0, 3, 1, 1, 2, 1, 1, 1, 3, 0, 0}
            ,{0, 0, 3, 1, 1, 1, 1, 1, 3, 0, 0, 0}
            ,{0, 0, 0, 3, 3, 3, 3, 3, 3, 0, 0, 0}};
    private void Start()
    {
        gridFieldGeneratorArray = new GridFieldGenerator[
            LevelGrid.Instance.GetWidth(),
            LevelGrid.Instance.GetHeight()
        ];

        for (int z = 0; z < LevelGrid.Instance.GetWidth(); z++)
        {
            for (int x = 0; x < LevelGrid.Instance.GetHeight(); x++)
            {
                //why z,x?????
                GridPosition gridPosition = new GridPosition(z, x);
                //rewrite?
                Instantiate(gridFieldTilePrefab[data[x,z]], LevelGrid.Instance.GetWorldPosition(gridPosition), transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
            }
        }

        //UnitActionSystem.Instance.OnSelectedActionChanged += UnitActionSystem_OnSelectedActionChanged;
        //LevelGrid.Instance.OnAnyUnitMovedGridPosition += LevelGrid_OnAnyUnitMovedGridPosition;

        //UpdateGridVisual();

        //for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
        //{
        //    for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
        //    {
        //        gridSystemVisualSingleArray[x, z].Show(GetGridVisualTypeMaterial(GridVisualType.White));
        //    }
        //}
    }
}
