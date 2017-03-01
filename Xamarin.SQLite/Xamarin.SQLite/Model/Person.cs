using System;
using SQLite;

namespace Xamarin.SQLite.Model
{
    [Table("People")]
    public class Person
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public int? Age { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Id, Name);
        }
    }
}
