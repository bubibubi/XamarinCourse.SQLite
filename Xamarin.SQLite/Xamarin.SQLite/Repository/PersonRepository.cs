using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.SQLite.Model;

namespace Xamarin.SQLite.Repository
{
    class PersonRepository : IDisposable
    {
        private readonly SQLiteConnection _connection;

        public PersonRepository()
        {
            _connection = ConnectionFatory.CreateConnection();
            _connection.CreateTable<Person>();
        }

        public void Insert(Person entity)
        {
            _connection.Insert(entity);
        }

        public void Update(Person entity)
        {
            _connection.Update(entity);
        }

        public void Delete(int id)
        {
            _connection.Delete<Person>(id);
        }

        public Person Get(int id)
        {
            return _connection.Get<Person>(id);
        }

        public List<Person> GetAll()
        {
            return _connection.Table<Person>().ToList();
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
