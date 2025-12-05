using UnityEngine;
using UnityEngine.UI;
using YG;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider GeneralVolumeSlider;
    [SerializeField] private Slider MusicVolumeSlider;
    
    [SerializeField] private float generalVolume;
    [SerializeField] private float musicVolume;
    
    [SerializeField] private AudioSource musicListener;
    private void Awake()
    {
        GeneralVolumeSlider.onValueChanged.AddListener(ChangeGeneralVolume);
        MusicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        if (YG2.isSDKEnabled)
        {
            OnSavesReady();
        }
        else
        {
            Invoke("OnSavesReady", 0.03f);
        }
        
    }

    private void ChangeGeneralVolume(float Value)
    {
        generalVolume = Value;
        AudioListener.volume = generalVolume;
        YG2.saves.GeneralVolume = generalVolume;
    }
    
    private void ChangeMusicVolume(float Value)
    {
        musicVolume = Value;
        musicListener.volume = musicVolume;
        YG2.saves.MusicVolume = musicVolume;
    }

    private void OnDisable()
    {
        YG2.SaveProgress();
    }

    private void OnSavesReady()
    {
        GeneralVolumeSlider.value = YG2.saves.GeneralVolume;
        MusicVolumeSlider.value = YG2.saves.MusicVolume;
        
        musicListener.volume = YG2.saves.MusicVolume;;
        AudioListener.volume = YG2.saves.GeneralVolume;
    }

    private void OnDestroy()
    {
        YG2.onGetSDKData -= OnSavesReady;
    }
}
