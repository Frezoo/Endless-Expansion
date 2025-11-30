using UnityEngine;
using YG;

public class BuyBioIncubator : MonoBehaviour
{
    public void TryToBuyBioIncubator()
    {
        if (YG2.saves.nanocat >= 150 && YG2.saves.biomass >= 200 && YG2.saves.aquaculture >= 300)
        {
            YG2.saves.nanocat -= 150;
            YG2.saves.biomass -= 200;
            YG2.saves.aquaculture -= 300;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.BioIncubaotrIsBuilded = true;
            YG2.SaveProgress();
            PhaseController.instance.CheckBuildingsToPhase3();
            PhaseController.instance.CheckTogglesToPhase3();
        }
        else
        {
            ThrowAlerts.Instance.ThrowNotEnoughMoneyAlert();
        }
    }
}
