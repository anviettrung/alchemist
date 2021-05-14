using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AssetLibrary : SingletonScriptableObject<AssetLibrary>
{
	public AudioClip appearSFX;
	public AudioClip growSFX;

	public void PlaySFX(GrowNode node)
	{
		switch (node.growSFX) {
			case GrowSFX.GROW:
				PlaySFX(node.nodeAudioSource, growSFX);
				break;
			case GrowSFX.APPEAR:
				PlaySFX(node.nodeAudioSource, appearSFX);
				break;
			case GrowSFX.NONE:
				return;
		}
	}

	public void PlaySFX(AudioSource source, AudioClip clip)
	{
		source.clip = clip;
		source.Play();
	}
}
