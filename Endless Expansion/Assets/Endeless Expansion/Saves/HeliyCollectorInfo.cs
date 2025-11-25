using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int FarmHeliyAmount;
        public float HeliyUpgradeCoast;
        public float HeliyUpgradeCoastResource => Mathf.RoundToInt(50 * Mathf.Pow(1.5f, HeliyLevel - 1));
        public int HeliyLevel;
        public float HeliyAutoFarmAmount => 2 * Mathf.Pow(HeliyLevel - 1, 1.7f);
    }
}

