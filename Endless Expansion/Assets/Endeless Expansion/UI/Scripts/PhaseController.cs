using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class PhaseController : MonoBehaviour
{
    [SerializeField] private TMP_Text phaseText;
    [SerializeField] private GameObject secondPhasePanel;
    [SerializeField] private GameObject thirdPhasePanel;
    
    [SerializeField] private Toggle phase1Toggle1;
    [SerializeField] private Toggle phase1Toggle2;
    [SerializeField] private Toggle phase1Toggle3;
    
    [SerializeField] private Toggle phase2Toggle1;
    [SerializeField] private Toggle phase2Toggle2;
    [SerializeField] private Toggle phase2Toggle3;
    [SerializeField] private Toggle phase2Toggle4;
    [SerializeField] private Toggle phase2Toggle5;
    
    public static PhaseController instance;

    private void Awake()
    {
        instance = this;
        DrawPhase();
        CheckTogglesPhase2();
    }
    
    private void DrawPhase()
    {
        switch (YG2.saves.CurrentPhase)
        {
            case 1:
                phaseText.text = "1";
                secondPhasePanel.SetActive(true);
                thirdPhasePanel.SetActive(false);
                break;
            case 2:
                phaseText.text = "2";
                secondPhasePanel.SetActive(false);
                thirdPhasePanel.SetActive(true);
                break;
            case 3:
                phaseText.text = "3";
                secondPhasePanel.SetActive(false);
                thirdPhasePanel.SetActive(true);
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
            YG2.saves.CurrentPhase = 2;
            DrawPhase();
        }
    }
}
