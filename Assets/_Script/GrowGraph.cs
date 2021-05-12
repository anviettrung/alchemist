using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GrowGraph : MonoBehaviour
{
	public List<GrowTree> trees;

	public void UseItem(int x)
	{
		GrowNode next = FindNextGrowNode(trees[x].activeNode);
		if (next != null)
			trees[x].GrowToNode(next);

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
					}
				}
			}

			growCount++;
		}
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
