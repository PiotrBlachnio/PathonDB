﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PathonDB.Server {
    public class Program {
        
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, logging) => {
                logging.ClearProviders();
                logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                logging.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
    }
}


// using PathonDB.Models.Database;

// namespace PathonDB {
//     class Program {
//         static void Main(string[] args) {
//             var client = new Client();
//             var queries = new string[] {
//                 "  CREATE   TABLE   users    (  email   text   , phoneNumber int, isAdult boolean, email text);",
//                 "INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Jeff@gmail.com\", 703503);",
//                 "INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);",
//                 "SELECT * FROM  userS WHERE isAdult = false;"
//             };

//             client.ExecuteQuery(queries); 
//         }
//     }
// }