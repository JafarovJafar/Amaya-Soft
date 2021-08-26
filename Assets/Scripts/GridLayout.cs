using UnityEngine;

/// <summary>
/// Класс, который упорядочивает дочерние объекты в виде сетки
/// </summary>
public class GridLayout : MonoBehaviour
{
    private float _cellSize;
    private int _colsInRow;
    private int _maxRowsCount;

    public void Init(float cellSize,int colsInRow, int maxRowsCount)
    {
        _cellSize = cellSize;
        _colsInRow = colsInRow;
        _maxRowsCount = maxRowsCount;
    }

    public void Add(Transform item)
    {
        Transform childItem = item;
        childItem.SetParent(transform);

        Refresh();
    }
    
    public void Refresh()
    {
        if (transform.childCount == 0)
        {
            transform.GetChild(0).localPosition = Vector3.zero;
        }
        else 
        {
            int childCount = transform.childCount;

            int rowsCount = Mathf.CeilToInt(childCount / (float) _colsInRow);

            rowsCount = Mathf.Clamp(rowsCount, 1, _maxRowsCount);
            
            int colsCount = Mathf.CeilToInt(childCount / (float) rowsCount);

            int currentRow = 0;
            int currentCol = 0;

            float halfSize = _cellSize / 2f;

            for (int i = 0; i < childCount; i++)
            {
                transform.GetChild(i).localPosition = new Vector3(
                    _cellSize * currentCol - halfSize * (colsCount - 1),
                    halfSize * (rowsCount - 1) - _cellSize * currentRow,
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