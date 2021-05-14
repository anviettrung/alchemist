using UnityEngine;
using DG.Tweening;

public class DAShowUp : MonoBehaviour
{
	public void SequenceAppear(float appearRate)
	{
		WhiteFade fader = GetComponent<WhiteFade>();
		if (fader == null) return;

		fader.gameObject.SetActive(true);

		for (int i = 0; i < fader.rends.Count; i++) {
			fader.rends[i].gameObject.SetActive(false);
			fader.rends[i].transform.localPosition += Vector3.up;
			int cp_i = i;
			DOVirtual.DelayedCall(cp_i * appearRate, () => {
				fader.rends[cp_i].gameObject.SetActive(true);
				fader.PlayFadeRend(cp_i, 1);
			}, false);
		}
	}
}
