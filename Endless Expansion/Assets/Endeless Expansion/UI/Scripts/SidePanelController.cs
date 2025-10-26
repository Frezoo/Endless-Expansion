using UnityEngine;

public class SidePanelController : MonoBehaviour
{
    [Header("Группа")]
    [SerializeField] private CanvasGroup canvasGroup;
    
    [Header("Панели")]
    [SerializeField] private GameObject basePanel;
    [SerializeField] private GameObject colonyPanel;
    [SerializeField] private GameObject laboratoryPanel;

    private GameObject activePanel;

    public void EnableBasePanel()
    {
        if(activePanel != null)
            activePanel.SetActive(false);
        basePanel.SetActive(true);
        activePanel = basePanel;
    }

    public void EnableColonyPanel()
    {
        if(activePanel != null)
            activePanel.SetActive(false);
        colonyPanel.SetActive(true);
        activePanel = colonyPanel;
    }

    public void EnableLaboratoryPanel()
    {
        if(activePanel != null)
            activePanel.SetActive(false);
        laboratoryPanel.SetActive(true);
        activePanel = laboratoryPanel;
    }
}
