using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int FarmBioAmount;
        public float BioUpgradeCoast;
        public float BioUpgradeCoastResource => Mathf.RoundToInt(50 * Mathf.Pow(1.5f, BioLevel - 1));
        public int BioLevel;
        public float BioAutoFarmAmount => 2 * Mathf.Pow(BioLevel - 1, 1.7f);
    }
}

