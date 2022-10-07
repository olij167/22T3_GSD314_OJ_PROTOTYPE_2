//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CodeMonkey.Utils;

//public class GridTest : MonoBehaviour
//{
//    private Grid<bool> grid;
//    [SerializeField] int width, height;
//    [SerializeField] float cellSize;
//    [SerializeField] Vector3 originPosition;
//    void Start()
//    {
//        grid = new Grid<bool>(width, height, cellSize, originPosition);
//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            // for 2D camera
//            grid.SetValue(UtilsClass.GetMouseWorldPosition(), true);

//        }

//        if (Input.GetMouseButtonDown(1))
//        {
//            // for 2D camera
//            Debug.Log("Value = " + grid.GetValue(UtilsClass.GetMouseWorldPosition()));

//        }

//    }
//}
