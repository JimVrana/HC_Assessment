using System;
using System.Collections.Generic;
using System.Text;
using HealthCatalystTest.Contracts;
using HealthCatalystTest.Models;
using System.Linq;

namespace PeopleAPItests
{
    class PeopleServiceFake : IPeopleService
    {
        private readonly List<Person> _people;
        private readonly List<Interest> _interests;
        private readonly List<PeopleInterestRelation> _relations;

        public PeopleServiceFake()
        {
            _people = new List<Person>()
            {
                new Person(){Id = 1, FirstName= "Dipper", LastName = "Pines", Age=12,
                    Street ="1 Mystery Shack Way", City = "Gravity Falls", State = "OR", Zip = "97009", ImageFileName="Dipper.jpg"},
                new Person(){Id = 2, FirstName= "Mabel", LastName = "Pines", Age=12,
                    Street = "1 Mystery Shack Way", City = "Gravity Falls", State = "OR", Zip = "97009", ImageFileName="Mabel.jpg"},
                new Person(){Id = 3, FirstName= "Grunkle Stan", LastName = "Pines", Age=70,
                   Street = "1 Mystery Shack Way", City = "Gravity Falls", State = "OR", Zip = "97009", ImageFileName="Grunkle.jpg"},
                new Person(){Id = 4, FirstName= "Soos", LastName = "Ramírez ", Age=26,
                    Street = "45 Main street", City = "Gravity Falls", State = "OR", Zip = "97009", ImageFileName="Soos.jpg"}
            };
            _interests = new List<Interest>()
            {
                new Interest(){Id=1, interest ="interest 1"},
                new Interest(){Id=2, interest ="interest 2"},
                new Interest(){Id=3, interest ="interest 3"},
                new Interest(){Id=4, interest ="interest 4"},
                new Interest(){Id=5, interest ="interest 5"}
            };

            _relations = new List<PeopleInterestRelation>()
            {
                new PeopleInterestRelation(){Id=1,InterestID = 1, PeopleID = 1},
                new PeopleInterestRelation(){Id=2,InterestID = 2, PeopleID = 1},
                new PeopleInterestRelation(){Id=3,InterestID = 3, PeopleID = 1},
                new PeopleInterestRelation(){Id=4,InterestID = 4, PeopleID = 2},
                new PeopleInterestRelation(){Id=5,InterestID = 5, PeopleID = 2},
                new PeopleInterestRelation(){Id=6,InterestID = 1, PeopleID = 3}
            };
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _people;
        }


        public IEnumerable<Interest> GetAllInterests()
        {
            return _interests;
        }

        public IEnumerable<Interest> GetAllInterestsForPerson(int id)
        {
            var interests = (from p in _people
                            join rl in _relations on p.Id equals rl.PeopleID
                            join i in _interests on rl.InterestID equals i.Id
                            where p.Id == id
                            select i).ToList();
            return interests;
        }

        
        public IEnumerable<PeopleInterestRelation> GetAllRelations()
        {
            return _relations;
        }

        public Person GetPersonById(int id)
        {
            return _people.Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Person> GetAllMatchingPeople(string str)
        {
            var people = from c in _people
                         where c.FirstName.ToUpper().Contains(str.ToUpper()) || c.LastName.ToUpper().Contains(str.ToUpper())
                         select c;
            return people;
        }
    }
}
