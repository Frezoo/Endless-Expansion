using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LaborotoryLogic : MonoBehaviour
{
    [SerializeField] private int NeedHeliyToSyntez = 30;
    [SerializeField] private int NeedBiomassToSyntez = 50;
    [SerializeField] private int NeedAquaToSyntez = 50;
    [SerializeField] private int NanocatPerSyntez = 10;

    [SerializeField] private int effectivityUpgradeCost = 400;
    
    [SerializeField] private TMP_Text sintezPriceText;
    [SerializeField] private TMP_Text upgradeEffectivtyText;
    
    [SerializeField] private Button upgradeEffectivityButton;



    private void Awake()
    {
        CheckUpgrade();
        upgradeEffectivityButton.interactable = !YG2.saves.effectivityWasUpgraded;
        upgradeEffectivityButton.onClick.AddListener(UpgradeEffectivity);
        ReDraw();
    }

    private void ReDraw()
    {
        sintezPriceText.text =
            $"{NeedBiomassToSyntez} <sprite name=\"biomass\"> + {NeedHeliyToSyntez}<sprite name=\"heliy\"> + {NeedAquaToSyntez}<sprite name=\"aquaculture\">";
        upgradeEffectivtyText.text = $"{effectivityUpgradeCost}$";

    }
    
    public void TrySyntez()
    {
        if(YG2.saves.heliy >= NeedHeliyToSyntez && YG2.saves.biomass >= NeedBiomassToSyntez && YG2.saves.aquaculture >= NeedAquaToSyntez)
        {
            YG2.saves.heliy -= NeedHeliyToSyntez;
            YG2.saves.biomass -= NeedBiomassToSyntez;
            YG2.saves.aquaculture -= NeedAquaToSyntez;
            YG2.saves.nanocat += NanocatPerSyntez;
            YG2.SaveProgress();
        }
        else
        {
            ThrowAlerts.Instance.ThrowNotEnoughMoneyAlert(); //TODO Create new alert for not enough resources
        }
    }

    private void UpgradeEffectivity()
    {
        if(YG2.saves.money >= effectivityUpgradeCost)
        {
            YG2.saves.money -= effectivityUpgradeCost;
            NeedAquaToSyntez = Mathf.RoundToInt(NeedAquaToSyntez * 0.8f);
            NeedBiomassToSyntez = Mathf.RoundToInt(NeedBiomassToSyntez * 0.8f);
            NeedHeliyToSyntez = Mathf.RoundToInt(NeedHeliyToSyntez * 0.8f);
            YG2.saves.effectivityWasUpgraded = true;
            upgradeEffectivityButton.interactable = false;
            ReDraw();
            YG2.SaveProgress();
        }
        else
        {
            ThrowAlerts.Instance.ThrowNotEnoughMoneyAlert();
        }
    }

    private void CheckUpgrade()
    {
        if (YG2.saves.effectivityWasUpgraded == true)
        {
            NeedAquaToSyntez = Mathf.RoundToInt(NeedAquaToSyntez * 0.8f);
            NeedBiomassToSyntez = Mathf.RoundToInt(NeedBiomassToSyntez * 0.8f);
            NeedHeliyToSyntez = Mathf.RoundToInt(NeedHeliyToSyntez * 0.8f);
        }
    }
}
