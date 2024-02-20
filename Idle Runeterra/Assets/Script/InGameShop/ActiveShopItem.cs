using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveShopItem : ShopItem
{
	public override State GetState() => State.Active;
	public abstract void ActiveAbility();
}
