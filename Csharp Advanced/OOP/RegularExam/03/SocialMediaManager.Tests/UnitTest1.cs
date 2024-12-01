using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private Influencer influencer;
        private InfluencerRepository influencerRepository;
        [SetUp]
        public void Setup()
        {
            influencer = new Influencer("Sasha", 5);
            influencerRepository = new InfluencerRepository();
        }

        [Test]
        public void Ctor_InfluencerDataSetsCorrectly()
        {
            Assert.IsNotNull(influencer);
            Assert.AreEqual(influencer.Username, "Sasha");
            Assert.AreEqual(influencer.Followers, 5);
        }

        [Test]
        public void RegisterInfluencer_ValidInfluencer_SuccessMessage()
        {

            var repository = new InfluencerRepository();
            var influencer = new Influencer("testUser", 1000);

            var result = repository.RegisterInfluencer(influencer);

            Assert.AreEqual($"Successfully added influencer {influencer.Username} with {influencer.Followers}", result);
        }

        [Test]
        public void RegisterInfluencer_NullInfluencer_ThrowsException()
        {
            var repository = new InfluencerRepository();

            Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(null));
        }

        [Test]
        public void RegisterInfluencer_DuplicateUsername_ThrowsException()
        {

            var repository = new InfluencerRepository();
            var influencer = new Influencer("testUser", 1000);
            repository.RegisterInfluencer(influencer);


            Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencerShouldAddCorrectly()
        {
            var repo=new InfluencerRepository();
            var influ = new Influencer("Ivan", 10);
            repo.RegisterInfluencer(influ);

            Assert.AreEqual(1, repo.Influencers.Count);
        }

        [Test]
        public void RemoveInfluencer_ExistingUsername_ReturnsTrue()
        {
 
            var repository = new InfluencerRepository();
            var influencer = new Influencer("testUser", 1000);
            repository.RegisterInfluencer(influencer);

 
            var result = repository.RemoveInfluencer("testUser");

    
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveInfluencer_NonExistingUsername_ReturnsFalse()
        {
  
            var repository = new InfluencerRepository();


            var result = repository.RemoveInfluencer("nonExistingUser");

  
            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveInfluencer_WithInvalidparameters_Null_ThrowsException()
        {
            var repository = new InfluencerRepository();

            Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(null));
        }

        [Test]
        public void RemoveInfluencer_WithInvalidparameters_WhiteSpace_ThrowsException()
        {
            var repository = new InfluencerRepository();

            Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(" "));
        }
        [Test]
        public void GetInfluencerWithMostFollowers_ReturnsInfluencerWithMostFollowers()
        {
            var repository = new InfluencerRepository();
            var influencer1 = new Influencer("user1", 5000);
            var influencer2 = new Influencer("user2", 7000);
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);

            var result = repository.GetInfluencerWithMostFollowers();

            Assert.AreEqual(influencer2, result);
        }

        [Test]
        public void GetInfluencer_ValidUsername_ReturnsInfluencer()
        {
            var repository = new InfluencerRepository();
            var influencer = new Influencer("testUser", 1000);
            repository.RegisterInfluencer(influencer);

            var result = repository.GetInfluencer("testUser");

            Assert.AreEqual(influencer, result);
        }

        [Test]
        public void GetInfluencer_NonExistingUsername_ReturnsNull()
        {
            var repository = new InfluencerRepository();

            var result = repository.GetInfluencer("nonExistingUser");

            Assert.IsNull(result);
        }

        [Test]
        public void GetInfluens()
        {
            var repo = new InfluencerRepository();
            var result = repo.GetInfluencer("");

            Assert.IsNull(result);
        }
    }
}