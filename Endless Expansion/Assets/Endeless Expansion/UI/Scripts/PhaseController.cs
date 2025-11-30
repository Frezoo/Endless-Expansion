using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class PhaseController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private TMP_Text phaseText;
    [SerializeField] private GameObject secondPhasePanel;
    [SerializeField] private GameObject thirdPhasePanel;
    [SerializeField] private Image planet;
    [SerializeField] private Sprite planetPhase1;
    [SerializeField] private Sprite planetPhase2;
    [SerializeField] private Sprite planetPhase3;
    
    [Header("Phase 1")]
    [SerializeField] private Toggle phase1Toggle1;
    [SerializeField] private Toggle phase1Toggle2;
    [SerializeField] private Toggle phase1Toggle3;
    
    [Header("Phase2")]
    [SerializeField] private Toggle phase2Toggle1;
    [SerializeField] private Toggle phase2Toggle2;
    [SerializeField] private Toggle phase2Toggle3;
    [SerializeField] private Toggle phase2Toggle4;
    [SerializeField] private Toggle phase2Toggle5;

    [SerializeField] private GameObject phase2BuyPanel;
    [SerializeField] private GameObject phase1BuyPanel;
    [SerializeField] private GameObject buyAtmosferProcessor;
    [SerializeField] private GameObject buyOrbitalMirror;
    [SerializeField] private GameObject buyBioIncubator;
    
    public static PhaseController instance;

    private void Awake()
    {
        instance = this;
        DrawPhase();
        if (YG2.saves.CurrentPhase == 1)
        {
            CheckTogglesPhase2();
            
        }
           
        if (YG2.saves.CurrentPhase == 2)
        {
            instance.CheckTogglesToPhase3();
            CheckBuildingsToPhase3();
        }
            
        
    }

    public void CheckBuildingsToPhase3()
    {
        if(YG2.saves.CurrentPhase == 2)
        {
            if (YG2.saves.AtmosferProcessorIsBuilded == false)
            {
                buyAtmosferProcessor.SetActive(true);
                buyOrbitalMirror.SetActive(false);
                buyBioIncubator.SetActive(false);
            }
            else if (YG2.saves.OrbitalMirrorIsBuilded == false)
            {
                buyAtmosferProcessor.SetActive(false);
                buyOrbitalMirror.SetActive(true);
                buyBioIncubator.SetActive(false);  
            }
            else
            {
                buyAtmosferProcessor.SetActive(false);
                buyOrbitalMirror.SetActive(false);
                if(!YG2.saves.BioIncubaotrIsBuilded)
                {buyBioIncubator.SetActive(true);}
            }
        }
    }

    private void DrawPhase()
    {
        switch (YG2.saves.CurrentPhase)
        {
            case 1:
                if(YG2.saves.ClickCount == 0)
                    ThrowAlerts.Instance.ThorPhase1Alert();
                phaseText.text = "1";
                secondPhasePanel.SetActive(true);
                thirdPhasePanel.SetActive(false);
                phase1BuyPanel.SetActive(true);
                phase2BuyPanel.SetActive(false);
                planet.sprite = planetPhase1;
                break;
            case 2:
                phaseText.text = "2";
                secondPhasePanel.SetActive(false);
                thirdPhasePanel.SetActive(true);
                phase1BuyPanel.SetActive(false);
                phase2BuyPanel.SetActive(true);
                planet.sprite = planetPhase2;
                CheckBuildingsToPhase3();
                break;
            case 3:
                phaseText.text = "3";
                secondPhasePanel.SetActive(false);
                thirdPhasePanel.SetActive(true);
                planet.sprite = planetPhase3;
                break;
        }
    }

    public void CheckTogglesPhase2()
    {
        if(YG2.saves.BuyedLaborotory)
        {
            phase1Toggle1.isOn = true;
        }

        if (YG2.saves.Reached2500Money)
        {
            phase1Toggle2.isOn = true;
        }
        else
        {
            phase1Toggle2.isOn = false;
        }

        if (YG2.saves.BaseLevelUppperThen5)
        {
            phase1Toggle3.isOn = true;
        }

        if (YG2.saves.BaseLevelUppperThen5 && YG2.saves.BuyedLaborotory && YG2.saves.Reached2500Money)
        {
            ThrowAlerts.Instance.ThrowNewPhaseAlert();
            YG2.saves.CurrentPhase = 2;
            DrawPhase();
            ThrowAlerts.Instance.ThorPhase2Alert();
        }
    }
    public void CheckTogglesToPhase3()
    {
        if (YG2.saves.AtmosferProcessorIsBuilded)
        {
            phase2Toggle1.isOn = true;
        }

        if (YG2.saves.OrbitalMirrorIsBuilded)
        {
            phase2Toggle2.isOn = true;
        }

        if (YG2.saves.BioIncubaotrIsBuilded)
        {
            phase2Toggle3.isOn = true;
            buyBioIncubator.SetActive(false);
        }

        if (YG2.saves.Reached125000Money)
        {
            phase2Toggle4.isOn = true;
        }
        else
        {
            phase2Toggle4.isOn = false;
        }

        if (YG2.saves.BaseLevelUppperThen20)
        {
            phase2Toggle5.isOn = true;
        }
        
        if (YG2.saves.AtmosferProcessorIsBuilded && YG2.saves.OrbitalMirrorIsBuilded && YG2.saves.BioIncubaotrIsBuilded && YG2.saves.Reached125000Money && YG2.saves.BaseLevelUppperThen20)
        {
            ThrowAlerts.Instance.ThrowNewPhaseAlert();
            YG2.saves.CurrentPhase = 3;
            DrawPhase();
            ThrowAlerts.Instance.ThorPhase3Alert();
        }
        
    }
}
