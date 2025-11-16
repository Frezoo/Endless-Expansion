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
        YG2.SaveProgress();
        ClickedFarmButton.Invoke();
        
    }

    public void FarmAqua()
    {
        YG2.saves.aquaculture += YG2.saves.FarmAquaAmount;
        YG2.SaveProgress();
        ClickedFarmButton.Invoke();
    }

    public void FarmBiomass()
    {
        YG2.saves.biomass += YG2.saves.FarmBioAmount;
        YG2.SaveProgress();
        ClickedFarmButton.Invoke();
    }
}