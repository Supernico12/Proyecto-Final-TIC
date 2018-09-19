using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript
{

    public string name;
    public int quantity;
    public AmmoTypes type;
	public Mesh mesh;
    public AmmoScript(AmmoTypes type, int quantity)
    {
        this.type = type;
        this.quantity = quantity;
    }


}

public enum AmmoTypes { PistolAmmo, RifleAmmo, HeavyAmmo, SniperAmmo }