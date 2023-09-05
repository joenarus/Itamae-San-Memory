using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGridLayout : LayoutGroup
{
    public int rows;
    public int columns;

    public Vector2 spacing;

    public Vector2 cardSize;

    public override void CalculateLayoutInputVertical()
    {
        if(rows == 0 || columns == 0)
        {
            rows = 5;
            columns = 8;
        }
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;


        float cardWidth = (parentWidth - spacing.x * (columns - 1)) / columns;
        float cardHeight = cardWidth;

        if(cardHeight * rows + spacing.y * (columns - 1) > parentHeight)
        {
            cardHeight = (parentHeight - spacing.y * (rows - 1)) / rows;
            cardWidth = cardHeight;
        }

        cardSize = new Vector2(cardWidth, cardHeight);

        padding.left = Mathf.FloorToInt((parentWidth - columns * cardWidth - spacing.x * (columns - 1)) / 2);
        padding.top = Mathf.FloorToInt((parentHeight - rows * cardHeight - spacing.y * (rows - 1)) / 2);

        for (int i = 0; i < rectChildren.Count; i++)
        {
            int rowCount = i / columns;
            int columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = padding.left + cardSize.x * columnCount + spacing.x * (columnCount);
            var yPos = padding.top + cardSize.y * rowCount + spacing.y * (rowCount);

            SetChildAlongAxis(item, 0, xPos, cardSize.x);
            SetChildAlongAxis(item, 1, yPos, cardSize.y);
        }
    }

    public override void SetLayoutHorizontal()
    {
        return;
    }

    public override void SetLayoutVertical()
    {
        return;
    }
}
