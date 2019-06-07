using System;
using System.Threading.Tasks;
using Realms;
using Realms.Server;
using Realms.Sync;

namespace OfflineFirstPOCAPI
{
    class Program
    {
        private const string AdminUsername = "JuanManuel";
        private const string AdminPassword = "juanma132";
        private const string ServerUrl = "127.0.0.1:9080";

        public static void Main(string[] args) => MainAsync().Wait();

        public static async Task MainAsync()
        {
            // Login the admin user
            var credentials = Credentials.UsernamePassword(AdminUsername, AdminPassword, createUser: false);
            var admin = await User.LoginAsync(credentials, new Uri($"http://{ServerUrl}"));

            var config = new NotifierConfiguration(admin)
            {
                // Add all handlers that this notifier will invoke
                Handlers = { new CouponHandler() }
            };

            // Start the notifier. Your handlers will be invoked for as
            // long as the notifier is not disposed.
            using (var notifier = await Notifier.StartAsync(config))
            {
                do
                {
                    Console.WriteLine("Type in 'exit' to quit the app.");
                }
                while (Console.ReadLine() != "exit");
            }
        }

        class CouponHandler : RegexNotificationHandler
        {
            // The regular expression you provide restricts the observed Realm files
            // to only the subset you are actually interested in. This is done to 
            // avoid the cost of computing the fine-grained change set if it's not
            // necessary.
            public CouponHandler() : base("")
            {
            }

            // The HandleChangeAsync method is called for every observed Realm file 
            // whenever it has changes. It is called with a change event which contains 
            // a version of the Realm from before and after the change, as well as
            // collections of all objects which were added, deleted, or modified in this change
            public override async Task HandleChangeAsync(IChangeDetails details)
            {
                Console.WriteLine("I'm listening!!!!!!!");

                //TODO: add this code 
                //if (details.TryGetValue("Coupon", out var changeSetDetails) &&
                //    changeSetDetails.Insertions.Length > 0)
                //{
                //    // Extract the user ID from the virtual path, assuming that we're using
                //    // a filter which only subscribes us to updates of user-scoped Realms.
                //    var userId = details.RealmPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0];

                //    using (var realm = details.GetRealmForWriting())
                //    {
                //        foreach (var coupon in changeSetDetails.Insertions.Select(c => c.CurrentObject))
                //        {
                //            var isValid = await CouponVerifier.VerifyAsync(coupon, userId);

                //            // Create a ThreadSafeReference of the coupon. While both
                //            // details.CurrentRealm and details.GetRealmForWriting() are open 
                //            // on the same thread, they are at different versions, so you need
                //            // to pass the Coupon between them either via ThreadSafeReference
                //            // or by its PrimaryKey.
                //            var writeableCoupon = realm.ResolveReference(ThreadSafeReference.Create(coupon));

                //            // It may be null if the coupon was deleted by the time we get here
                //            if (writeableCoupon != null)
                //            {
                //                realm.Write(() => writeableCoupon.IsValid = isValid);
                //            }
                //        }
                //    }
                //}
            }
        }
    }
}
