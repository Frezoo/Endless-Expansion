using UnityEngine;
using UnityEngine.UI;
using YG;

public class BuyColonyBuildings : MonoBehaviour
{
    [SerializeField] private Button BuyRA;
    [SerializeField] private Button BuySQ;
    [SerializeField] private Button BuyIZ;
    [SerializeField] private Button BuyG;
    [SerializeField] private Button BuyTN;
    [SerializeField] private Button BuyEC;
    [SerializeField] private Button BuyU;

    private void Awake()
    {
        BuyRA.onClick.AddListener(OnBuyRA);
        BuySQ.onClick.AddListener(OnBuySQ);
        BuyIZ.onClick.AddListener(OnBuyIZ);
        BuyG.onClick.AddListener(OnBuyG);
        BuyTN.onClick.AddListener(OnBuyTN);
        BuyEC.onClick.AddListener(OnBuyEC);
        BuyU.onClick.AddListener(OnBuyU);
    }

    private void OnBuyRA()
    {
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.RededentalAreaIsBuilded = true;
            BuyRA.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
    private void OnBuySQ()
    {
        
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.SQIsBuilded = true;
            BuySQ.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
    private void OnBuyIZ()
    {
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.IZIsBuilded = true;
            BuyIZ.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
    private void OnBuyG()
    {
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.GIsBuilded = true;
            BuyG.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
    private void OnBuyTN()
    {
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.TNIsBuilded = true;
            BuyTN.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
    private void OnBuyEC()
    {
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.ECIsBuilded = true;
            BuyEC.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
    private void OnBuyU()
    {
        if (YG2.saves.money >= 65000)
        {
            YG2.saves.money -= 65000;
            UiController.Instance.ReDrawHaracteristic();
            YG2.saves.UIsbuilded = true;
            BuyU.interactable = false;
            PhaseController.instance.CheckTogglesEnd();
            YG2.SaveProgress();
        }
    }
}
