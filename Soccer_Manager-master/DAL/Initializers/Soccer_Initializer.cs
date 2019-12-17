using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model_Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Initializers
{
    public static class Soccer_Initializer
    {
        public static void Initialize(SoccerContext context)
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

            

            messi.Born = new DateTime(1987, 6, 24);
            busquets.Born = new DateTime(1988, 7, 16);
            suarez.Born = new DateTime(1987, 1, 24);
            mane.Born = new DateTime(1992, 4, 10);
            salah.Born = new DateTime(1992, 6, 15);
            firmino.Born = new DateTime(2005, 5, 5);
            aubameyang.Born = new DateTime(1989, 6, 18);
            leno.Born = new DateTime(1992, 3, 4);
            bellerin.Born = new DateTime(1995, 3, 19);


            context.Players.AttachRange(
                new List<Player> { messi, busquets, suarez, mane, salah, firmino, aubameyang, leno, bellerin });
            context.SaveChanges();


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

            context.Add(EPL);
            context.Add(EPL);
            context.SaveChanges();
            context.Add(someCup);
            context.SaveChanges();


            EPL.TeamTournaments.Add(new TeamTournament { Tournament = EPL, Team = liverpool });
            EPL.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = EPL });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = FACUP });
            FACUP.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = FACUP });
            someCup.TeamTournaments.Add(new TeamTournament { Team = liverpool, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = arsenal, Tournament = someCup });
            someCup.TeamTournaments.Add(new TeamTournament { Team = barcelona, Tournament = someCup });

            context.SaveChanges();

        }
    }
}
