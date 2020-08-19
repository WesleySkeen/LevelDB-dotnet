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
        }

        public Player Get(string key)
        {
            byte[] id = ZeroFormatterSerializer.Serialize(key);

            var player = _localDb.Get(id);

            return ZeroFormatterSerializer.Deserialize<Player>(player);
        }
        
        public void Put(List<Player> players)
        {
            foreach (var player in players)
            {
                byte[] data = ZeroFormatterSerializer.Serialize(player);
                byte[] id = ZeroFormatterSerializer.Serialize(player.FirstName);

                _localDb.Put(id, data);
            }
        }
    }
}