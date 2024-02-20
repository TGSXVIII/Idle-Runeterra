using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveShopItem : ShopItem
{
	public override State GetState() => State.Passive;
	public abstract void PassiveAbility();
}
