using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCatalystTest.Models;


namespace HealthCatalystTest.Contracts
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int id);
        IEnumerable<Person> GetAllMatchingPeople(string str);
        IEnumerable<Interest> GetAllInterests();
        IEnumerable<Interest> GetAllInterestsForPerson(int id);      
    }
}

