using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class PlayerTests2
    {
        Player player;
        Image healthBar;

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("TestArena");
            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ReceiveBodyShotTest()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
            player.Awake();
            float initialHealthAmount = healthBar.fillAmount;
            var projectileObj = new Projectile();
            player.TakeHit(projectileObj, HitType.Body);
            float currentHealthAmount = healthBar.fillAmount;
            Assert.AreEqual(0.9f, currentHealthAmount, "Health should be decreased by 10%");
            yield return null;
        }

        //[UnityTest]
        //public IEnumerator ReceiveHeadShotTest()
        //{
        //    float initialHealthAmount = healthBar.fillAmount;
        //    var projectileObj = new Projectile();
        //    player.TakeHit(projectileObj, HitType.Head);
        //    float currentHealthAmount = healthBar.fillAmount;
        //    Assert.AreEqual(0.7f, currentHealthAmount, "Health should be decreased by 30%");
        //    yield return null; 
        //}
    }
}
