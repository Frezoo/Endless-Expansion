using TMPro;
using UnityEngine;
using YG;
public class PhaseController : MonoBehaviour
{
    [SerializeField] private TMP_Text phaseText;
    [SerializeField] private GameObject secondPhasePanel;
    [SerializeField] private GameObject thirdPhasePanel;

    private void Awake()
    {
       // DrawPhase();
    }
    
    // private void DrawPhase()
    // {
    //     switch (YG2.saves.currentPhase)
    //     {
    //         case 1:
    //             phaseText.text = "1";
    //             secondPhasePanel.SetActive(true);
    //             thirdPhasePanel.SetActive(false);
    //             break;
    //         case 2:
    //             phaseText.text = "2";
    //             secondPhasePanel.SetActive(false);
    //             thirdPhasePanel.SetActive(true);
    //             break;
    //         case 3:
    //             phaseText.text = "3";
    //             secondPhasePanel.SetActive(false);
    //             thirdPhasePanel.SetActive(true);
    //             break;
    //     }
    // }
}
