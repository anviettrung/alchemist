using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatTextManager : Singleton<FloatTextManager>
{
	[SerializeField] List<Transform> levelupText = new List<Transform>();
	public float textUpDist = 1;
	public float textUpDuration = 1;

	Transform GetText()
	{
		for (int i = 0; i < levelupText.Count; i++)
			if (levelupText[i].gameObject.activeInHierarchy == false)
				return levelupText[i];

		return levelupText[0];
	}

	public void PopupLevelUpText(Vector3 pos)
	{
		Transform tex = GetText();
		tex.position = pos;

		Vector3 fixDistPos = tex.localPosition;
		fixDistPos.z = -10;
		tex.localPosition = fixDistPos;

		tex.gameObject.SetActive(true);

		tex.DOLocalMoveY(tex.localPosition.y + textUpDist, textUpDuration)
			.SetEase(Ease.OutSine)
			.OnComplete(() => tex.gameObject.SetActive(false));
	}

}
