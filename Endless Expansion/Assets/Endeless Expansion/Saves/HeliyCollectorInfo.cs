using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int FarmHeliyAmount;
        public float HeliyUpgradeCoast;
        public int HeliyLevel;
        public float HeliyAutoFarmAmount => 2 * Mathf.Pow(HeliyLevel - 1, 1.7f);
    }
}

