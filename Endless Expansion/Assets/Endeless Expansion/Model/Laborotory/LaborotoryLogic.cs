using UnityEngine;
using YG;

public class LaborotoryLogic : MonoBehaviour
{
    [SerializeField] private int NeedHeliyToSyntez = 30;
    [SerializeField] private int NeedBiomassToSyntez = 50;
    [SerializeField] private int NeedAquaToSyntez = 50;
    [SerializeField] private int NanocatPerSyntez = 10;
    
    

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
}
