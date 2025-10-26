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
        YG2.saves.heliy += 1;
        YG2.SaveProgress();
        ClickedFarmButton.Invoke();
        
    }

    public void FarmNanocatalys()
    {
        YG2.saves.nanocat += 1;
        YG2.SaveProgress();
        ClickedFarmButton.Invoke();
    }

    public void FarmBiomass()
    {
        YG2.saves.biomass += 1;
        YG2.SaveProgress();
        ClickedFarmButton.Invoke();
    }
}