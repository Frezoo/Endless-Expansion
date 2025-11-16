using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int FarmAquaAmount;
        public float AquaUpgradeCoast;
        public int AquaLevel;
        public float AquaAutoFarmAmount => 2 * Mathf.Pow(AquaLevel - 1, 1.7f);
    }
}

