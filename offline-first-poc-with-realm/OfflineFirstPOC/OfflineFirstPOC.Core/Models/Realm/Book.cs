using System;
using System.Linq;
using Realms;
using Realms.Sync;

namespace OfflineFirstPOC.Core.Models
{
    public class Book : RealmObject
    {
        [PrimaryKey]
        [MapTo("id")]
        public long Id { get; set; }

        [MapTo("title")]
        public string Title { get; set; }

        [MapTo("description")]
        public string Description { get; set; }

        [MapTo("pageCount")]
        public int PageCount { get; set; }

        public Book() { }

        public Book(long Id)
        {
            this.Id = Id;
        }

        public static Book Create()
        {
            var user = User.Current;
            if (user != null)
            {
                var configuration = new FullSyncConfiguration(new Uri(Constants.RealmPath, UriKind.Relative), user);

                Book NewBook()
                {
                    var q = Realm.GetInstance(configuration).All<Book>();
                    return new Book(q.Any() ? q.Last().Id + 1 : 0);
                }

                if (Realm.GetInstance(configuration).IsInTransaction)
                    return NewBook();
                using (var trans = Realm.GetInstance(configuration).BeginWrite())
                    return NewBook();
            }

            return null;
        }
    }
}
