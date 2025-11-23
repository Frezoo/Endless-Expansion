using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class Player : MonoBehaviour
{

    public UnityEvent ClickedFarmButton;
    
    public void FarmHeliy()
    {
        YG2.saves.heliy += YG2.saves.FarmHeliyAmount;
        ClickedFarmButton?.Invoke();
        YG2.saves.ClickCount++;
    }

    public void FarmAqua()
    {
        YG2.saves.aquaculture += YG2.saves.FarmAquaAmount;
        ClickedFarmButton?.Invoke();
        YG2.saves.ClickCount++;
    }

    public void FarmBiomass()
    {
        YG2.saves.biomass += YG2.saves.FarmBioAmount;
        ClickedFarmButton?.Invoke();
        YG2.saves.ClickCount++;
    }

    public void OnDisable()
    {
        YG2.SaveProgress(); 
    }
}