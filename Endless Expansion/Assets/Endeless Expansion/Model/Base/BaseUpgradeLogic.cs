using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;

public class BaseUpgradeLogic : MonoBehaviour
{
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

    [Header("Ссылка на BaseLogic")]
    [SerializeField] private BaseLogic baseLogic;

    private void Awake()
    {
        if (baseLogic == null) baseLogic = GetComponent<BaseLogic>();

        if (updateAquacultureCollector != null) updateAquacultureCollector.onClick.AddListener(UpgradeAquacultureCollector);
        if (updateBiomassCollector != null) updateBiomassCollector.onClick.AddListener(UpgradeBiomassCollector);
        if (updateHeliumCondenser != null) updateHeliumCondenser.onClick.AddListener(UpgradeHeliumCondenser);

        LoadDrawPrices();
        DrawUpgradePrices();
    }

    private void UpgradeHeliumCondenser()
    {
        if (YG2.saves.money >= upgradeHeliumCondenserCost)
        {
            YG2.saves.money -= Mathf.RoundToInt(upgradeHeliumCondenserCost);
            YG2.saves.HeliyLevel += 1;
            YG2.saves.HeliyUpgradeCoast = 100 * YG2.saves.HeliyLevel * 1.5f;
            upgradeHeliumCondenserCost = YG2.saves.HeliyUpgradeCoast;
            YG2.saves.FarmHeliyAmount = 3 * YG2.saves.HeliyLevel;
            if (heliumCondenserUpgradePriceText != null) heliumCondenserUpgradePriceText.text = YG2.saves.HeliyUpgradeCoast.ToString();
            baseLogic?.SoldResources?.Invoke();
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно средств для апгрейда");
        }
    }

    private void UpgradeBiomassCollector()
    {
        if (YG2.saves.money >= upgradeBiomassCollectorCost)
        {
            YG2.saves.money -= Mathf.RoundToInt(upgradeBiomassCollectorCost);
            YG2.saves.BioLevel += 1;
            YG2.saves.BioUpgradeCoast = 100 * YG2.saves.BioLevel * 1.5f;
            YG2.saves.FarmBioAmount = 3 * YG2.saves.BioLevel;
            upgradeBiomassCollectorCost = YG2.saves.BioUpgradeCoast;
            if (biomassCollectorUpgradePriceText != null) biomassCollectorUpgradePriceText.text = YG2.saves.BioUpgradeCoast.ToString();
            baseLogic?.SoldResources?.Invoke();
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно средств для апгрейда");
        }
    }

    private void UpgradeAquacultureCollector()
    {
        if (YG2.saves.money >= upgradeAquacultureCollectorCost)
        {
            YG2.saves.money -= Mathf.RoundToInt(upgradeAquacultureCollectorCost);
            YG2.saves.AquaLevel += 1;
            YG2.saves.AquaUpgradeCoast = 100 * YG2.saves.AquaLevel * 1.5f;
            YG2.saves.FarmAquaAmount = 3 * YG2.saves.AquaLevel;
            upgradeAquacultureCollectorCost = YG2.saves.AquaUpgradeCoast;
            if (aquacultureCollectorUpgradePriceText != null) aquacultureCollectorUpgradePriceText.text = YG2.saves.AquaUpgradeCoast.ToString();
            baseLogic?.SoldResources?.Invoke();
            YG2.SaveProgress();
        }
        else
        {
            Debug.Log("Недостаточно средств для апгрейда");
        }
    }

    private void LoadDrawPrices()
    {
        upgradeHeliumCondenserCost = YG2.saves.HeliyUpgradeCoast;
        upgradeAquacultureCollectorCost = YG2.saves.AquaUpgradeCoast;
        upgradeBiomassCollectorCost = YG2.saves.BioUpgradeCoast;
    }

    private void DrawUpgradePrices()
    {
        if (heliumCondenserUpgradePriceText != null) heliumCondenserUpgradePriceText.text = upgradeHeliumCondenserCost.ToString();
        if (biomassCollectorUpgradePriceText != null) biomassCollectorUpgradePriceText.text = upgradeBiomassCollectorCost.ToString();
        if (aquacultureCollectorUpgradePriceText != null) aquacultureCollectorUpgradePriceText.text = upgradeAquacultureCollectorCost.ToString();
    }
}
