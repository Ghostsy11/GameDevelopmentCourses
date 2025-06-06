using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] slots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType _ammoType;
        public int _ammoAmount;
    }

    public int AmountOfAmmReturned(AmmoType AmmoType)
    {
        return GetAmmoSlot(AmmoType)._ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType AmmoType)
    {

        GetAmmoSlot(AmmoType)._ammoAmount--;
    }
    public void IncraseCurrentAmmo(AmmoType AmmoType, int ammoAmount)
    {

        GetAmmoSlot(AmmoType)._ammoAmount += ammoAmount;
    }
    private AmmoSlot GetAmmoSlot(AmmoType AmmoType)
    {
        foreach (AmmoSlot Ammoslot in slots)
        {
            if (Ammoslot._ammoType == AmmoType)
            {
                return Ammoslot;
            }
        }
        return null;
    }
}
