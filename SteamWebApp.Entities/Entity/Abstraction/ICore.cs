using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.Entities.Entity.Abstraction
{
    public enum Status
    {
        None = 0,
        Active = 1,
        Passive =2,
    }
    public interface ICore
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public Status Status { get; set; }
    }
}
