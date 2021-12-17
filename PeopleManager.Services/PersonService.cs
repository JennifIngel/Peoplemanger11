using System.Collections.Generic;
using System.Linq;
using PeopleManager.Core;
using PeopleManager.Model;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private readonly PeopleManagerDbContext _dbContext;

        public PersonService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person Get(int id)
        {
            return _dbContext.People
                .SingleOrDefault(p => p.Id == id);
        }

        public IList<Person> Find()
        {
            return _dbContext.People
                .ToList();
        }

        public Person Create(Person person)
        {
            _dbContext.People.Add(person);

            _dbContext.SaveChanges();

            return person;
        }

        public Person Update(int id, Person person)
        {
            var dbPerson = _dbContext.People.SingleOrDefault(p => p.Id == id);

            if (dbPerson is null)
            {
                return null;
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;

            _dbContext.SaveChanges();

            return dbPerson;
        }

        public bool Delete(int id)
        {
            var person = _dbContext.People.SingleOrDefault(p => p.Id == id);
            if (person is null)
            {
                return false;
            }

            _dbContext.People.Remove(person);

            _dbContext.SaveChanges();

            return true;
        }
        
    }
}
