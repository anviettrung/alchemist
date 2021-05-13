using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
	[SerializeField] GrowGraph growGraph;
	[SerializeField] Button resetButton;
	[SerializeField] List<Button> itemButtons = new List<Button>();

	#region Validating
	public GrowGraph GrowGraph {
		get => growGraph;
		set {
			growGraph = value;
			OnChangeGrowGraph();
		}
	}

	private void OnValidate()
	{
		OnChangeGrowGraph();
	}

	void OnChangeGrowGraph()
	{
		int n_item = growGraph == null ? 0 : growGraph.trees.Count;

		for (int i = 0; i < itemButtons.Count; i++)
			itemButtons[i].gameObject.SetActive(i < n_item);
	}

	#endregion

	private void Awake()
	{
		/* -----------------------------
		// Initialization
		// ----------------------------- */
		for (int i = 0; i < itemButtons.Count; i++) {
			int cp_i = i;
			itemButtons[i].onClick.AddListener(() => OnClickItem(cp_i));
		}

		resetButton.onClick.AddListener(ResetItem);
	}

	protected void ResetItem()
	{
		Debug.Log("Reset Item");
		for (int i = 0; i < itemButtons.Count; i++) {
			itemButtons[i].interactable = true;
		}
	}

	protected void OnClickItem(int x)
	{
		if (growGraph.Growing == false) {
			Debug.Log("Use item " + x);
			itemButtons[x].interactable = false;
			growGraph.UseItem(x);
		}
	}
}
