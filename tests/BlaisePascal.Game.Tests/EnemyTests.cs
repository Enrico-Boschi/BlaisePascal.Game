using System;
using System.Collections.Generic;
using System.Text;
using BlaisePascal.Game.Domain;

namespace BlaisePascal.Game.Tests
{
    public class EnemyTests
    {
        [Fact]
        public void Enemy_WhenAnEnemyWithTheNameEnemyIsCreatedHisNameIsEnemy()
        {
            Enemy enemy = new Enemy("Enemy", 76, 67);
            Assert.Equal("Enemy", enemy.Name);
        }

        [Fact]
        public void Enemy_WhenAnEnemyWith100HealthIsCreatedHisHealthIs100()
        {
            Enemy enemy = new Enemy("Enemy", 100, 67);
            Assert.Equal(100, enemy.Health);
        }
        [Fact]
        public void Enemy_WhenAnEnemyWith100AttackisCreatedHisAttackIs100()
        {
            Enemy enemy = new Enemy("Enemy", 76, 100);
            Assert.Equal(100, enemy.Damage);
        }
        [Fact]
        public void Enemy_AfterHeIsCreatedHeIsAlive()
        {
            Enemy enemy = new Enemy("Enemy", 76, 67);
            Assert.True(enemy.IsAlive());
        }
        [Fact]
        public void Enemy_WhenAnEnemyIsCreatedWithNameEnemyAndHisNameIsChangedToNameHisNameIsName()
        {
            Enemy enemy = new Enemy("Enemy", 76, 100);
            enemy.Name = "Name";
            Assert.Equal("Name", enemy.Name);
        }
        [Fact]
        public void Enemy_CannotTakeNegativeDamage()
        {
            Enemy enemy = new Enemy("Enemy", 76, 100);
            Assert.Throws<ArgumentException>(() => enemy.TakeDamage(-1));
        }
    }
}
