using UnityEngine;
using UnityEngine.Events;
using YG;


public class BuyLaborotory : MonoBehaviour
{
    [SerializeField] private BaseLogic baseLogic;
    [SerializeField] private GameObject parnet;
    [SerializeField] private GameObject laboratory;


    private void Awake()
    {
        if (YG2.saves.BaseLevel >= BaseLevel.BaseWithLab)
        {
            parnet.SetActive(false);
            laboratory.SetActive(true);
        }
        else
        {
            parnet.SetActive(true);
            laboratory.SetActive(false);
        }
    }
    
    public void TryBuyLaborotory()
    {
        if (YG2.saves.money >= 1000 && YG2.saves.heliy >= 100 && YG2.saves.biomass >= 200)
        {
            YG2.saves.money -= 1000;
            YG2.saves.heliy -= 100;
            YG2.saves.biomass -= 200;
            YG2.saves.BaseLevel = BaseLevel.BaseWithLab;
            gameObject.SetActive(false);
            YG2.SaveProgress();
            ChangeStantions.Instance.GoToLaboratoryStantion();
            laboratory.SetActive(true);
            baseLogic.ReDrawBase();
            PhaseController.instance.CheckTogglesPhase2();
        }
        else
        {
            ThrowAlerts.Instance.ThrowNotEnoughMoneyAlert();
        }
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        ChangeStantions.Instance.EnableBasePanel();
    }
}
