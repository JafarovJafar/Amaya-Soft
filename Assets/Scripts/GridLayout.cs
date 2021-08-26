using UnityEngine;

/// <summary>
/// Класс, который упорядочивает дочерние объекты в виде сетки
/// </summary>
public class GridLayout : CustomLayout
{
    [SerializeField] float cellSize;
    [SerializeField] int colsInRow;
    [SerializeField] int maxRowsCount;

    public override void Add(Transform item)
    {
        Transform childItem = item;
        childItem.SetParent(transform);

        Refresh();
    }
    
    private void Refresh()
    {
        if (transform.childCount == 0)
        {
            transform.GetChild(0).localPosition = Vector3.zero;
        }
        else 
        {
            int childCount = transform.childCount;

            int rowsCount = Mathf.CeilToInt(childCount / (float) colsInRow);

            rowsCount = Mathf.Clamp(rowsCount, 1, maxRowsCount);
            
            int colsCount = Mathf.CeilToInt(childCount / (float) rowsCount);

            int currentRow = 0;
            int currentCol = 0;

            float halfSize = cellSize / 2f;

            for (int i = 0; i < childCount; i++)
            {
                transform.GetChild(i).localPosition = new Vector3(
                    cellSize * currentCol - halfSize * (colsCount - 1),
                    halfSize * (rowsCount - 1) - cellSize * currentRow,
                    0
                );

                currentCol++;

                if (currentCol == colsCount)
                {
                    currentRow++;
                    currentCol = 0;
                }
            }
        }
    }
}