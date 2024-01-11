using Squadmakers.Api.Models;
using Squadmakers.DomainObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Squadmakers.Api.Controllers
{
    public class MathematicsController : ApiController
    {
        // GET: Mathematics
        public int Get(string numbers)
        {

            string newString = numbers.Trim(new char[] { '{', '}', '[', ']' });
            List<int> numberList = newString.Split(',').Select(int.Parse).ToList();

            int number = MathematicsModel.Instance.GetCommonMultiple(numberList);

            return number;
        }

        public int Get(int number)
        {
            return MathematicsModel.Instance.SumNumber(number);
        }
    }
}