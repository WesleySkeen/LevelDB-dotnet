using System.Collections.Generic;
using LevelDB.Api.Controllers;
using ZeroFormatter;

namespace LevelDB.Api
{
    public class LocalDb
    {
        public DB _localDb;

        public LocalDb()
        {
            _localDb = new DB(new Options {CreateIfMissing = true}, @"players");
            populatePlayers();
        }

        public Player Get(string key)
        {
            byte[] id = ZeroFormatterSerializer.Serialize(key.ToLower());

            var player = _localDb.Get(id);

            return ZeroFormatterSerializer.Deserialize<Player>(player);
        }

        private void populatePlayers()
        {
            var players = new List<Player>
            {
                new Player("Bruno", "Fernandez"),
                new Player("Anthony", "Martial"),
                new Player("Marcus", "Rashford")
            };

            foreach (var player in players)
            {
                byte[] data = ZeroFormatterSerializer.Serialize(player);
                byte[] id = ZeroFormatterSerializer.Serialize(player.FirstName.ToLower());

                _localDb.Put(id, data);
            }
        }
    }
}