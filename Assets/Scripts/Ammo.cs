using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Ammo : MonoBehaviour
{
    

    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;

    public Dictionary<string, int> tagToAmmo;

void Awake()
{
    tagToAmmo = new Dictionary<string, int>
{
{ Constants.Pistol , pistolAmmo },
{ Constants.Shotgun , shotgunAmmo },
{ Constants.AssaultRifle , assaultRifleAmmo },
};
}

public void AddAmmo(string tag, int ammo)
{
    if (!tagToAmmo.ContainsKey(tag))
    {
        Debug.LogError("Unrecognized gun type passed: " + tag);
    }
    tagToAmmo[tag] += ammo;
}

// Returns true if gun has ammo
public bool HasAmmo(string tag)
{
    if (!tagToAmmo.ContainsKey(tag))
    {
        Debug.LogError("Unrecognized gun type passed: " + tag);
    }
    return tagToAmmo[tag] > 0;
}

public int GetAmmo(string tag)
{
    if (!tagToAmmo.ContainsKey(tag))
    {
        Debug.LogError("Unrecognized gun type passed:" + tag);
    }
    return tagToAmmo[tag];
}

public void ConsumeAmmo(string tag)
{
    if (!tagToAmmo.ContainsKey(tag))
    {
        Debug.LogError("Unrecognized gun type passed:" + tag);
    }
    tagToAmmo[tag] --;
}

}