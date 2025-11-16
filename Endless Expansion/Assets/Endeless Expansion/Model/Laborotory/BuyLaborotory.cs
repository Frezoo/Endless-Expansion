using UnityEngine;
using YG;


public class BuyLaborotory : MonoBehaviour
{
    [SerializeField] private BaseLogic baseLogic;
    public void TryBuyLaborotory()
    {
        if (YG2.saves.money >= 2500)
        {
            YG2.saves.money -= 2500;
            YG2.saves.BaseLevel = BaseLevel.BaseWithLab;
            gameObject.SetActive(false);
            YG2.SaveProgress();
            ChangeStantions.Instance.GoToLaboratoryStantion();
            baseLogic.ReDrawBase();
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
