using System;
using UnityEngine;
using YG;

public class PhaseControlerModel : MonoBehaviour
{
    private int currentPhase => YG2.saves.CurrentPhase;
    private PhaseController ui;

    private void Update()
    {
        if (currentPhase == 1)
        {
            if (YG2.saves.BaseLevelUppperThen5)
            {
                
            }
        }
    }
}
