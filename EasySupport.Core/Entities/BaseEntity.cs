﻿namespace EasySupport.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

        public void SetAsActived()
        {
            IsDeleted = false;
        }
    }
}