using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public BaseLevel BaseLevel;

        public int BaseCurrentLevel;
        public int BaseUpgradeCoast => Mathf.RoundToInt(150* Mathf.Pow(1.3f, BaseCurrentLevel-1));

        public float BaseHealth;
        
        public float MaxBaseHealth => 200 * Mathf.Pow(1.4f, BaseCurrentLevel - 1);
    }
}

