using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GrowNode))]
public class GrowTree : MonoBehaviour
{
	[ReadOnly] public GrowNode root;
	[ReadOnly] public GrowNode activeNode;

	public bool IsActiveTree => activeNode != root;

	public int GetTreeLevel()
	{
		int res = 0;

		GrowNode iter = activeNode;
		while (iter.parentNode != null) {
			res++;
			iter = iter.parentNode;
		}

		return res;
	}

	private void Awake()
	{
		root = GetComponent<GrowNode>();
		activeNode = root;
	}

	public void GrowToNode(GrowNode node)
	{
		activeNode = node;

		AssetLibrary.Instance.PlaySFX(activeNode);
		if (activeNode.growSFX == GrowSFX.GROW)
			FloatTextManager.Instance.PopupLevelUpText(activeNode.defaultLevelUpTextAnchor.position); 
		activeNode.onGrow.Invoke();
	}
}
