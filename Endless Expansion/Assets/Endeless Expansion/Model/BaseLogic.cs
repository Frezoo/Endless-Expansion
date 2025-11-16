using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using YG;

public class BaseLogic : MonoBehaviour
{
    
    [Header("Параметры базы")]
    [SerializeField] private BaseLevel baseLevel = BaseLevel.Base;
    [SerializeField] private List<Sprite> baseSprites = new();
    [SerializeField] private Image BaseView;
    
    [Header("Фарминг ресурсов")]
    [SerializeField] private Player player;
    
    [Header("Награды за ресурсы")]
    [SerializeField] private float RewardForHeliy = 2;
    [SerializeField] private float RewardForBiomass = 5;
    [SerializeField] private float RewardForAquaculture = 3;
    [SerializeField] private float RewardForNanocat = 10;

    [Header("Ограничения по продаже")]
    [SerializeField] private float MaxResourceCountToSell = 100;
    
    [Header("Кнопки продажи")]
    [SerializeField] private Button sellHeliyButton;
    [SerializeField] private Button sellBiomassButton;
    [SerializeField] private Button sellAquacultureButton;
    [SerializeField] private Button sellNanocatButton;

    [Header("Кнопки апгрейда")] 
    [SerializeField] private Button updateHeliumCondenser;
    [SerializeField] private Button updateBiomassCollector;
    [SerializeField] private Button updateAquacultureCollector;
    
    [Header("Стоимость апгрейда")]
    [SerializeField] private float upgradeHeliumCondenserCost = 100;
    [SerializeField] private float upgradeBiomassCollectorCost = 100;
    [SerializeField] private float upgradeAquacultureCollectorCost = 100;
    
    [Header("Текст стоимости апгрейда")]
    [SerializeField] private TMP_Text heliumCondenserUpgradePriceText;
    [SerializeField] private TMP_Text biomassCollectorUpgradePriceText;
    [SerializeField] private TMP_Text aquacultureCollectorUpgradePriceText;
    
    [Header("Текст")]
    [SerializeField] private TMP_Text heliyPrice;
    [SerializeField] private TMP_Text biomassPrice;
    [SerializeField] private TMP_Text aquaculturePrice;
    [SerializeField] private TMP_Text nanocatPrice;
    
    public UnityEvent SoldResources;
    
    private void Awake()
    {
        sellHeliyButton.onClick.AddListener(SellHeliy);
        sellBiomassButton.onClick.AddListener(SellBiomass);
        sellAquacultureButton.onClick.AddListener(SellAquaculture);
        sellNanocatButton.onClick.AddListener(SellNanocat);
        
        updateAquacultureCollector.onClick.AddListener(UpgradeAquacultureCollector);
        updateBiomassCollector.onClick.AddListener(UpgradeBiomassCollector);
        updateHeliumCondenser.onClick.AddListener(UpgradeHeliumCondenser);
        
        ReDrawBase();
        
        DrawSellPrices();
        LoadDrawPrices();
        DrawUpgradePrices();
    }

    private void ReDrawBase()
    {
        BaseView.sprite = baseSprites[(int)baseLevel];
    }

    public void SellHeliy()
    {
        var heliyToSell = Mathf.Clamp(YG2.saves.heliy, 0, MaxResourceCountToSell);
        YG2.saves.money += Mathf.RoundToInt(heliyToSell * RewardForHeliy);
        YG2.saves.heliy -= Mathf.RoundToInt(heliyToSell);
        SoldResources?.Invoke();
        YG2.SaveProgress();
    }
    
    public void SellBiomass()
    {
        var biomassToSell = Mathf.Clamp(YG2.saves.biomass, 0, MaxResourceCountToSell);
        YG2.saves.money += Mathf.RoundToInt(biomassToSell * RewardForBiomass);
        YG2.saves.biomass -= Mathf.RoundToInt(biomassToSell);
        SoldResources?.Invoke();
        YG2.SaveProgress();
    }
    
    public void SellAquaculture()
    {
        var aquacultureToSell = Mathf.Clamp(YG2.saves.aquaculture, 0, MaxResourceCountToSell);
        YG2.saves.money += Mathf.RoundToInt(aquacultureToSell * RewardForAquaculture);
        YG2.saves.aquaculture -= Mathf.RoundToInt(aquacultureToSell);
        SoldResources?.Invoke();
        YG2.SaveProgress();
    }
    
    public void SellNanocat()
    {
        var nanocatToSell = Mathf.Clamp(YG2.saves.nanocat, 0, MaxResourceCountToSell);
        YG2.saves.money += Mathf.RoundToInt(nanocatToSell * RewardForNanocat);
        YG2.saves.nanocat -= Mathf.RoundToInt(nanocatToSell);
        SoldResources?.Invoke();
        YG2.SaveProgress();
    }
    
    private void UpgradeHeliumCondenser()
    {
        if(YG2.saves.money >= upgradeHeliumCondenserCost)
        {
            YG2.saves.money -= Mathf.RoundToInt(upgradeHeliumCondenserCost);
            YG2.saves.HeliyLevel += 1;
            YG2.saves.HeliyUpgradeCoast = 100 * YG2.saves.HeliyLevel * 1.5f;
            upgradeHeliumCondenserCost = YG2.saves.HeliyUpgradeCoast;
            YG2.saves.FarmHeliyAmount = 3 * YG2.saves.HeliyLevel;
            heliumCondenserUpgradePriceText.text = YG2.saves.HeliyUpgradeCoast.ToString();
            SoldResources?.Invoke();
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно средств для апгрейда");
        }
    }
    
    private void UpgradeBiomassCollector()
    {
        if(YG2.saves.money >= upgradeBiomassCollectorCost)
        {
            YG2.saves.money -= Mathf.RoundToInt(upgradeBiomassCollectorCost);
            YG2.saves.BioLevel += 1;
            YG2.saves.BioUpgradeCoast = 100 * YG2.saves.BioLevel * 1.5f;
            YG2.saves.FarmBioAmount = 3 * YG2.saves.BioLevel;
            upgradeBiomassCollectorCost = YG2.saves.BioUpgradeCoast;
            biomassCollectorUpgradePriceText.text = YG2.saves.BioUpgradeCoast.ToString();
            SoldResources?.Invoke();
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно средств для апгрейда");
        }
    }
    
    private void UpgradeAquacultureCollector()
    {
        if(YG2.saves.money >= upgradeAquacultureCollectorCost)
        {
            YG2.saves.money -= Mathf.RoundToInt(upgradeAquacultureCollectorCost);
            YG2.saves.AquaLevel += 1;
            YG2.saves.AquaUpgradeCoast = 100 * YG2.saves.AquaLevel * 1.5f;
            YG2.saves.FarmAquaAmount = 3 * YG2.saves.AquaLevel;
            upgradeAquacultureCollectorCost = YG2.saves.AquaUpgradeCoast;
            aquacultureCollectorUpgradePriceText.text = YG2.saves.AquaUpgradeCoast.ToString();
            SoldResources?.Invoke();
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно средств для апгрейда");
        }
    }
    
    private void DrawSellPrices()
    {
        heliyPrice.text = RewardForHeliy.ToString();
        biomassPrice.text = RewardForBiomass.ToString();
        aquaculturePrice.text = RewardForAquaculture.ToString();
        nanocatPrice.text = RewardForNanocat.ToString();
    }

    private void LoadDrawPrices()
    {
        upgradeHeliumCondenserCost = YG2.saves.HeliyUpgradeCoast;
        upgradeAquacultureCollectorCost = YG2.saves.AquaUpgradeCoast;
        upgradeBiomassCollectorCost = YG2.saves.BioUpgradeCoast;
    }
    
    private void DrawUpgradePrices()
    {
        heliumCondenserUpgradePriceText.text = upgradeHeliumCondenserCost.ToString();
        biomassCollectorUpgradePriceText.text = upgradeBiomassCollectorCost.ToString();
        aquacultureCollectorUpgradePriceText.text = upgradeAquacultureCollectorCost.ToString();
    }
    
}
