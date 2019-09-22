using Data.Repositories;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TennisPlayersStats.Controllers;

namespace TennisPlayersStats.Tests.Controllers
{
   [TestClass]
    public class TennisPlayersControllerTest
    {
        ITennisPlayerRepository repo = new TennisPlayersRepository();
        private readonly int existPlayerId = 52;
        private readonly int notExistPlayerId = 2;
        private readonly List<Player> players = (List<Player>)Commun.Helpers.JsonReaderHelper<PlayerCollection>.GetSerializedJsonFromUrl().Players;

        [TestMethod]
        public void Test_GetPlayerByIdReturnPlayerWithTheSameId()
        {
            // Arrange
            TennisPlayerController controller = new TennisPlayerController(repo);
            Player existedPlayer = players.Find(p => p.Id == existPlayerId);
            // Act
            IHttpActionResult actionResult = controller.Player(existPlayerId);
            OkNegotiatedContentResult<Player> contectResult = actionResult as OkNegotiatedContentResult<Player>;
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(contectResult);
            Assert.IsNotNull(contectResult.Content);
            Assert.AreEqual(existPlayerId, contectResult.Content.Id);
            Assert.AreEqual(contectResult.Content.Id, existedPlayer.Id);
            Assert.AreEqual(contectResult.Content.FirstName, existedPlayer.FirstName);
            Assert.AreEqual(contectResult.Content.LastName, existedPlayer.LastName);
            Assert.AreEqual(contectResult.Content.ShortName, existedPlayer.ShortName);
            Assert.AreEqual(contectResult.Content.Picture, existedPlayer.Picture);
            Assert.AreEqual(contectResult.Content.Sex, existedPlayer.Sex);
            Assert.AreEqual(contectResult.Content.Country.Code, existedPlayer.Country.Code);
            Assert.AreEqual(contectResult.Content.Country.Picture, existedPlayer.Country.Picture);
            Assert.AreEqual(contectResult.Content.Data.Rank, existedPlayer.Data.Rank);
            Assert.AreEqual(contectResult.Content.Data.Height, existedPlayer.Data.Height);
            Assert.AreEqual(contectResult.Content.Data.Last.Length, existedPlayer.Data.Last.Length);
            Assert.AreEqual(contectResult.Content.Data.Points, existedPlayer.Data.Points);
            Assert.AreEqual(contectResult.Content.Data.Weight, existedPlayer.Data.Weight);
            Assert.AreEqual(contectResult.Content.Data.Age, existedPlayer.Data.Age);

        }
        [TestMethod]
        public void Test_GetPlayerByIdReturnNotFound()
        {
            // Arrange
            TennisPlayerController controller = new TennisPlayerController(repo);
            // Act
            IHttpActionResult actionResult = controller.Player(notExistPlayerId);
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void Test_GetAllPlayers()
        {
            // Arrange
            TennisPlayerController controller = new TennisPlayerController(repo);
            // Act
            IHttpActionResult actionResult = controller.Players();
            OkNegotiatedContentResult<List<Player>> contectResult = actionResult as OkNegotiatedContentResult<List<Player>>;
            //Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(contectResult);
            Assert.IsNotNull(contectResult.Content);
            Assert.AreEqual(contectResult.Content.Count, players.Count);
            foreach (Player ply in contectResult.Content)
            {
                Player currentPlayer = players.Find(p => p.Id == ply.Id);
                if (currentPlayer != null)
                {
                    Assert.AreEqual(currentPlayer.Id, ply.Id);
                    Assert.AreEqual(currentPlayer.FirstName, ply.FirstName);
                    Assert.AreEqual(currentPlayer.LastName, ply.LastName);
                    Assert.AreEqual(currentPlayer.ShortName, ply.ShortName);
                    Assert.AreEqual(currentPlayer.Picture, ply.Picture);
                    Assert.AreEqual(currentPlayer.Sex, ply.Sex);
                    Assert.AreEqual(currentPlayer.Country.Code, ply.Country.Code);
                    Assert.AreEqual(currentPlayer.Country.Picture, ply.Country.Picture);
                    Assert.AreEqual(currentPlayer.Data.Rank, ply.Data.Rank);
                    Assert.AreEqual(currentPlayer.Data.Height, ply.Data.Height);
                    Assert.AreEqual(currentPlayer.Data.Last.Length, ply.Data.Last.Length);
                    Assert.AreEqual(currentPlayer.Data.Points, ply.Data.Points);
                    Assert.AreEqual(currentPlayer.Data.Weight, ply.Data.Weight);
                    Assert.AreEqual(currentPlayer.Data.Age, ply.Data.Age);
                }
            }
        }

        [TestMethod]
        public void Test_DeletePlayerByIdReturnOk()
        {
            // Arrange
            TennisPlayerController controller = new TennisPlayerController(repo);
            // Act
            IHttpActionResult actionResult = controller.Delete(existPlayerId);
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
        [TestMethod]
        public void Test_DeletePlayerByIdReturnNotFound()
        {
            // Arrange
            TennisPlayerController controller = new TennisPlayerController(repo);
            // Act
            IHttpActionResult actionResult = controller.Delete(notExistPlayerId);
            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
