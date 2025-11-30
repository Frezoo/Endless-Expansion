using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UiController : MonoBehaviour
{
    [Header("Текстовое представление характеристик")]
    [SerializeField] private TMP_Text biomassText;
    [SerializeField] private TMP_Text heliyText;
    [SerializeField] private TMP_Text nanocatText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text aquacultureText;
    [SerializeField] private TMP_Text baseLevelText;

    [Header("Модель")] 
    [SerializeField] private Player player;
    [SerializeField] private BaseLogic baseLogic;
    [SerializeField] private AutoFarm autoFarm;
    [SerializeField] private LaborotoryLogic laborotory;

    public static UiController Instance;
    
    
    private void Awake()
    {
        Instance = this;
        if (player == null)
        {
            Debug.LogWarning("Отсутсвует игрок");
            return;
        }
        
        ReDrawHaracteristic();
        player.ClickedFarmButton.AddListener(ReDrawHaracteristic);
        baseLogic.SoldResources.AddListener(ReDrawHaracteristic);
        autoFarm.OnTick.AddListener(ReDrawHaracteristic);
        laborotory.Syntez.AddListener(ReDrawHaracteristic);
        
    }
    public void ReDrawHaracteristic()
    {
        biomassText.text = YG2.saves.biomass.ToString();
        heliyText.text = YG2.saves.heliy.ToString();
        nanocatText.text = YG2.saves.nanocat.ToString();
        moneyText.text = YG2.saves.money.ToString();
        aquacultureText.text = YG2.saves.aquaculture.ToString();
        baseLevelText.text = YG2.saves.BaseCurrentLevel.ToString();
    }
}
