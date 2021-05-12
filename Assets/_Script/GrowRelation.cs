using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GrowRelation
{
	GrowNode FromNode;
	GrowNode ToNode;

	public bool IsPointTo(GrowNode node) => node == ToNode;

	public GrowRelation(GrowNode from, GrowNode to)
	{
		FromNode = from;
		FromNode.OutRelations.Add(this);

		ToNode = to;
		ToNode.InRelations.Add(this);
	}

	public void DestroyRelation()
	{
		FromNode.OutRelations.Remove(this);
		ToNode.InRelations.Remove(this);
	}
}
