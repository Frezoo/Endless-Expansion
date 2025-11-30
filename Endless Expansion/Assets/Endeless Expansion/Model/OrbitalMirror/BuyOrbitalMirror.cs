using UnityEngine;
using YG;

public class BuyOrbitalMirror : MonoBehaviour
{
    [SerializeField] private GameObject OrbitalMirror;
    public void TryToBuyOrbitalMirror()
    {
        if (YG2.saves.nanocat >= 100 && YG2.saves.heliy >= 500)
        {
            YG2.saves.nanocat -= 100;
            YG2.saves.heliy -= 500;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.OrbitalMirrorIsBuilded = true;
            YG2.SaveProgress();
            OrbitalMirror.SetActive(true);
            PhaseController.instance.CheckBuildingsToPhase3();
            PhaseController.instance.CheckTogglesToPhase3();
        }
        else
        {
            ThrowAlerts.Instance.ThrowNotEnoughMoneyAlert();
        }
    }
}
