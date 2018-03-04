namespace Moo.Data.Migrations
{
    using Moo.Entities.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Moo.Data.Context.MooDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Moo.Data.Context.MooDbContext context)
        {
            // CreateUsers(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        private void CreateUsers(Moo.Data.Context.MooDbContext context)
        {
            for (var i = 0; i < 30; i++)
            {
                var user = new User()
                {
                    Username = $"User_{i}",
                    Password = "password"
                };
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
                user.GamesPlayed = CreatePlayedGames(30 - i, user.ID);
                context.SaveChanges();
            }
        }

        private List<Game> CreatePlayedGames(int wonGames, int userId)
        {
            var numberOfGames = 30;
            var games = new List<Game>();
            for (var i = 0; i < numberOfGames; i++)
            {
                var hasUserWonValue = i > wonGames ? false : true;
                games.Add(new Game() { UserID = userId, UserWon = hasUserWonValue });
            }

            return games;
        }
    }
}
