using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteamWebApp.Entities.Entity.Abstraction;
using SteamWebApp.Entities.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamWebApp.DAL.Entity.Concrete.EfCore.Context
{
    public class ProjectContext:IdentityDbContext<User>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<GameUser>().HasKey(x => new { x.GameId, x.UserId });
            modelBuilder.Entity<GameUser>().Ignore(x => x.User);
            modelBuilder.Entity<Like>().HasKey(x => new { x.GameId, x.UserId});
            modelBuilder.Entity<Like>().Ignore(x => x.User);
            modelBuilder.Entity<CategoryGame>()
                .HasKey(x => new { x.GameId, x.CategoryId });
            modelBuilder.Entity<Game>().Property(g => g.Price).IsRequired().HasColumnType("decimal(5, 2)");
            //Category Data
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Moba", Description = "Moba is a team-based strategy game where two teams of five powerful champions face off to destroy the other’s base.", TransactionDate = DateTime.Now },
            new Category() { Id = 2, Name = "Fps", Description = "A first person shooter (FPS) is a genre of action video game that is played from the point of view of the protagonist. FPS games typically map the gamer's movements and provide a view of what an actual person would see and do in the game", TransactionDate = DateTime.Now },
            new Category() { Id = 3, Name = "Survival Games", Description = "Survival games are a subgenre of action video games set in a hostile, intense, open-world environment, where players generally begin with minimal equipment and are required to collect resources, craft tools, weapons, and shelter, and survive as long as possible.", TransactionDate = DateTime.Now }
            );
            //Game Data
            modelBuilder.Entity<Game>().HasData(
                    new Game() { Id = 1, Name = "League Of Legends", Description = "(LoL) is a multiplayer online battle arena video game developed and published by Riot Games for Microsoft Windows and macOS. Inspired by the Warcraft III: The Frozen Throne mod Defense of the Ancients, the game follows a freemium model and is supported by microtransactions.", Image = "lol.jpg", Price = 120 },

            new Game() { Id = 2, Name = "CsGo", Description = "The Terrorists, depending on the game mode, must either plant the bomb or defend the hostages, while the Counter-Terrorists must either prevent the bomb from being planted, defuse the bomb, or rescue the hostages", Image = "csgo.jpg", Price = 0 },

            new Game() { Id = 3, Name = "Battleground", Description = "Battlegrounds is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive. Players can choose to enter the match solo, duo, or with a small team of up to four people.", Image = "battleground.jpg", Price = 50 },

            new Game() { Id = 4, Name = "Dota2", Description = "Dota 2 is a multiplayer online battle arena (MOBA) video game in which two teams of five players compete to collectively destroy a large structure defended by the opposing team known as the Ancient, whilst defending their own.", Image = "dota2.jpg", Price = 25 },

            new Game() { Id = 5, Name = "Smite", Description = "SMITE is the MOBA (Multiplayer Online Battle Arena) type game in which the players fight with each other on the particular map within a special set of rules. Each of the players controls one character, in SMITE the characters are Gods.", Image = "smite.jpg", Price = 0 },

            new Game() { Id = 6, Name = "H1Z1", Description = "Z1 Battle Royale (formerly H1Z1 and King of the Kill) is a free-to-play battle royale game developed and published by Daybreak Game Company. The game's development began after the original H1Z1 was spun off into two separate projects in early 2016: H1Z1: Just Survive and H1Z1: King of the Kill.", Image = "h1z1.jpg", Price = 15 },

            new Game() { Id = 7, Name = "Paragon", Description = "Paragon was a free-to-play multiplayer online battle arena game developed and published by Epic Games. Powered by their own Unreal Engine 4, the game started pay-to-play early access in March 2016, and free-to-play access to its open beta started in February 2017.", Image = "paragon.jpg", Price = 0 },

            new Game() { Id = 8, Name = "Valorant", Description = "Gameplay. Valorant is a team-based tactical shooter and first-person shooter set in the near-future. ... In the main game mode, players join either the attacking or defending team with each team having five players on it. Agents have unique abilities and use an economic system to purchase their abilities and weapons.", Image = "valorant.jpg", Price = 60 },

            new Game() { Id = 9, Name = "Raft", Description = "Raft throws you and your friends into an epic oceanic adventure! Alone or together, players battle to survive a perilous voyage across a vast sea! Gather debris, scavenge reefs and build your own floating home, but be wary of the man-eating sharks!", Image = "raft.jpg", Price = 0 },

            new Game() { Id = 10, Name = "Minecraft", Description = "Minecraft is a Lego style adventure game which has massively increased in popularity since it was released two years ago. It now has more than 33 million users worldwide. The video game puts players in a randomly-generated world where they can create their own structures and contraptions out of textured cubes", Image = "minecraft.jpg", Price = 140 }
                );
            //CategoryGame Data
            modelBuilder.Entity<CategoryGame>().HasData(
            new CategoryGame() { CategoryId = 1, GameId = 1 },
            new CategoryGame() { CategoryId = 2, GameId = 2 },
            new CategoryGame() { CategoryId = 2, GameId = 3 },
            new CategoryGame() { CategoryId = 3, GameId = 3 },
            new CategoryGame() { CategoryId = 1, GameId = 4 },
            new CategoryGame() { CategoryId = 1, GameId = 5 },
            new CategoryGame() { CategoryId = 3, GameId = 6 },
            new CategoryGame() { CategoryId = 2, GameId = 6 },
            new CategoryGame() { CategoryId = 1, GameId = 7 },
            new CategoryGame() { CategoryId = 2, GameId = 8 },
            new CategoryGame() { CategoryId = 3, GameId = 9 },
            new CategoryGame() { CategoryId = 3, GameId = 10 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
