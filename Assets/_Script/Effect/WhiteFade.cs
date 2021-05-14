using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WhiteFade : MonoBehaviour
{
	public List<MeshRenderer> rends = new List<MeshRenderer>();

	public void PlayFadeAll(float duration)
	{
		for (int i = 0; i < rends.Count; i++) {
			PlayFadeRend(i, duration);
		}
	}

	public void PlayFadeRend(int x, float duration)
	{
		Color origin_color = rends[x].material.GetColor("_EmissionColor");
		rends[x].material.SetColor("_EmissionColor", Color.white);
		rends[x].material.DOColor(origin_color, "_EmissionColor", duration);
		rends[x].material.EnableKeyword("_EMISSION");
	}

	public void DelayDeactiveAll(float duration)
	{
		DOVirtual.DelayedCall(duration, () => {
			for (int i = 0; i < rends.Count; i++) {
				rends[i].gameObject.SetActive(false);
			}
		}, false);
	}
}
