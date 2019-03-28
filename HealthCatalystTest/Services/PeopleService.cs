using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCatalystTest.Models;
using HealthCatalystTest.Contracts;


namespace HealthCatalystTest.Services
{
    public class PeopleService : IPeopleService
    {

        private readonly PersonContext _context;

        public PeopleService(PersonContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all interests
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Interest> GetAllInterests()
        {
            var interests = from c in _context.Interests select c;
            return interests;
        }

        /// <summary>
        /// Returns all Interests for a person with the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Interest> GetAllInterestsForPerson(int id)
        {

            var interests = from p in _context.People
                            join rl in _context.PeopleInterestRelation on p.Id equals rl.PeopleID
                            join i in _context.Interests on rl.InterestID equals i.Id
                            where p.Id == id
                            select i;

            return interests;
        }

        /// <summary>
        /// returns all people that have a first name or last name that contains the passed in string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public IEnumerable<Person> GetAllMatchingPeople(string str)
        {
            
            var people = from c in _context.People
                          where c.FirstName.ToUpper().Contains(str.ToUpper()) || c.LastName.ToUpper().Contains(str.ToUpper())
                         select c;
            return people;
        }

       /// <summary>
       /// Returns all people
       /// </summary>
       /// <returns></returns>
        public IEnumerable<Person> GetAllPeople()
        {
            var people = from c in _context.People select c;
            return people;
        }

        /// <summary>
        /// Return the person with the specified ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetPersonById(int id)
        {
            var person = (from c in _context.People where c.Id == id select c).FirstOrDefault();
            return person;
        }



    }

}
