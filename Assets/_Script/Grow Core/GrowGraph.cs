using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowGraph : MonoBehaviour
{
	public List<GrowTree> trees;
	public bool Growing { get;  private set; }

	public void UseItem(int x)
	{
		StartCoroutine(IUseItem(x));
	}

	IEnumerator IUseItem(int x)
	{
		Growing = true;

		GrowNode next = FindNextGrowNode(trees[x].activeNode);
		if (next != null) {
			trees[x].GrowToNode(next);
			AssetLibrary.Instance.PlayAppearSFX(next);
			yield return new WaitForSeconds(next.growDuration);
		}

		bool graphChange = true;
		int growCount = 0;
		while (graphChange) {
			graphChange = false;

			for (int i = 0; i < trees.Count; i++) {
				if (!trees[i].IsActiveTree) continue;

				GrowNode nextNode = FindNextGrowNode(trees[i].activeNode);
				if (nextNode != null) {
					if (nextNode.canGrowContinuously || growCount != 0 || nextNode.growConditions.Count != 0) {
						graphChange = true;
						trees[i].GrowToNode(nextNode);
						AssetLibrary.Instance.PlayGrowSFX(nextNode);
						yield return new WaitForSeconds(nextNode.growDuration);
					}
				}
			}

			growCount++;
		}

		yield return 0;

		Growing = false;
	}

	public GrowNode FindNextGrowNode(GrowNode node)
	{
		foreach (GrowNode next in node.childNode) {
			bool canGrow = true;
			foreach (GrowCondition condition in next.growConditions) {
				if (CheckGrowCondition(condition) == false) {
					canGrow = false;
					break;
				}
			}
			if (canGrow)
				return next;
		}

		return null;
	}

	public bool CheckGrowCondition(GrowCondition condition)
	{
		switch (condition.cmpComp) {
			case GrowCondition.CompareComponent.LEVEL:
				switch (condition.cmpType) {
					case GrowCondition.CompareType.EQUAL:
						return condition.tree.GetTreeLevel() == condition.cmpValue;
					case GrowCondition.CompareType.GREATER:
						return condition.tree.GetTreeLevel() > condition.cmpValue;
					case GrowCondition.CompareType.SMALLER:
						return condition.tree.GetTreeLevel() < condition.cmpValue;
				}
				break;
			case GrowCondition.CompareComponent.NODE:
				return condition.tree.activeNode == condition.cmpNode;
		}

		return false;
	}
}
