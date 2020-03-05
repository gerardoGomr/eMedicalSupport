﻿using System;

namespace Citas.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public Entity() => Id = Guid.NewGuid();
    }
}
