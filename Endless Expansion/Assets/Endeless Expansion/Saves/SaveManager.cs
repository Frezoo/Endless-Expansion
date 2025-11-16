using UnityEngine;
using YG;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string StandardLanguage = "ru";
    public float StandardGeneralVolume = 1;
    public float StandardMusicVolume = 1;
    public int StandardBiomass;
    public int StandardHeliy;
    public int StandardMoney;
    public int StandardNanocat;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        YG2.onDefaultSaves += FristStartSetup;
    }

    public void SetDefaultParams()
    {
        YG2.saves.biomass = StandardBiomass;
        YG2.saves.heliy = StandardHeliy;
        YG2.saves.money = StandardMoney;
        YG2.saves.nanocat = StandardNanocat;
        YG2.saves.BaseLevel = BaseLevel.Base;
        
        YG2.saves.FarmHeliyAmount = 1;
        YG2.saves.HeliyLevel = 1;
        YG2.saves.HeliyUpgradeCoast = 100;

        YG2.saves.FarmAquaAmount = 1;
        YG2.saves.AquaLevel = 1;
        YG2.saves.AquaUpgradeCoast = 100;
        
        YG2.saves.FarmBioAmount = 1;
        YG2.saves.BioLevel = 1;
        YG2.saves.BioUpgradeCoast = 100;
        
        YG2.SaveProgress();
    }
    
    public void FristStartSetup()
    {
        SetDefaultParams();
        
        YG2.saves.Language = StandardLanguage;
        YG2.saves.GeneralVolume = StandardGeneralVolume;
        YG2.saves.MusicVolume = StandardMusicVolume;
        YG2.SaveProgress();
    }
    
}