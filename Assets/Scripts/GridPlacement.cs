using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacement : MonoBehaviour
{
    private Grid<GridObject> grid;
    [SerializeField] int width, height;
    [SerializeField] float cellSize;
    [SerializeField] Transform inventory;
    //[SerializeField] Sprite testTransform;
    void Awake()
    {
        grid = new Grid<GridObject>(width, height, cellSize, inventory.position, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }

    public class GridObject
    {
        private Grid<GridObject> grid;
        private int x, y;

        public GridObject(Grid<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return x + ", " + y;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(testTransform, Mouse3D.GetMouseWorldPosition(), Quaternion.identity);
        }
    }
}
