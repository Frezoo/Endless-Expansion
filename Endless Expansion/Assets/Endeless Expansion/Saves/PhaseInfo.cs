namespace YG
{
    public partial class SavesYG
    {
        public int CurrentPhase;

        public bool BuyedLaborotory => YG2.saves.BaseLevel.Equals(BaseLevel.BaseWithLab);
        public bool Reached2500Money => YG2.saves.money >= 2500;
        public bool Reached125000Money => YG2.saves.money >= 125000;
        
        
        public bool BaseLevelUppperThen5 => YG2.saves.BaseCurrentLevel >= 5;
        public bool BaseLevelUppperThen20 => YG2.saves.BaseCurrentLevel >= 20;
    }
}

