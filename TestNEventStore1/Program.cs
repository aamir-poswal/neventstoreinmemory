using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNEventStore1
{
    class Program
    {
        //private static  Guid StreamId = new Guid("A66AB9C53DAB27B53E15A46CA064DDAF1B33A655"); // aggregate identifier
        private static IStoreEvents store;
        static void Main(string[] args)
        {
            try
            {
                using (store = WireupEventStore())
                {
                    OpenStream();
                }

                Console.WriteLine("test");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
        private static IStoreEvents WireupEventStore()
        {
            //return Wireup.Init()
            //             .LogToOutputWindow()
            //             .UsingInMemoryPersistence()
            //             .UsingSqlPersistence("EventStore") // Connection string is in app.config
            //             .WithDialect(new MsSqlDialect())
            //             .EnlistInAmbientTransaction() // two-phase commit
            //             .InitializeStorageEngine()
            //             .TrackPerformanceInstance("example")
            //             .UsingJsonSerialization()
            //             .Compress()
            //             .EncryptWith(EncryptionKey)
            //             .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
            //             .UsingSynchronousDispatchScheduler()
            //             .DispatchTo(new DelegateMessageDispatcher(DispatchCommit))
            //             .Build();
            return Wireup.Init()
                    .LogToOutputWindow()
                    .UsingInMemoryPersistence()
                    .UsingSqlPersistence("EventStoreDB")
                    .WithDialect(new MsSqlDialect())
                    .EnlistInAmbientTransaction()
                    .InitializeStorageEngine()
                    // .UsingJsonSerialization()
                    .Build();
        }

        private static void OpenStream()
        {
            // or we can call OpenStream(StreamId, 0, int.MaxValue) to read all commits,
            // if no commits exist then it creates a new stream for us.
            using (IEventStream stream = store.OpenStream(new Guid("b563c6e7-1855-4963-8bb8-00fd06272e71"), 0, int.MaxValue))
            {

            }
        }


    }
}
