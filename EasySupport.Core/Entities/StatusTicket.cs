﻿namespace EasySupport.Core.Entities
{
    public class StatusTicket : BaseEntity
    {
        public StatusTicket(string name) : base()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
