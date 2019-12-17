﻿using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Model_Classes;

namespace Services
{
    public interface IHighLevelSoccerManagerService
    {
        int CreateTeam(Team team);
        void UpdateTeam(int teamId, Team updatedTeam);
        void RemoveTeam(int teamId);
        void RemoveTeamFromTournament(int teamId, int tournamentId);
        bool AddTeamToTournament(int teamId, int tournamentId);
        Team GetTeam(int teamId);
        IEnumerable<Team> GetAllTeam();
        IEnumerable<Tournament> GetAllTournaments();

        int CreateTournament(Tournament tournament);
        void UpdateTournament(int tournamentId, Tournament updatedTournament);
        void RemoveTournament(int tournamentId);
        Tournament GetTournament(int id);
    }

    public class HighLevelSoccerManagerService : IHighLevelSoccerManagerService
    {
        private readonly IRepository<Tournament> _tournamentRepository;
        private readonly IRepository<Team> _teamRepository;

        public HighLevelSoccerManagerService(IRepository<Tournament> tournamentRepository, IRepository<Team> teamRepository)
        {
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
        }


        public int CreateTeam(Team team)
        {
            return _teamRepository.Add(team);
        }

        public int CreateTournament(Tournament tournament)
        {
            return _tournamentRepository.Add(tournament);
        }

        public IEnumerable<Team> GetAllTeam()
        {
            var lst = _teamRepository.GetAll();

            foreach (Team team in lst)
            {
                RecalculateAge(team.Players);
            }

            return lst;
        }

        public Team GetTeam(int teamId)
        {
            var team = _teamRepository.Get(teamId);
            if(team != null) { RecalculateAge(team.Players);}

            return team;
        }

        public void RemoveTeam(int teamId)
        {
            _teamRepository.Delete(team => team.TeamId == teamId);
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            return _tournamentRepository.GetAll();
        }

        public Tournament GetTournament(int id)
        {
            return _tournamentRepository.Get(id);
        }

        public void RemoveTournament(int tournamentId)
        {
            var t = _tournamentRepository.Get(tournamentId);
            _tournamentRepository.Delete(t);
        }

        public void UpdateTeam(int teamId, Team updatedTeam)
        {
            var teamFromDb = _teamRepository.Get(team => team.TeamId == teamId);

            teamFromDb.Name = updatedTeam.Name;
            teamFromDb.Mail = updatedTeam.Mail;
            teamFromDb.DataCreation = updatedTeam.DataCreation;
            teamFromDb.Avatar = updatedTeam.Avatar==null ? teamFromDb.Avatar : updatedTeam.Avatar;

            _teamRepository.Update(teamFromDb);
        }

        public void UpdateTournament(int tournamentId, Tournament updatedTournament)
        {
            var tournamentFromDb = _tournamentRepository.Get(t => t.TournamentId == tournamentId);

            tournamentFromDb.Name = updatedTournament.Name;
            tournamentFromDb.MaxCountTeams = updatedTournament.MaxCountTeams;
            tournamentFromDb.StartDate = updatedTournament.StartDate;
            tournamentFromDb.EndDate = updatedTournament.EndDate;
            tournamentFromDb.Mail = updatedTournament.Mail;

            _tournamentRepository.Update(tournamentFromDb);
        }

        public void RemoveTeamFromTournament(int teamId, int tournamentId)
        {
            var tournamentFromDb = _tournamentRepository.Get(t => t.TournamentId == tournamentId);
            tournamentFromDb.TeamTournaments.RemoveAll(tt => tt.TournamentId == teamId);

            _tournamentRepository.Update(tournamentFromDb);

        }

        public bool AddTeamToTournament(int teamId, int tournamentId)
        {
            var tournamentFromDb = _tournamentRepository.Get(t => t.TournamentId == tournamentId);
            var teamFromDb = _teamRepository.Get(t => t.TeamId == teamId);

            if (teamFromDb.TeamTournaments.Find(tt => { return tt.TeamId == tournamentId && tt.TournamentId == teamId; }) != null)
            {
                return false;
            }

            _tournamentRepository.AddTeamTournaments(teamFromDb, tournamentFromDb);
            return true;
        }

        public static void RecalculateAge(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.Age_ = Age(player.Born);
            }
        }

        private static int Age(DateTime date)
        {
            return DateTime.Now.Year - date.Year;
        }
    }

}
