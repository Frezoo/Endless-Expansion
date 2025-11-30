using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using YG;

public class BaseLogic : MonoBehaviour
{
    [Header("Параметры базы")] [SerializeField]
    private BaseLevel baseLevel = BaseLevel.Base;

    [SerializeField] private List<Sprite> baseSprites = new();
    [SerializeField] private Image BaseView;

    [Header("Фарминг ресурсов")] [SerializeField]
    private Player player;

    [Header("Награды за ресурсы")] [SerializeField]
    private float RewardForHeliy = 2;

    [SerializeField] private float RewardForBiomass = 5;
    [SerializeField] private float RewardForAquaculture = 3;
    [SerializeField] private float RewardForNanocat = 10;

    [Header("Ограничения по продаже")] [SerializeField]
    private float MaxResourceCountToSell = 100;

    [Header("Кнопки продажи")] [SerializeField]
    private Button sellHeliyButton;

    [SerializeField] private Button sellBiomassButton;
    [SerializeField] private Button sellAquacultureButton;
    [SerializeField] private Button sellNanocatButton;


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

        if (YG2.isSDKEnabled)
        {
            LoadBaseSaves();
            Debug.Log("Подгрузка базы");
        }
        else
        {
            Invoke("LoadBaseSaves", 0.03f);
            Debug.Log("Подгрузка базы 1");
        }

        DrawSellPrices();
    }

    public void ReDrawBase()
    {
        Debug.Log((int)baseLevel);
        BaseView.sprite = baseSprites[(int)YG2.saves.BaseLevel];
    }

    public void SellHeliy()
    {
        var heliyToSell = Mathf.Clamp(YG2.saves.heliy, 0, MaxResourceCountToSell);
        if (heliyToSell > 0)
        {
            var award = Mathf.RoundToInt(heliyToSell * RewardForHeliy);
            YG2.saves.money += award;
            YG2.saves.heliy -= Mathf.RoundToInt(heliyToSell);
            YG2.saves.AllMoney += award;
            SoldResources?.Invoke();
            YG2.SaveProgress();
            if(YG2.saves.CurrentPhase == 1)
                PhaseController.instance.CheckTogglesPhase2();
            if(YG2.saves.CurrentPhase == 2)
                PhaseController.instance.CheckTogglesToPhase3();
        }
        
    }

    public void SellBiomass()
    {
        var biomassToSell = Mathf.Clamp(YG2.saves.biomass, 0, MaxResourceCountToSell);
        if (biomassToSell > 0)
        {
            var award = Mathf.RoundToInt(biomassToSell * RewardForBiomass);
            YG2.saves.money += award;
            YG2.saves.AllMoney += award;
            YG2.saves.biomass -= Mathf.RoundToInt(biomassToSell);
            SoldResources?.Invoke();
            YG2.SaveProgress();
            if(YG2.saves.CurrentPhase == 1)
                PhaseController.instance.CheckTogglesPhase2();
            if(YG2.saves.CurrentPhase == 2)
                PhaseController.instance.CheckTogglesToPhase3();
        }
        
    }

    public void SellAquaculture()
    {
        var aquacultureToSell = Mathf.Clamp(YG2.saves.aquaculture, 0, MaxResourceCountToSell);
        if (aquacultureToSell > 0)
        {
            var award = Mathf.RoundToInt(aquacultureToSell * RewardForAquaculture);
            YG2.saves.AllMoney += award;
            YG2.saves.money += award;
            YG2.saves.aquaculture -= Mathf.RoundToInt(aquacultureToSell);
            SoldResources?.Invoke();
            YG2.SaveProgress();
            if(YG2.saves.CurrentPhase == 1)
                PhaseController.instance.CheckTogglesPhase2();
            if(YG2.saves.CurrentPhase == 2)
                PhaseController.instance.CheckTogglesToPhase3();
        }
        
    }

    public void SellNanocat()
    {
        var nanocatToSell = Mathf.Clamp(YG2.saves.nanocat, 0, MaxResourceCountToSell);
        if (nanocatToSell > 0)
        {
            var award = Mathf.RoundToInt(nanocatToSell * RewardForNanocat);
            YG2.saves.AllMoney += award;
            YG2.saves.money += award;
            YG2.saves.nanocat -= Mathf.RoundToInt(nanocatToSell);
            SoldResources?.Invoke();
            YG2.SaveProgress();
            if(YG2.saves.CurrentPhase == 1)
                PhaseController.instance.CheckTogglesPhase2();
            if(YG2.saves.CurrentPhase == 2)
                PhaseController.instance.CheckTogglesToPhase3();
        }
        
    }


    private void DrawSellPrices()
    {
        heliyPrice.text = $"{RewardForHeliy}$/";
        biomassPrice.text = $"{RewardForBiomass}$/";
        aquaculturePrice.text = $"{RewardForAquaculture}$/";
        nanocatPrice.text = $"{RewardForNanocat}$/";
    }

    private void LoadBaseSaves()
    {
        baseLevel = YG2.saves.BaseLevel;
        ReDrawBase();
    }
}