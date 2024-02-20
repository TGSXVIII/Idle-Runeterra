using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InGameShop : MonoBehaviour
{
	private TeamManager teamManager;

	[Header("Items")]
	[SerializeField]
	private List<ShopItem> shopItems = new();

	[Header("Shop")]
	[SerializeField]
	private GameObject ShopCanvas;
	[SerializeField]
	private GameObject shopContent;
	[SerializeField]
	private GameObject shopItemPrefab;
	[SerializeField]
	private bool shopIsOpen = false;

	[Header("Champion")]
	[SerializeField]
	private GameObject champPrefab;
	[SerializeField]
	private RectTransform champIconLocation;
	[SerializeField]
	private float ChampIconPadding = 200;
	private List<Image> champOutline = new();

	private int champtionSelected = -1;

	private void Start()
	{
		teamManager = GameObject.FindGameObjectWithTag("GameController").
			GetComponent<GameManager>().GetAllyTeam(ChampionStats.Team.Player);

		MakeChampIcon();
		MakeUIShop();
		OpenOrCloseShop();
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			shopIsOpen = !shopIsOpen;
			OpenOrCloseShop();
		}
	}

	private void OpenOrCloseShop()
	{
		if (shopIsOpen) OpenShop();
		else CloseShop();
	}

	private void OpenShop()
	{
		ShopCanvas.SetActive(true);
	}

	private void CloseShop()
	{
		ShopCanvas.SetActive(false);
		champtionSelected = -1;
		ChanceOutline();
	}

	private void MakeChampIcon()
	{
		bool right = true;
		int distanceMulitibler = 0;
		float maxWidth = champIconLocation.rect.width - ChampIconPadding;
		float distanceBetween = maxWidth / teamManager.champions.Count;
		float firstPostion = teamManager.champions.Count % 2 == 0 ? distanceBetween / 2 : 0;

		for (int i = 0; i < teamManager.champions.Count; i++)
		{
			InGameShopItemIcon champIcon = Instantiate(champPrefab, champIconLocation)
				.GetComponent<InGameShopItemIcon>();

			float postion = firstPostion + distanceMulitibler * distanceBetween * (right ? 1 : -1);
			champIcon.gameObject.transform.localPosition = new Vector2(postion, 0);
			champIcon.Icon.sprite = teamManager.champions[i].GetIcon();
			champIcon.Button.onClick.AddListener(() => SelectChamption(champIcon));
			champIcon.index = i;
			champOutline.Add(champIcon.Outline);
			right = !right;

			if (i == 0)
				distanceMulitibler += 1;

			if (i > 1)
				distanceMulitibler += (i + 1) % 2;
		}
	}
	private void MakeUIShop()
	{
		foreach (ShopItem item in shopItems)
		{
			GameObject shopItem = Instantiate(shopItemPrefab, shopContent.transform);
			Button button = shopItem.GetComponentInChildren<Button>();
			button.onClick.AddListener(() => Buy(item));

			if (item.icon != null)
				button.GetComponent<Image>().sprite = item.icon;
		}
	}
	private void Buy(ShopItem item)
	{
		if (teamManager.gold >= item.cost && champtionSelected > -1)
		{
			teamManager.gold -= item.cost;
			teamManager.champions[champtionSelected].AddItem(item);
		}
	}
	private void ChanceOutline()
	{
		for (int i = 0; i < champOutline.Count; i++)
		{
			champOutline[i].color = i == champtionSelected ?
				Color.red : new Color(0.3528302f, 0.3921569f, 1, 1);
		}
	}
	public void SelectChamption(InGameShopItemIcon champion)
	{
		champtionSelected = champion.index;
		ChanceOutline();
	}
}
