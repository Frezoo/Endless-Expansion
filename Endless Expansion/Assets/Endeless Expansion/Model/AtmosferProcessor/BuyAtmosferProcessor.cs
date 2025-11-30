using UnityEngine;
using YG;

public class BuyAtmosferProcessor : MonoBehaviour
{
    public void TryToBuyAtmosferProcessor()
    {
        if (YG2.saves.nanocat >= 50 && YG2.saves.heliy >= 200)
        {
            YG2.saves.nanocat -= 50;
            YG2.saves.heliy -= 200;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.AtmosferProcessorIsBuilded = true;
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
