using BlaisePascal.Game.Domain;
using System.Numerics;

namespace BlaisePascal.Game.Tests
{

    public class PlayerTests
    {
        [Fact]
        public void Player_ShouldStartAtLevelOne()
        {
            Player player = new Player("Name");

            Assert.Equal(1, player.Level);
        }

        public void Player_shouldBeNamed
    }
}
