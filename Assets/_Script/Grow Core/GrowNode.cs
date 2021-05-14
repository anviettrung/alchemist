using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEditor;

public enum GrowSFX {
	GROW,
	APPEAR,
	NONE
}

public class GrowNode : MonoBehaviour
{
	[ReadOnly] public GrowNode parentNode = null;
	[ReadOnly] public List<GrowNode> childNode = new List<GrowNode>();

	[Header("Transition")]
	public bool canGrowContinuously = false;
	public List<GrowCondition> growConditions = new List<GrowCondition>();

	[Header("Growth")]
	public float growDuration = 0;
	public Transform defaultLevelUpTextAnchor;
	public UnityEvent onGrow = new UnityEvent();

	[Header("SFX")]
	public GrowSFX growSFX;
	[HideInInspector] public AudioSource nodeAudioSource;
	

	private void Awake()
	{
		SetNodeRelation();
		nodeAudioSource = gameObject.AddComponent<AudioSource>();
		nodeAudioSource.playOnAwake = false;

		if (defaultLevelUpTextAnchor == null)
			defaultLevelUpTextAnchor = this.transform;
	}

	protected void SetNodeRelation()
	{
		//if (parentNode != null) {
		//	if (parentNode.transform != transform.parent) {
		//		// Remove old parent settings
		//		parentNode.childNode.Remove(this);
		//	}
		//}

		//parentNode = transform.parent.GetComponent<GrowNode>();
		//if (parentNode != null) {
		//	// Init
		//	parentNode.childNode.Add(this);
		//}

		for (int i = 0; i < transform.childCount; i++) {
			GrowNode node = transform.GetChild(i).GetComponent<GrowNode>();
			if (node != null) {
				node.parentNode = this;
				childNode.Add(node);
			}
		}
	}

	[MenuItem("GameObject/Grow Node", false, 15)]
	protected static void CreateGrowNode(MenuCommand menuCommand)
	{
		GameObject go = new GameObject("Node");
		go.AddComponent<GrowNode>();

		// Ensure it gets reparented if this was a context click (otherwise does nothing)
		GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
		// Register the creation in the undo system
		Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
		Selection.activeObject = go;
	}
}

[System.Serializable]
public class GrowCondition
{
	public enum CompareComponent {
		LEVEL,
		NODE
	}
	public enum CompareType
	{
		EQUAL,
		GREATER,
		SMALLER
	}

	public GrowTree tree;
	public CompareComponent cmpComp;
	public CompareType cmpType;
	public int cmpValue;
	public GrowNode cmpNode;
}

#if UNITY_EDITOR

//[CustomPropertyDrawer(typeof(GrowCondition))]
//public class GrowConditionDrawer : PropertyDrawer
//{
//	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//	{
//		return 16f;
//	}

//	public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
//	{
//		var treeProp = property.FindPropertyRelative("treeIndex");
//		var compProp = property.FindPropertyRelative("cmpComp");
//		var typeProp = property.FindPropertyRelative("cmpType");
//		var valueProp = property.FindPropertyRelative("cmpValue");
//		var nodeProp = property.FindPropertyRelative("cmpNode");

//		EditorGUI.indentLevel += 1;
//		rect.width /= 2;
//		treeProp.intValue = EditorGUI.IntField(rect, "Tree", treeProp.intValue);
//		rect.x += rect.width;
//		valueProp.intValue = EditorGUI.IntField(rect, valueProp.intValue);


//		//EditorGUILayout.BeginHorizontal();
//		//mTarget.cmpComp = (GrowCondition.CompareComponent)EditorGUILayout.EnumPopup(mTarget.cmpComp);

//		//switch (mTarget.cmpComp) {
//		//	case GrowCondition.CompareComponent.LEVEL:
//		//		mTarget.cmpType = (GrowCondition.CompareType)EditorGUILayout.EnumPopup(mTarget.cmpType);
//		//		mTarget.cmpValue = EditorGUILayout.IntField(mTarget.cmpValue);
//		//		break;
//		//	case GrowCondition.CompareComponent.NODE:
//		//		mTarget.cmpNode = (GrowNode)EditorGUILayout.ObjectField(mTarget.cmpNode, typeof(GrowNode), true);
//		//		break;
//		//}

//		//EditorGUILayout.EndHorizontal();
//	}
//}

#endif
