using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GrowGraph : MonoBehaviour
{
	[System.Serializable]
	public class GrowTree
	{
		public string name;
		//GrowNode startNode;
		//public List<GrowNode> nodes = new List<GrowNode>();
	}

	public List<GrowTree> trees;
}

//#if UNITY_EDITOR
//[CustomEditor(typeof(GrowGraph))]
//public class GrowGraphEditor: GenericEditor<GrowGraph>
//{
//	int treeIndex;
//	int fromNodeIndex;
//	int toNodeIndex;

//	public override void OnInspectorGUI()
//	{
//		base.OnInspectorGUI();

//		EditorGUILayout.BeginHorizontal();
//		treeIndex = EditorGUILayout.IntField(treeIndex);
//		fromNodeIndex = EditorGUILayout.IntField(fromNodeIndex);
//		toNodeIndex = EditorGUILayout.IntField(toNodeIndex);

//		EditorGUILayout.EndHorizontal();

//		if (GUILayout.Button("Create Relation")) {
//			if (0 <= treeIndex && treeIndex < mTarget.trees.Count)
//				if (0 <= fromNodeIndex && fromNodeIndex < mTarget.trees[treeIndex].nodes.Count
//				 && 0 <= toNodeIndex && toNodeIndex < mTarget.trees[treeIndex].nodes.Count)
//					new GrowRelation(
//						mTarget.trees[treeIndex].nodes[fromNodeIndex],
//						mTarget.trees[treeIndex].nodes[toNodeIndex]);
//		}

//		if (GUILayout.Button("Remove Relation")) {
//			if (0 <= treeIndex && treeIndex < mTarget.trees.Count)
//				if (0 <= fromNodeIndex && fromNodeIndex < mTarget.trees[treeIndex].nodes.Count
//				 && 0 <= toNodeIndex && toNodeIndex < mTarget.trees[treeIndex].nodes.Count) {
//					foreach (GrowRelation re in mTarget.trees[treeIndex].nodes[fromNodeIndex].OutRelations) {
//						if (re.IsPointTo(mTarget.trees[treeIndex].nodes[toNodeIndex])) {
//							re.DestroyRelation();
//							break;
//						}
//					}
//				}
//		}
//	}
//}
//#endif
