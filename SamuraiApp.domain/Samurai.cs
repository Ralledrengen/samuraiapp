using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.domain
{
    public class Samurai
    {
        public Samurai()
        {
            Quotes = new List<Quotes>;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quotes> Quotes { get; set; }
        public Clan Clan { get; set; }
    }

    public class Clan
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
    }

    public class Quotes
    {

    }
}
