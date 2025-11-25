using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int FarmAquaAmount;
        public float AquaUpgradeCoast;
        public float AquaUpgradeCoastResource => Mathf.RoundToInt(50 * Mathf.Pow(1.5f, AquaLevel - 1));
        public int AquaLevel;
        public float AquaAutoFarmAmount => 2 * Mathf.Pow(AquaLevel - 1, 1.7f);
    }
}

