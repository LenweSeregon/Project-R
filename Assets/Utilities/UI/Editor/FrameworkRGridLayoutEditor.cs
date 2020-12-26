using System;

namespace com.companyR.frameworkR.Utilities.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(FrameworkRGridLayout))]
    public class FrameworkRGridLayoutEditor : Editor
    {
        private static readonly string PROPERTY_NAME_CELL_SIZE_X_MODE = "m_CellSizeXMode";
        private static readonly string PROPERTY_NAME_CELL_SIZE_Y_MODE = "m_CellSizeYMode";
        private static readonly string PROPERTY_NAME_LAYOUT_MODE_ROW = "m_LayoutRowMode";
        private static readonly string PROPERTY_NAME_LAYOUT_MODE_COLUMN = "m_LayoutColumnMode";
        
        private static readonly string PROPERTY_NAME_FILL_MODE = "m_FillMode";
        
        private static readonly string PROPERTY_NAME_NB_ROW = "m_NbRows";
        private static readonly string PROPERTY_NAME_NB_COLUMN = "m_NbColumns";
        private static readonly string PROPERTY_NAME_CELL_SIZE_X = "m_CellSize.x";
        private static readonly string PROPERTY_NAME_CELL_SIZE_Y = "m_CellSize.y";
        private static readonly string PROPERTY_NAME_SPACING_SIZE = "m_Spacing";
        private static readonly string PROPERTY_NAME_PADDING_SIZE = "m_Padding";
        private static readonly string PROPERTY_NAME_CHILD_ALIGNMENT = "m_ChildAlignment";
        
        private SerializedProperty m_PropertyCellSizeXMode;
        private SerializedProperty m_PropertyCellSizeYMode;
        private SerializedProperty m_PropertyLayoutModeRow;
        private SerializedProperty m_PropertyLayoutModeColumn;
        private SerializedProperty m_PropertyFillMode;
        private SerializedProperty m_PropertyNbRow;
        private SerializedProperty m_PropertyNbColumn;
        private SerializedProperty m_PropertyCellSizeX;
        private SerializedProperty m_PropertyCellSizeY;
        private SerializedProperty m_PropertySpacingSize;
        private SerializedProperty m_PropertyPaddingSize;
        private SerializedProperty m_PropertyChildAlignment;
        
        private FrameworkRGridLayout m_GridLayout;
        private RectTransform m_GridLayoutRectTransform;
        
        private GUIStyle m_CenteredTitleStyle;
        private GUIStyle m_HeaderTitleStyle;
        private GUIStyle m_ToggleButtonStyleNormal = null;
        private GUIStyle m_ToggleButtonStyleToggled = null;

        private bool m_Init = false;
        
        private void OnEnable()
        {
            Init();
        }
        
        private void Init()
        {
            if (m_Init) return;
            
            m_Init = true;
            m_GridLayout = serializedObject.targetObject as FrameworkRGridLayout;
            m_GridLayoutRectTransform = m_GridLayout.GetComponent<RectTransform>();
            
            m_PropertyCellSizeXMode = serializedObject.FindProperty(PROPERTY_NAME_CELL_SIZE_X_MODE);
            m_PropertyCellSizeYMode = serializedObject.FindProperty(PROPERTY_NAME_CELL_SIZE_Y_MODE);
            m_PropertyLayoutModeRow = serializedObject.FindProperty(PROPERTY_NAME_LAYOUT_MODE_ROW);
            m_PropertyLayoutModeColumn = serializedObject.FindProperty(PROPERTY_NAME_LAYOUT_MODE_COLUMN);
            m_PropertyFillMode = serializedObject.FindProperty(PROPERTY_NAME_FILL_MODE);
            m_PropertyNbRow = serializedObject.FindProperty(PROPERTY_NAME_NB_ROW);
            m_PropertyNbColumn = serializedObject.FindProperty(PROPERTY_NAME_NB_COLUMN);
            m_PropertyCellSizeX = serializedObject.FindProperty(PROPERTY_NAME_CELL_SIZE_X);
            m_PropertyCellSizeY = serializedObject.FindProperty(PROPERTY_NAME_CELL_SIZE_Y);
            m_PropertySpacingSize = serializedObject.FindProperty(PROPERTY_NAME_SPACING_SIZE);
            m_PropertyPaddingSize = serializedObject.FindProperty(PROPERTY_NAME_PADDING_SIZE);
            m_PropertyChildAlignment = serializedObject.FindProperty(PROPERTY_NAME_CHILD_ALIGNMENT);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
         
            
            // Initializing styles
            m_CenteredTitleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Italic, fontSize = 15};
            m_HeaderTitleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleLeft, fontStyle = FontStyle.Bold, fontSize = 12};
            if ( m_ToggleButtonStyleNormal == null )
            {
                m_ToggleButtonStyleNormal = "Button";
                m_ToggleButtonStyleToggled = new GUIStyle(m_ToggleButtonStyleNormal);
                m_ToggleButtonStyleToggled.normal.background = m_ToggleButtonStyleToggled.active.background;
            }
            // Box for debugging
            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.LabelField("Informations", m_CenteredTitleStyle, GUILayout.ExpandWidth(true));
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Validity : OK");
                EditorGUILayout.LabelField("Child Count : " + m_GridLayoutRectTransform.childCount);
                EditorGUILayout.LabelField("Cell size : (" + m_GridLayout.MCellSize.x + "," + m_GridLayout.MCellSize.y + ")");
                EditorGUILayout.LabelField("Number of rows : " + m_GridLayout.NbRows);
                EditorGUILayout.LabelField("Number of columns : " + m_GridLayout.NbColumns);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
            
            // Box for parametrize
            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.LabelField("Parametrize", m_CenteredTitleStyle, GUILayout.ExpandWidth(true));
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("General settings :", m_HeaderTitleStyle);
                EditorGUILayout.PropertyField(m_PropertyChildAlignment);
                EditorGUILayout.PropertyField(m_PropertyFillMode);
                EditorGUILayout.PropertyField(m_PropertySpacingSize);
                EditorGUILayout.PropertyField(m_PropertyPaddingSize);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                
                EditorGUILayout.LabelField("Row settings : ", m_HeaderTitleStyle);
                m_PropertyCellSizeYMode.enumValueIndex = (int) (FrameworkRGridLayout.CellSizeYMode) EditorGUILayout.EnumPopup(new GUIContent("Cell height Mode"), (FrameworkRGridLayout.CellSizeYMode) m_PropertyCellSizeYMode.enumValueIndex, GetEnabledCellSizeYMode, true);
                if (m_GridLayout.MCellSizeYMode == FrameworkRGridLayout.CellSizeYMode.Respect)
                {
                    EditorGUILayout.PropertyField(m_PropertyCellSizeY, new GUIContent("Cell height value"));
                }
                
                m_PropertyLayoutModeRow.enumValueIndex = (int) (FrameworkRGridLayout.LayoutModeRow) EditorGUILayout.EnumPopup(new GUIContent("Row Mode"), (FrameworkRGridLayout.LayoutModeRow) m_PropertyLayoutModeRow.enumValueIndex, GetEnabledRowMode, true);
                if (m_GridLayout.MLayoutRowMode == FrameworkRGridLayout.LayoutModeRow.Fixed)
                {
                    EditorGUILayout.PropertyField(m_PropertyNbRow, new GUIContent("Number of row"));
                }
                
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                
                EditorGUILayout.LabelField("Column settings : ", m_HeaderTitleStyle);
                m_PropertyCellSizeXMode.enumValueIndex = (int) (FrameworkRGridLayout.CellSizeXMode) EditorGUILayout.EnumPopup(new GUIContent("Cell width Mode"), (FrameworkRGridLayout.CellSizeXMode) m_PropertyCellSizeXMode.enumValueIndex, GetEnabledCellSizeXMode, true);
                if (m_GridLayout.MCellSizeXMode == FrameworkRGridLayout.CellSizeXMode.Respect)
                {
                    EditorGUILayout.PropertyField(m_PropertyCellSizeX, new GUIContent("Cell width value"));
                }
                
                m_PropertyLayoutModeColumn.enumValueIndex = (int) (FrameworkRGridLayout.LayoutModeColumn) EditorGUILayout.EnumPopup(new GUIContent("Column Mode"), (FrameworkRGridLayout.LayoutModeColumn) m_PropertyLayoutModeColumn.enumValueIndex, GetEnabledColumnMode, true);
                if (m_GridLayout.MLayoutColumnMode == FrameworkRGridLayout.LayoutModeColumn.Fixed)
                {
                    EditorGUILayout.PropertyField(m_PropertyNbColumn, new GUIContent("Number of column"));
                }
            }
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnInspectorGUIType()
        {
            EditorGUILayout.PropertyField(m_PropertyFillMode);
            //EditorGUILayout.PropertyField(m_PropertyCellSize);
            EditorGUILayout.PropertyField(m_PropertyPaddingSize);
            EditorGUILayout.PropertyField(m_PropertyChildAlignment);
        }

        private void OnInspectorGUIInformation()
        {
            
        }

        private string DescriptionType()
        {
            return null;
        }
        

        private bool GetEnabledCellSizeXMode(Enum arg)
        {
            if(arg is FrameworkRGridLayout.CellSizeXMode == false)
                throw new Exception("Enum type is incorrect - Should be " + typeof(FrameworkRGridLayout.CellSizeXMode));
            
            FrameworkRGridLayout.CellSizeXMode sizeXMode = (FrameworkRGridLayout.CellSizeXMode) arg;

            switch (sizeXMode)
            {
                case FrameworkRGridLayout.CellSizeXMode.Respect:
                    return true;
                case FrameworkRGridLayout.CellSizeXMode.MatchHeight:
                    return true;
                case FrameworkRGridLayout.CellSizeXMode.AutoCalculate:
                    return m_GridLayout.MLayoutColumnMode == FrameworkRGridLayout.LayoutModeColumn.Fixed;
                default:
                    throw new ArgumentOutOfRangeException("CellSizeXMode enum value not implemented : " + sizeXMode);
            }
        }

        private bool GetEnabledCellSizeYMode(Enum arg)
        {
            if(arg is FrameworkRGridLayout.CellSizeYMode == false)
                throw new Exception("Enum type is incorrect - Should be " + typeof(FrameworkRGridLayout.CellSizeYMode));
            
            FrameworkRGridLayout.CellSizeYMode sizeYMode = (FrameworkRGridLayout.CellSizeYMode) arg;

            switch (sizeYMode)
            {
                case FrameworkRGridLayout.CellSizeYMode.Respect:
                    return true;
                case FrameworkRGridLayout.CellSizeYMode.MatchWidth:
                    return true;
                case FrameworkRGridLayout.CellSizeYMode.AutoCalculate:
                    return m_GridLayout.MLayoutRowMode == FrameworkRGridLayout.LayoutModeRow.Fixed;
                default:
                    throw new ArgumentOutOfRangeException("CellSizeXMode enum value not implemented : " + sizeYMode);
            }
        }

        private bool GetEnabledRowMode(Enum arg)
        {
            if(arg is FrameworkRGridLayout.LayoutModeRow == false)
                throw new Exception("Enum type is incorrect - Should be " + typeof(FrameworkRGridLayout.LayoutModeRow));
            
            FrameworkRGridLayout.LayoutModeRow rowMode = (FrameworkRGridLayout.LayoutModeRow) arg;

            switch (rowMode)
            {
                case FrameworkRGridLayout.LayoutModeRow.Fixed:
                    return true;
                case FrameworkRGridLayout.LayoutModeRow.AutoCalculate:
                    return m_GridLayout.MCellSizeYMode != FrameworkRGridLayout.CellSizeYMode.AutoCalculate;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool GetEnabledColumnMode(Enum arg)
        {
            if(arg is FrameworkRGridLayout.LayoutModeColumn == false)
                throw new Exception("Enum type is incorrect - Should be " + typeof(FrameworkRGridLayout.LayoutModeColumn));
            
            FrameworkRGridLayout.LayoutModeColumn columnMode = (FrameworkRGridLayout.LayoutModeColumn) arg;

            switch (columnMode)
            {
                case FrameworkRGridLayout.LayoutModeColumn.Fixed:
                    return true;
                case FrameworkRGridLayout.LayoutModeColumn.AutoCalculate:
                    return m_GridLayout.MCellSizeXMode != FrameworkRGridLayout.CellSizeXMode.AutoCalculate;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}