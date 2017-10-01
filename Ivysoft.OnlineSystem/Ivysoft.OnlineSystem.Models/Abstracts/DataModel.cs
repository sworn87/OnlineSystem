using Ivysoft.OnlineSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ivysoft.OnlineSystem.Models.Abstracts
{
    public abstract class DataModel : IAuditable, IDeletable
    {
        public DataModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
