namespace NewMazeAndBall
{
    internal sealed class GameConstructor
    {
        private MazeCreator _mazeCreator;
        private BonusCreator _bonusCreator;

        internal GameConstructor(int mapLengthX, int maplengthY, int goodBonusCount, int badBonusCount, PlayerBase player)
        {
            _mazeCreator = new MazeCreator(mapLengthX, maplengthY);
            _bonusCreator = new BonusCreator(goodBonusCount, badBonusCount, _mazeCreator, player);
        }

        internal void GenerateGame()
        {
            _mazeCreator.GenerateMap();
            _bonusCreator.GenerateBonus();
        }
    }
}
