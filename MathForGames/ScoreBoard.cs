using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class ScoreBoard : Actor
    {
        private UIText _redScore;
        private UIText _blueScore;

        public ScoreBoard(UIText redScore, UIText blueScore)
        {
            _redScore = redScore;
            _blueScore = blueScore;
        }

        public override void Start()
        {
            base.Start();
            _redScore.Start();
            _blueScore.Start();
        }

        public override void Update()
        {
            base.Update();
            _redScore.Text = "Red : " + GameStats.RedScore.ToString();
            _redScore.Update();

            _blueScore.Text = "Blue : " + GameStats.BlueScore.ToString();
            _blueScore.Update();
        }

        public override void Draw()
        {
            base.Draw();
            _redScore.Draw();
            _blueScore.Draw();
        }
    }
}
