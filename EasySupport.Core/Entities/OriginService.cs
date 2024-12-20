﻿namespace EasySupport.Core.Entities
{
    public class OriginService : BaseEntity
    {
        public OriginService(string name) : base()
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
