using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryItemEditor : EditorWindow
{
    public InventoryItemList inventoryItemList;
    private int viewIndex = 1;

    [MenuItem ("Window/Inventory Item Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(InventoryItemEditor));
    }

	private void OnEnable()
	{
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string ObjectPath = EditorPrefs.GetString("ObjectPath");
            inventoryItemList = AssetDatabase.LoadAssetAtPath(ObjectPath, typeof(InventoryItemList)) as InventoryItemList;
        }
	}

	private void OnGUI()
	{
        GUILayout.BeginHorizontal();
        GUILayout.Label("Inventory Item Editor", EditorStyles.boldLabel);
        if (inventoryItemList != null)
        {
            if (GUILayout.Button("Show Item List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = inventoryItemList;
            }
        }
        if (GUILayout.Button("Open Item List"))
        {
            OpenItemList();
        }
        if (GUILayout.Button("New Item List"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = inventoryItemList;
        }
        GUILayout.EndHorizontal();



        if (inventoryItemList == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Create New Item List", GUILayout.ExpandWidth(false)))
            {
                CreateNewItemList();
            }
            if (GUILayout.Button("Open Existing Item List", GUILayout.ExpandWidth(false)))
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal();
        }


        GUILayout.Space(20);



        if (inventoryItemList != null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex < inventoryItemList.itemList.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);
            if (GUILayout.Button("Add Item", GUILayout.ExpandWidth(false)))
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false)))
            {
                DeleteItem(viewIndex - 1);
            }
            GUILayout.EndHorizontal();

            if (inventoryItemList.itemList == null)
            {
                Debug.Log("wtf");
            }
            if (inventoryItemList.itemList.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = MathfClamp(EditorGUILayout.IntField("Current Item", viewIndex, GUILayout.ExpandWidth(false)));
                //Mathf.Clamp(viewIndex, 1, inventoryItemList.itemList.Count);

                //... A COMPLETER
                //TODO: A terminer https://unity3d.com/fr/learn/tutorials/modules/beginner/live-training-archive/scriptable-objects?playlist=17117
            }

        }
	}

}
//TODO: truc

