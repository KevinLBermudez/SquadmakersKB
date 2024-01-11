using Squadmakers.Api.Services;
using Squadmakers.DomainObjects.Entities;
using Squadmakers.DomainObjects.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Squadmakers.Api.Models
{
    public class JokesModel
    {
        private static readonly JokesModel _instance = new JokesModel();

        private JokesModel() { }

        public static JokesModel Instance
        {
            get
            {
                return _instance;
            }
        }

        public Chistes GetJokeRandom()
        {
            SquadmakersdbContext squadmakersdb = new SquadmakersdbContext();
            Random random = new Random();

            var jokesListId = squadmakersdb.Chistes.Where( x => x.Activo == true).Select(x => x.Id).ToList();
            int randomId = random.Next(0, jokesListId.Count);

            var joke = squadmakersdb.Chistes.FirstOrDefault(x => x.Id == jokesListId[randomId]);

            return (Chistes)joke;
        }
        public string GetChuckJoke()
        {
            var joke =  ChucknorrisService.Instance.GetJoke();

            return joke;
        }

        public string GetDadJoke()
        {
            var joke = IcanhazdadjokeService.Instance.GetJoke();

            return joke;
        }

        public string UpdateJoke(Chistes chiste,int number)
        {
            SquadmakersdbContext squadmakersdb = new SquadmakersdbContext();

            var joke = squadmakersdb.Chistes.FirstOrDefault(x => x.Id == number);

            joke.Cuerpo = chiste.Cuerpo;

            squadmakersdb.SaveChanges();

            return "OK";
        }

        public string DeleteJoke(int number)
        {
            SquadmakersdbContext squadmakersdb = new SquadmakersdbContext();

            var joke = squadmakersdb.Chistes.FirstOrDefault(x => x.Id == number);

            joke.Activo = false;

            squadmakersdb.SaveChanges();

            return "OK";
        }

    }
}