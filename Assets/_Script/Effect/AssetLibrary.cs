using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AssetLibrary : SingletonScriptableObject<AssetLibrary>
{
	public AudioClip appearSFX;
	public AudioClip growSFX;

	public void PlayAppearSFX(GrowNode node)
	{
		if (node.playAppearSFX)
			PlayAppearSFX(node.nodeAudioSource);
	}

	public void PlayAppearSFX(AudioSource source)
	{
		source.clip = appearSFX;
		source.Play();
	}

	public void PlayGrowSFX(GrowNode node)
	{
		if (node.playGrowSFX)
			PlayGrowSFX(node.nodeAudioSource);
	}

	public void PlayGrowSFX(AudioSource source)
	{
		source.clip = growSFX;
		source.Play();
	}
}
