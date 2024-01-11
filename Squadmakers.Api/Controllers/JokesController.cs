using Squadmakers.Api.Models;
using Squadmakers.DomainObjects.Entities;
using Squadmakers.DomainObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Squadmakers.Api.Controllers
{
    public class JokesController : ApiController
    {
        // GET: Jokes random
        public Chistes Get()
        {
            var joke = JokesModel.Instance.GetJokeRandom();

            return joke;
        }

        // Get: Jokes/Chuck/Dad
        public string Get(string value)
        {
            var joke = "Error";

            if(value == "Chuck")
            {
                 joke = JokesModel.Instance.GetChuckJoke();

            }
            else if(value == "Dad")
            {
                 joke = JokesModel.Instance.GetDadJoke();
            }

            return joke;
        }

        // PUT : Jokes/5
        public string Put([FromBody] Chistes chiste, int number) 
        {
            var joke = "Error";
               
            if(chiste != null)
            {
                joke = JokesModel.Instance.UpdateJoke(chiste,number);
            }

            return joke;
        }

        // DELETE : Jokes/5
        public string Delete(int number)
        {
            var joke = "Error";

            if(number != 0)
            {
                joke = JokesModel.Instance.DeleteJoke(number);
            }

            return joke;
        }

    }
}