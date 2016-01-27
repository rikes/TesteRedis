using System;

namespace RedisTest
{
    public class Log
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public DateTime LogDateTime { get; set; }
    }

    public class User
    {
        public string Name = "Pedro";
        public string SobreNome = "MArtins";

    }
}