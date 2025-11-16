using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int FarmBioAmount;
        public float BioUpgradeCoast;
        public int BioLevel;
        public float BioAutoFarmAmount => 2 * Mathf.Pow(BioLevel - 1, 1.7f);
    }
}

