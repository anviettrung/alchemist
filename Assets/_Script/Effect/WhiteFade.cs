using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WhiteFade : MonoBehaviour
{
	public List<MeshRenderer> rends = new List<MeshRenderer>();

	public void PlayFade(float duration)
	{
		for (int i = 0; i < rends.Count; i++) {
			Color origin_color = rends[i].material.GetColor("_EmissionColor");
			rends[i].material.SetColor("_EmissionColor", Color.white);
			rends[i].material.DOColor(origin_color, "_EmissionColor", duration);
			rends[i].material.EnableKeyword("_EMISSION");
		}
	}
}
