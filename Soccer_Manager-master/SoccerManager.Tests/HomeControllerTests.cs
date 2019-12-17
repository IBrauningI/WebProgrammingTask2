using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using Xunit;
using Services;
using Moq;
using System.Collections.Generic;
using DAL.Model_Classes;
using WebApplication1.Models.ViewModels;
using System.Linq;
using WebApplication1.Models;

//Fact - test

namespace SoccerManager.Tests
{
    public class HomeControllerTests
    {
        private IEnumerable<Player> GetTestPlayers()
        {
            Team barcelona = new Team("Barcelona");
            barcelona.Password = "Barcelona_1";
            barcelona.Mail = "barcelona@gmail.com";
            Team liverpool = new Team("Liverpool");
            liverpool.Password = "Liverpool_1";
            liverpool.Mail = "liverpool@gmail.com";
            Team arsenal = new Team("Arsenal");
            arsenal.Password = "Arsenal_1";
            arsenal.Mail = "arsenal@gmail.com";

            Player messi = new Player("Lionel", "Messi", "RW") { Team = barcelona };
            Player busquets = new Player("Sergio", "Busquets", "CDM") { Team = barcelona };
            Player suarez = new Player("Luis", "Suarez", "ST") { Team = barcelona };
            Player mane = new Player("Sadio", "Mane", "LW") { Team = liverpool };
            Player salah = new Player("Mohamed", "Salah", "RW") { Team = liverpool };
            Player firmino = new Player("Roberto", "Firmino", "ST") { Team = liverpool };
            Player aubameyang = new Player("Pierre-Emerick", "Aubameyang", "ST") { Team = arsenal };
            Player leno = new Player("Bernd", "Leno", "GK") { Team = arsenal };
            Player bellerin = new Player("Hector", "Bellerin", "RB") { Team = arsenal };

            Tournament EPL = new Tournament();
            EPL.Name = "EPL";
            EPL.MaxCountTeams = 20;
            EPL.StartDate = "15.08.2019";
            EPL.EndDate = "22.05.2020";
            EPL.Password = "English_1";
            EPL.Mail = "englishLeague@gmail.com";
            Tournament FACUP = new Tournament();
            FACUP.Name = "FACUP";
            FACUP.MaxCountTeams = 20;
            FACUP.StartDate = "01.09.2019";
            FACUP.EndDate = "05.03.2020";
            FACUP.Password = "Facup_1";
            FACUP.Mail = "facup@gmail.com";
            Tournament someCup = new Tournament();
            someCup.Name = "Some";
            someCup.MaxCountTeams = 30;
            someCup.StartDate = "02.08.2019";
            someCup.EndDate = "05.05.2020";
            someCup.Password = "Some_1";
            someCup.Mail = "some_cup@gmail.com";

            EPL.TeamTournaments.Add(new TeamTournament { Tournament = EPL, Team = liverpool });
            EPL.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = EPL });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = FACUP });
            someCup.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = someCup });

            var players = new List<Player>
            {
                messi, busquets, suarez, mane, salah, firmino, aubameyang, leno, bellerin
            };
            return players;
        }
        private IEnumerable<Team> GetTestTeams()
        {
            Team barcelona = new Team("Barcelona");
            barcelona.Password = "Barcelona_1";
            barcelona.Mail = "barcelona@gmail.com";
            Team liverpool = new Team("Liverpool");
            liverpool.Password = "Liverpool_1";
            liverpool.Mail = "liverpool@gmail.com";
            Team arsenal = new Team("Arsenal");
            arsenal.Password = "Arsenal_1";
            arsenal.Mail = "arsenal@gmail.com";

            Player messi = new Player("Lionel", "Messi", "RW") { Team = barcelona };
            Player busquets = new Player("Sergio", "Busquets", "CDM") { Team = barcelona };
            Player suarez = new Player("Luis", "Suarez", "ST") { Team = barcelona };
            Player mane = new Player("Sadio", "Mane", "LW") { Team = liverpool };
            Player salah = new Player("Mohamed", "Salah", "RW") { Team = liverpool };
            Player firmino = new Player("Roberto", "Firmino", "ST") { Team = liverpool };
            Player aubameyang = new Player("Pierre-Emerick", "Aubameyang", "ST") { Team = arsenal };
            Player leno = new Player("Bernd", "Leno", "GK") { Team = arsenal };
            Player bellerin = new Player("Hector", "Bellerin", "RB") { Team = arsenal };

            Tournament EPL = new Tournament();
            EPL.Name = "EPL";
            EPL.MaxCountTeams = 20;
            EPL.StartDate = "15.08.2019";
            EPL.EndDate = "22.05.2020";
            EPL.Password = "English_1";
            EPL.Mail = "englishLeague@gmail.com";
            Tournament FACUP = new Tournament();
            FACUP.Name = "FACUP";
            FACUP.MaxCountTeams = 20;
            FACUP.StartDate = "01.09.2019";
            FACUP.EndDate = "05.03.2020";
            FACUP.Password = "Facup_1";
            FACUP.Mail = "facup@gmail.com";
            Tournament someCup = new Tournament();
            someCup.Name = "Some";
            someCup.MaxCountTeams = 30;
            someCup.StartDate = "02.08.2019";
            someCup.EndDate = "05.05.2020";
            someCup.Password = "Some_1";
            someCup.Mail = "some_cup@gmail.com";

            EPL.TeamTournaments.Add(new TeamTournament { Tournament = EPL, Team = liverpool });
            EPL.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = EPL });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = FACUP });
            someCup.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = someCup });

            var teams = new List<Team>
            {
                barcelona, liverpool, arsenal
            };
            return teams;
        }
        private IEnumerable<Tournament> GetTestCups()
        {
            Team barcelona = new Team("Barcelona");
            barcelona.Password = "Barcelona_1";
            barcelona.Mail = "barcelona@gmail.com";
            Team liverpool = new Team("Liverpool");
            liverpool.Password = "Liverpool_1";
            liverpool.Mail = "liverpool@gmail.com";
            Team arsenal = new Team("Arsenal");
            arsenal.Password = "Arsenal_1";
            arsenal.Mail = "arsenal@gmail.com";

            Player messi = new Player("Lionel", "Messi", "RW") { Team = barcelona };
            Player busquets = new Player("Sergio", "Busquets", "CDM") { Team = barcelona };
            Player suarez = new Player("Luis", "Suarez", "ST") { Team = barcelona };
            Player mane = new Player("Sadio", "Mane", "LW") { Team = liverpool };
            Player salah = new Player("Mohamed", "Salah", "RW") { Team = liverpool };
            Player firmino = new Player("Roberto", "Firmino", "ST") { Team = liverpool };
            Player aubameyang = new Player("Pierre-Emerick", "Aubameyang", "ST") { Team = arsenal };
            Player leno = new Player("Bernd", "Leno", "GK") { Team = arsenal };
            Player bellerin = new Player("Hector", "Bellerin", "RB") { Team = arsenal };

            Tournament EPL = new Tournament();
            EPL.Name = "EPL";
            EPL.MaxCountTeams = 20;
            EPL.StartDate = "15.08.2019";
            EPL.EndDate = "22.05.2020";
            EPL.Password = "English_1";
            EPL.Mail = "englishLeague@gmail.com";
            Tournament FACUP = new Tournament();
            FACUP.Name = "FACUP";
            FACUP.MaxCountTeams = 20;
            FACUP.StartDate = "01.09.2019";
            FACUP.EndDate = "05.03.2020";
            FACUP.Password = "Facup_1";
            FACUP.Mail = "facup@gmail.com";
            Tournament someCup = new Tournament();
            someCup.Name = "Some";
            someCup.MaxCountTeams = 30;
            someCup.StartDate = "02.08.2019";
            someCup.EndDate = "05.05.2020";
            someCup.Password = "Some_1";
            someCup.Mail = "some_cup@gmail.com";

            EPL.TeamTournaments.Add(new TeamTournament { Tournament = EPL, Team = liverpool });
            EPL.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = EPL });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = FACUP });
            someCup.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = someCup });

            var cups = new List<Tournament>
            {
                EPL, FACUP, someCup
            };
            return cups;
        }

        [Fact]
        public void IndexReturnsAViewResultWithALists()
        {
            // Arrange
            var moqLowService = new Mock<ILowLevelSoccerManagmentService>();
            var moqHighService = new Mock<IHighLevelSoccerManagerService>();

            moqLowService.Setup(service => service.GetAllPlayers()).Returns(GetTestPlayers());
            moqHighService.Setup(service => service.GetAllTeam()).Returns(GetTestTeams());
            moqHighService.Setup(service => service.GetAllTournaments()).Returns(GetTestCups());

            HomeController controller = new HomeController(moqHighService.Object, moqLowService.Object);

            // Act
            var result1 = controller.Index("asff");
            var result = controller.Index("");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GeneralInfo>(viewResult.Model);
            Assert.Equal(GetTestPlayers().ToList().Count, model.Players.Count);
            Assert.Equal(GetTestTeams().ToList().Count, model.Teams.Count);
            Assert.Equal(GetTestCups().ToList().Count, model.Tournaments.Count);
            var viewResult1 = Assert.IsType<ViewResult>(result1);
            var model1 = Assert.IsAssignableFrom<GeneralInfo>(viewResult1.Model);
            Assert.Empty(model.Teams.Where(el => el.Name.Contains("asff")));
        }

        private Tournament TestGetCup(int id)
        {
            Tournament EPL = new Tournament();
            EPL.TournamentId = 1;
            EPL.Name = "EPL";
            EPL.MaxCountTeams = 20;
            EPL.StartDate = "15.08.2019";
            EPL.EndDate = "22.05.2020";
            EPL.Password = "English_1";
            EPL.Mail = "englishLeague@gmail.com";
            Tournament FACUP = new Tournament();
            FACUP.TournamentId = 2;
            FACUP.Name = "FACUP";
            FACUP.MaxCountTeams = 20;
            FACUP.StartDate = "01.09.2019";
            FACUP.EndDate = "05.03.2020";
            FACUP.Password = "Facup_1";
            FACUP.Mail = "facup@gmail.com";
            Tournament someCup = new Tournament();
            someCup.TournamentId = 3;
            someCup.Name = "Some";
            someCup.MaxCountTeams = 30;
            someCup.StartDate = "02.08.2019";
            someCup.EndDate = "05.05.2020";
            someCup.Password = "some";
            someCup.Mail = "some_cup@gmail.com";


            switch (id)
            {
                case 1: return EPL;
                case 2: return FACUP;
                case 3: return someCup;
                default: return null;
            }
        }
        [Fact]
        public void CupReturnCorrectCup()
        {
            // Arrange
            var moqLowService = new Mock<ILowLevelSoccerManagmentService>();
            var moqHighService = new Mock<IHighLevelSoccerManagerService>();

            moqHighService.Setup(service => service.GetTournament(It.IsAny<int>())).Returns<int>(id => TestGetCup(id));

            HomeController controller = new HomeController(moqHighService.Object, moqLowService.Object);

            // Act_1
            var result1 = controller.Cup(1);
            // Assert_1
            var viewResult1 = Assert.IsType<ViewResult>(result1);
            var model1 = Assert.IsAssignableFrom<Tournament>(viewResult1.Model);
            Assert.Equal(TestGetCup(1).TournamentId, model1.TournamentId);

            // Act_2
            var result2 = controller.Cup(2);
            // Assert_2
            var viewResult2 = Assert.IsType<ViewResult>(result2);
            var model2 = Assert.IsAssignableFrom<Tournament>(viewResult2.Model);
            Assert.Equal(TestGetCup(2).TournamentId, model2.TournamentId);

            // Act_4
            var result4 = controller.Cup(4);
            // Assert_4
            var viewResult4 = Assert.IsType<ViewResult>(result4);
            Assert.Null(viewResult4.Model);
        }

        private Team TestGetTeam(int id)
        {
            Team t1 = new Team();
            t1.TeamId = 1;
            t1.Name = "T1";
            Team t2 = new Team();
            t2.TeamId = 2;
            t2.Name = "T2";
            Team t3 = new Team();
            t3.TeamId = 3;
            t3.Name = "T3";


            switch (id)
            {
                case 1: return t1;
                case 2: return t2;
                case 3: return t3;
                default: return null;
            }
        }
        [Fact]
        public void TeamReturnCorrectTeam()
        {
            // Arrange
            var moqLowService = new Mock<ILowLevelSoccerManagmentService>();
            var moqHighService = new Mock<IHighLevelSoccerManagerService>();

            moqHighService.Setup(service => service.GetTeam(It.IsAny<int>())).Returns<int>(id => TestGetTeam(id));

            HomeController controller = new HomeController(moqHighService.Object, moqLowService.Object);

            // Act_1
            var result1 = controller.Team(1);
            // Assert_1
            var viewResult1 = Assert.IsType<ViewResult>(result1);
            var model1 = Assert.IsAssignableFrom<Team>(viewResult1.Model);
            Assert.Equal(TestGetTeam(1).TeamId, model1.TeamId);

            // Act_2
            var result2 = controller.Team(2);
            // Assert_2
            var viewResult2 = Assert.IsType<ViewResult>(result2);
            var model2 = Assert.IsAssignableFrom<Team>(viewResult2.Model);
            Assert.Equal(TestGetTeam(2).TeamId, model2.TeamId);

            // Act_4
            var result4 = controller.Team(4);
            // Assert_4
            var viewResult4 = Assert.IsType<ViewResult>(result4);
            Assert.Null(viewResult4.Model);
        }

        [Fact]
        public void AboutCorrectViewModel()
        {
            //Arrange
            var moqLowService = new Mock<ILowLevelSoccerManagmentService>();
            var moqHighService = new Mock<IHighLevelSoccerManagerService>();

            HomeController controller = new HomeController(moqHighService.Object, moqLowService.Object);

            //Action
            ViewResult result = controller.About() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Your application description page.", result?.ViewData["Message"]);
        }

        [Fact]
        public void ContactCorrectViewModel()
        {
            //Arrange
            var moqLowService = new Mock<ILowLevelSoccerManagmentService>();
            var moqHighService = new Mock<IHighLevelSoccerManagerService>();

            HomeController controller = new HomeController(moqHighService.Object, moqLowService.Object);

            //Action
            ViewResult result = controller.Contact() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Your contact page.", result?.ViewData["Message"]);
        }

        [Fact]
        public void ErrotTest()
        {
            //Arrange
            var moqLowService = new Mock<ILowLevelSoccerManagmentService>();
            var moqHighService = new Mock<IHighLevelSoccerManagerService>();

            HomeController controller = new HomeController(moqHighService.Object, moqLowService.Object);

            //Action
            ViewResult result = controller.Error() as ViewResult;

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
