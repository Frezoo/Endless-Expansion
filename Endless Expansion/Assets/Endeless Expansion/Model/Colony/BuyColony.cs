using System;
using UnityEngine;
using YG;

public class BuyColony : MonoBehaviour
{
   [SerializeField] private GameObject parent;
   [SerializeField] private GameObject colony;

   private void Awake()
   {
      if (YG2.saves.ColonyIsBuilded)
      {
         parent.SetActive(false);
         colony.SetActive(true);
      }
      else
      {
         colony.SetActive(false);
      }
   }

   public void TryToBuyColony()
   {
      if (YG2.saves.money >= 65000)
      {
         YG2.saves.money -= 65000;
         YG2.saves.ColonyIsBuilded = true;
         UiController.Instance.ReDrawHaracteristic();
         parent.SetActive(false);
         colony.SetActive(true);
         PhaseController.instance.CheckTogglesEnd();
      }
      else
      {
         ThrowAlerts.Instance.ThrowNotEnoughMoneyAlert();
      }
   }
}
