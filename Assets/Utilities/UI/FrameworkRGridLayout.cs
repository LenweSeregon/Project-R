using System;
using Sirenix.OdinInspector;

namespace com.companyR.frameworkR.Utilities.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class FrameworkRGridLayout : LayoutGroup
    {
        // There is 2 Fill Mode that can we use
        // To understand the 2 fill mode, there is for this example 9 element to fill in the grid layout
        // ====
        // FillMode Width will prioritize the filling by completed a row before starting another one
        // 
        // The result in the grid layout will be 
        // 1 2 3 4 
        // 5 6 7 8
        // 9
        // ====
        // FillMode Height will prioritize the filling by completed a column before starting another one
        // 
        // The result in the grid layout will be
        // 1 5 9 
        // 2 6
        // 3 7
        // 4 8
        public enum FillMode
        {
            RowFirst,
            ColumnFirst
        }

        public enum CellSizeXMode
        {
            Respect,
            MatchHeight,
            AutoCalculate
        }

        public enum CellSizeYMode
        {
            Respect,
            MatchWidth,
            AutoCalculate
        }

        public enum LayoutModeRow
        {
            Fixed,
            AutoCalculate,
        }

        public enum LayoutModeColumn
        {
            Fixed,
            AutoCalculate,
        }


        //public enum 

        [SerializeField] private CellSizeXMode m_CellSizeXMode;
        [SerializeField] private CellSizeYMode m_CellSizeYMode;
        [SerializeField] private LayoutModeRow m_LayoutRowMode;
        [SerializeField] private LayoutModeColumn m_LayoutColumnMode;
        [SerializeField] private FillMode m_FillMode;
        
        [SerializeField] private int m_NbRows;
        [SerializeField] private int m_NbColumns;
        [SerializeField] private Vector2 m_CellSize;
        [SerializeField] private Vector2 m_Spacing;
        [SerializeField] private bool m_FitX;
        [SerializeField] private bool m_FitY;
        
        public int NbRows => m_NbRows;
        public int NbColumns => m_NbColumns;

        public Vector2 MCellSize => m_CellSize;
        public CellSizeXMode MCellSizeXMode => m_CellSizeXMode;
        public CellSizeYMode MCellSizeYMode => m_CellSizeYMode;
        public LayoutModeRow MLayoutRowMode => m_LayoutRowMode;
        public LayoutModeColumn MLayoutColumnMode => m_LayoutColumnMode;

        private int GetMaxFittingInForSize(float availableSpace, float spacing, float size)
        {
            int incremental = 0;
            bool oversize = false;

            while (oversize == false)
            {
                float spacingTaking = incremental == 0 ? 0 : (incremental - 1) * spacing;
                float actualSize = spacingTaking + (incremental * size);
                oversize = actualSize > availableSpace;

                incremental += oversize ? -1 : 1;
            }

            return incremental;
        }

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
            
            // 1. In any case we'll respect spacing and padding given in parameter
            //   From this, based on parameters given for the grid layout, we'll calculate
            //   number of rows & columns and cell size.
            float totalWidth = rectTransform.rect.width;
            float totalWidthWithoutPadding = totalWidth - (padding.left + padding.right);
            float totalHeight = rectTransform.rect.height;
            float totalHeightWithoutPadding = totalHeight - (padding.top + padding.bottom);

            // Step 0 - We'll ensure to check possible error if combination are incorrect
            if (m_CellSizeXMode == CellSizeXMode.AutoCalculate && m_LayoutColumnMode == LayoutModeColumn.AutoCalculate)
                throw new Exception("Cannot AutoCalculate CellSizeX & LayoutModeColumn - At least 1 information" +
                                    "need to be given");
            if(m_CellSizeYMode == CellSizeYMode.AutoCalculate && m_LayoutRowMode == LayoutModeRow.AutoCalculate)
                throw new Exception("Cannot AutoCalculate CellSizeY & LayoutModeRow - At least 1 information" +
                                    "need to be given");
            if (m_CellSizeXMode == CellSizeXMode.MatchHeight && m_CellSizeYMode == CellSizeYMode.MatchWidth)
                throw new Exception("Cannot have both CellSizeXMode & CellSizeYMode set to match the other" +
                                    "one because there is a race condition");
            if (m_CellSizeXMode == CellSizeXMode.Respect && Mathf.Approximately(m_CellSize.x, 0f))
                throw new Exception("Cannot have CellSizeXMode set to Respect & CellSize.x == 0");
            if (m_CellSizeYMode == CellSizeYMode.Respect && Mathf.Approximately(m_CellSize.y, 0f))
                throw new Exception("Cannot have CellSizeYMode set to Respect & CellSize.y == 0");
            if (m_LayoutRowMode == LayoutModeRow.Fixed && m_LayoutColumnMode == LayoutModeColumn.Fixed && 
                m_NbRows * m_NbColumns < transform.childCount)
                throw new Exception("Both row & column are fixed but there is not enough space for all children");

            // Step 1 - We'll ensure to compute size mode for both CellSizeX & CellSizeY and assign proper cell size
            // if the mode enable it
            if (m_CellSizeXMode == CellSizeXMode.MatchHeight)
            {
                m_CellSize.x = m_CellSize.y;
            }

            if (m_CellSizeYMode == CellSizeYMode.MatchWidth)
            {
                m_CellSize.y = m_CellSize.x;
            }

            // Step 2 - We'll compute number of row & column in the grid layout according to parameters
            // It is important to notice that some combination are not strictly forbidden but may cause overflow
            // that need to be handle with a scrollview for example.
            //
            // Example : If you set the LayoutModeRow to Fixed & CellSizeXMode to Respect, it will force the algorithm
            // to preserve the m_CellSize.x and the number of row, leading to potential overflow
            //
            // The only way to ensure that the algorithm will calculate the approximate maximum size for m_CellSize.x is to
            // set CellSizeXMode to AutoCalculate.
            //
            // The algorithm will advertise with a log that the computation will lead to an overflow
            // Step 2.1 - Compute LayoutModeRow
            switch (m_LayoutRowMode)
            {
                case LayoutModeRow.Fixed:
                    if (m_CellSizeYMode == CellSizeYMode.AutoCalculate)
                    {
                        m_CellSize.y = (totalHeightWithoutPadding - (m_Spacing.y * (m_NbRows - 1))) / m_NbRows;
                    }
                    else
                    {
                        float totalHeightOccupied = m_Padding.top + m_Padding.bottom + (m_CellSize.y * m_NbRows) +
                                              (m_Spacing.y * (m_NbRows - 1));
                        if (totalHeightOccupied > totalHeight)
                        {
                            Debug.LogWarning("Total height occupied is overflowing : " + totalHeightOccupied + " / " +
                                             totalHeight);
                        }
                    }
                    break;
                case LayoutModeRow.AutoCalculate:
                    if (m_LayoutColumnMode == LayoutModeColumn.Fixed)
                    {
                        m_NbRows = Mathf.CeilToInt(rectTransform.childCount / (float) m_NbColumns);
                    }
                    else
                    {
                        int nbRow = GetMaxFittingInForSize(totalHeightWithoutPadding, m_Spacing.y, m_CellSize.y);
                        m_NbRows = nbRow;
                    }
                    break;
                
                default:
                    throw new Exception("LayoutModeRow value : " + m_LayoutRowMode + " isn't implemented");
            }
            
            // Step 2.2 - Compute LayoutModeColumn
            switch (m_LayoutColumnMode)
            {
                case LayoutModeColumn.Fixed:
                    if (m_CellSizeXMode == CellSizeXMode.AutoCalculate)
                    {
                        m_CellSize.x = (totalWidthWithoutPadding - (m_Spacing.x * (m_NbColumns - 1))) / m_NbColumns;
                    }
                    else
                    {
                        float totalWidthOccupied = m_Padding.left + m_Padding.right + (m_CellSize.x * m_NbColumns) +
                                              (m_Spacing.x * (m_NbColumns - 1));
                        if (totalWidthOccupied > totalWidth)
                        {
                            Debug.LogWarning("Total width occupied is overflowing : " + totalWidthOccupied + " / " +
                                             totalWidth);
                        }
                    }
                    
                    break;
                case LayoutModeColumn.AutoCalculate:
                    if (m_LayoutRowMode == LayoutModeRow.Fixed)
                    {
                        m_NbColumns = Mathf.CeilToInt(rectTransform.childCount / (float) m_NbRows);
                    }
                    else
                    {
                        int nbColumn = GetMaxFittingInForSize(totalWidthWithoutPadding, m_Spacing.x, m_CellSize.x);
                        m_NbColumns = nbColumn;
                    }

                    break;
                default:
                    throw new Exception("LayoutModeColumn value : " + m_LayoutColumnMode + " isn't implemented");
            }
            
            // Step 3 - We need to make a second round on CellSize matching because our implementation may have changed it
            // during the layout calculation
            if (m_CellSizeXMode == CellSizeXMode.MatchHeight)
            {
                m_CellSize.x = m_CellSize.y;
            }

            if (m_CellSizeYMode == CellSizeYMode.MatchWidth)
            {
                m_CellSize.y = m_CellSize.x;
            }

            // Actually drawing
            
            if (m_FillMode == FillMode.ColumnFirst)
            {
                for (int i = 0; i < rectChildren.Count; i++)
                {
                    int column = m_NbColumns > rectTransform.childCount ? rectTransform.childCount : m_NbColumns;
                    int row = Mathf.CeilToInt(rectTransform.childCount / (float) column);
                    float widthOccupied = m_Padding.left + m_Padding.right + (m_CellSize.x * column) +
                                          (m_Spacing.x * (m_NbColumns - 1));
                    float heightOccupied = m_Padding.top + m_Padding.bottom + (m_CellSize.y * row) +
                                           (m_Spacing.y * (row - 1));
                    Vector2 startingPoint = StartingPoint(totalWidth, widthOccupied, totalHeight, heightOccupied);
                    
                    int rowCount = i / m_NbColumns;
                    int columnCount = i % m_NbColumns;
   
                    var item = rectChildren[i];
                    var positionX = (m_CellSize.x * columnCount) + (m_Spacing.x * columnCount) + padding.left + startingPoint.x;
                    var positionY = (m_CellSize.y * rowCount) + (m_Spacing.y * rowCount) + padding.top + startingPoint.y;
                    SetChildAlongAxis(item, 0, positionX, m_CellSize.x);
                    SetChildAlongAxis(item, 1, positionY, m_CellSize.y);
                }
            }
            else if (m_FillMode == FillMode.RowFirst)
            {
                for (int i = 0; i < rectChildren.Count; i++)
                {
                    int row = m_NbRows > rectTransform.childCount ? rectTransform.childCount : m_NbRows;
                    int column = Mathf.CeilToInt(rectTransform.childCount / (float) row);
                    
                    float widthOccupied = m_Padding.left + m_Padding.right + (m_CellSize.x * column) +
                                          (m_Spacing.x * (column - 1));
                    float heightOccupied = m_Padding.top + m_Padding.bottom + (m_CellSize.y * row) +
                                           (m_Spacing.y * (row - 1));
                    Vector2 startingPoint = StartingPoint(totalWidth, widthOccupied, totalHeight, heightOccupied);
                    
                    int rowCount = i % m_NbRows;
                    int columnCount = i / m_NbRows;
   
                    var item = rectChildren[i];
                    var positionX = (m_CellSize.x * columnCount) + (m_Spacing.x * columnCount) + padding.left + startingPoint.x;
                    var positionY = (m_CellSize.y * rowCount) + (m_Spacing.y * rowCount) + padding.top + startingPoint.y;
                    SetChildAlongAxis(item, 0, positionX, m_CellSize.x);
                    SetChildAlongAxis(item, 1, positionY, m_CellSize.y);
                }
            }
            else
            {
                throw new Exception("Fill Mode : " + m_FillMode + " not implemented");
            }
        }

        public override void CalculateLayoutInputVertical()
        {
        }

        public override void SetLayoutHorizontal()
        {
        }

        public override void SetLayoutVertical()
        {
        }

        private Vector2 StartingPoint(float totalWidth, float totalWidthOccupied, float totalHeight, float totalHeightOccupied)
        {
            Debug.Log(totalWidth + " - " +  totalWidthOccupied);
            Debug.Log(totalHeight + " - " +  totalHeightOccupied);
            Vector2 startingPosition = Vector2.zero;
            // We'll compute the Y starting position
            if (m_ChildAlignment == TextAnchor.UpperCenter || m_ChildAlignment == TextAnchor.UpperLeft ||
                m_ChildAlignment == TextAnchor.UpperRight)
            {
                startingPosition.y = 0f;
            }
            else if (m_ChildAlignment == TextAnchor.MiddleCenter || m_ChildAlignment == TextAnchor.MiddleLeft ||
                m_ChildAlignment == TextAnchor.MiddleRight)
            {
                startingPosition.y = (totalHeight - totalHeightOccupied) / 2;
            }
            else if(m_ChildAlignment == TextAnchor.LowerCenter || m_ChildAlignment == TextAnchor.LowerLeft || 
                    m_ChildAlignment == TextAnchor.LowerRight)
            {
                startingPosition.y = totalHeight - totalHeightOccupied;
            }
            else
            {
                throw new Exception("Child alignment : " + m_ChildAlignment + " is not implemented for Y position");
            }
            
            // We'll compute the X starting position
            if (m_ChildAlignment == TextAnchor.LowerLeft || m_ChildAlignment == TextAnchor.MiddleLeft ||
                m_ChildAlignment == TextAnchor.UpperLeft)
            {
                startingPosition.x = 0f;
            }
            else if (m_ChildAlignment == TextAnchor.LowerCenter || m_ChildAlignment == TextAnchor.MiddleCenter ||
                m_ChildAlignment == TextAnchor.UpperCenter)
            {
                startingPosition.x = (totalWidth - totalWidthOccupied) / 2;
            }
            else if (m_ChildAlignment == TextAnchor.LowerRight || m_ChildAlignment == TextAnchor.MiddleRight ||
                m_ChildAlignment == TextAnchor.UpperRight)
            {
                startingPosition.x = totalWidth - totalWidthOccupied;
            }
            else
            {
                throw new Exception("Child alignment : " + m_ChildAlignment + " is not implemented for X position");
            }

            return startingPosition;
        }
    }
}