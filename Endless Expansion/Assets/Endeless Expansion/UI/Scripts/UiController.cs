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

    [Header("Модель")] 
    [SerializeField] private Player player;
    [SerializeField] private BaseLogic baseLogic;
    

    private void Awake()
    {
        if (player == null)
        {
            Debug.LogWarning("Отсутсвует игрок");
            return;
        }

        ReDrawHaracteristic();
        player.ClickedFarmButton.AddListener(ReDrawHaracteristic);
        baseLogic.SoldResources.AddListener(ReDrawHaracteristic);
    }

    private void ReDrawHaracteristic()
    {
        biomassText.text = YG2.saves.biomass.ToString();
        heliyText.text = YG2.saves.heliy.ToString();
        nanocatText.text = YG2.saves.nanocat.ToString();
        moneyText.text = YG2.saves.money.ToString();
    }
}
