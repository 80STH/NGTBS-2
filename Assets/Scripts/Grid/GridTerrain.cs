using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTerrain : MonoBehaviour
{
    //public static GridTerrain Instance { get; private set; }

    //[Serializable]
    //public struct GridTerrainTypeMaterial
    //{
    //    public GridTerrainType gridTerrainType;
    //    public Material material;
    //}

    //public enum GridTerrainType
    //{
    //    Void,
    //    Grass,
    //    Stone,
    //    Water,
    //}


    //[SerializeField] private List<GridTerrainTypeMaterial> gridTerrainTypeMaterialList;

    ////temporary code
    //private int[,] data =
    //        {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    //        ,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};


    ////temporary code
    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Debug.LogError("There's more than one GridObjects! " + transform + " - " + Instance);
    //        Destroy(gameObject);
    //        return;
    //    }
    //    Instance = this;
    //}
    //public void Start()
    //{
    //    for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
    //    {
    //        for (int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
    //        {
    //            //gridSystemVisualSingleArray[x, z].Show(GetGridVisualTypeMaterial(GridTerrainType.Void));
    //        }
    //    }
    //}

    //private Material GetGridVisualTypeMaterial(GridTerrainType gridTerrainType)
    //{
    //    foreach (GridTerrainTypeMaterial gridTerrainTypeMaterial in gridTerrainTypeMaterialList)
    //    {
    //        if (gridTerrainTypeMaterial.gridTerrainType == gridTerrainType)
    //        {
    //            return gridTerrainTypeMaterial.material;
    //        }
    //    }

    //    Debug.LogError("Could not find GridTerrainTypeMaterial for GridTerrainType " + gridTerrainType);
    //    return null;
    //}
}
