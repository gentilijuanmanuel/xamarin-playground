using System.Linq;
using Realms;

namespace OfflineFirstPOC.Core.Models
{
    public class Book : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }

        public Book() { }

        public Book(long Id)
        {
            this.Id = Id;
        }

        public static Book Create()
        {
            Book NewBook()
            {
                var q = Realm.GetInstance().All<Book>();
                return new Book(q.Any() ? q.Last().Id + 1 : 0);
            }

            if (Realm.GetInstance().IsInTransaction)
                return NewBook();
            using (var trans = Realm.GetInstance().BeginWrite())
                return NewBook();
        }
    }
}
