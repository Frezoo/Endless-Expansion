using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class AutoFarm : MonoBehaviour
{
    [SerializeField] private float tickInterval = 0.5f;
    public UnityEvent OnTick;

    private void Awake()
    {
        StartCoroutine(AutoFarmRoutine());
    }

    private IEnumerator AutoFarmRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickInterval);

            var saves = YG2.saves;


            if (saves.BioLevel >= 1)
            {
                saves.biomass += Mathf.RoundToInt(saves.BioAutoFarmAmount);
            }


            if (saves.HeliyLevel >= 1)
            {
                saves.heliy += Mathf.RoundToInt(saves.HeliyAutoFarmAmount);
            }


            if (saves.AquaLevel >= 1)
            {
                saves.aquaculture += Mathf.RoundToInt(saves.AquaAutoFarmAmount);
            }
            OnTick?.Invoke();
        }
    }

    private void OnDestroy()
    {
        YG2.SaveProgress();
    }
}