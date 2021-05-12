using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class GrowNode
{
	public List<GrowRelation> OutRelations = new List<GrowRelation>();
	public List<GrowRelation> InRelations = new List<GrowRelation>();

	public UnityEvent onStartNode = new UnityEvent();
	public UnityEvent onEndNode = new UnityEvent();
}
