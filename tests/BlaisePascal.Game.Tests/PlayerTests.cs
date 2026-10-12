using BlaisePascal.Game.Domain;
using System;
using System.Numerics;
using Xunit;

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

        [Fact]
        public void Player_ShouldhaveTheCorrectNameAfterCreation()
        {
            string name = "TestName";
            Player player = new Player(name);
            Assert.Equal(name, player.Name);
        }
        [Fact]
        public void Player_ShouldStartWith100MaxHealth()
        {
            Player player = new Player("Name");
            Assert.Equal(100, player.MaxHealth);
        }
        [Fact]
        public void Player_ShouldStartWith100Health()
        {
            Player player = new Player("Name");
            Assert.Equal(100, player.Health);
        }
        [Fact]
        public void Player_ShouldStartWith0Experience()
        {
            Player player = new Player("Name");
            Assert.Equal(0, player.Experience);
        }
        [Fact]
        public void Player_ShouldStartWith0Gold()
        {
            Player player = new Player("Name");
            Assert.Equal(0, player.Gold);
        }
        [Fact]
        public void Player_ShouldBeAliveAfterCreation()
        {
            Player player = new Player("Name");
            Assert.True(player.IsAlive);
        }
        [Fact]
        public void AddExperience_CannotAddNegativeExperience()
        {
            Player player = new Player("Name");
            Assert.Throws<ArgumentException>(() => player.AddExperience(-1));
        }
        [Fact]
        public void AddExperience_AfterHavingadded99ExperienceIs99()
        {
            Player player = new Player("Name");
            player.AddExperience(99);
            Assert.Equal(99, player.Experience);
        }
        [Fact]
        public void AddExperience_AfterHavingAdded101ExperienceIs1AndLevelIs2()
        {
            Player player = new Player("Name");
            player.AddExperience(101);
            Assert.Equal(1, player.Experience);
            Assert.Equal(2, player.Level);
        }
        [Fact]
        public void TakeDamage_AfterPlayerIsCreatedAndTook1DamageHealthIs99()
        {
            Player player = new Player("Name");
            player.TakeDamage(1);
            Assert.Equal(99, player.Health);
        }
        [Fact]
        public void TakeDamage_CannotTakeNegativeDamage()
        {
            Player player = new Player("Name");
            Assert.Throws<ArgumentException>(() => player.TakeDamage(-1));
        }
        [Fact]
        public void TakeDamage_AfterPlayerTakeADamageEqualToHisMaxHealthItIsNotAlive()
        {
            Player player = new Player("Name");
            player.TakeDamage(player.MaxHealth);
            Assert.False(player.IsAlive);
        }
        [Fact]
        public void Heal_WhenPlayerHasMaxHealthMinus1HealthAndHeHealsOf1HisHealthIsAgianEqualToHisMaxHealth()
        {
            Player player = new Player("Name");
            player.TakeDamage(1);
            player.Heal(1);
            Assert.Equal(player.MaxHealth, player.Health);
        }
        [Fact]
        public void Heal_CannotHealByNegativeNumbers()
        {
            Player player = new Player("Name");
            Assert.Throws<ArgumentException>(() => player.Heal(-1));
        }
        [Fact]
        public void Heal_AfterADeadPlayerHealsByAnyPositiveNumberHisHealthRemains0AndHeIsStillDead()
        {
            Player player = new Player("Name");
            player.TakeDamage(player.MaxHealth);
            player.Heal(1);
            Assert.False(player.IsAlive);
            Assert.Equal(0, player.Health);
        }
        [Fact]
        public void ResetExperience_WhenPlayerHas99ExperienceAndItGetsResettedExperienceIs0()
        {
            Player player = new Player("Name");
            player.AddExperience(99);
            player.ResetExperience();
            Assert.Equal(0, player.Experience);
        }
        [Fact]
        public void ResetHealth_WhenPlayerHas50HealthAndItGetsResettedHealthIs100()
        {
            Player player = new Player("Name");
            player.TakeDamage(50);
            player.ResetHealth();
            Assert.Equal(player.MaxHealth, player.Health);
        }
        [Fact]
        public void ResetHealth_WhenPlayerIsNotAliveAndHisHealthGetsResettedHeIsAlive()
        {
            Player player = new Player("Name");
            player.TakeDamage(player.MaxHealth);
            Assert.False(player.IsAlive);
            player.ResetHealth();
            Assert.True(player.IsAlive);
        }
        [Fact]
        public void AddGold_CannotAddNegativeGold()
        {
            Player player = new Player("Name");
            Assert.Throws<ArgumentException>(() => player.AddGold(-1));
        }
        [Fact]
        public void AddGold_AfterHavingadded2GoldIs2()
        {
            Player player = new Player("Name");
            player.AddGold(99);
            Assert.Equal(99, player.Gold);
        }
    }
}