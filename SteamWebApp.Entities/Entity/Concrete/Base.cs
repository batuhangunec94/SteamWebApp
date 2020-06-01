using SteamWebApp.Entities.Entity.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamWebApp.Entities.Entity.Concrete
{
    public class Base : ICore
    {
        public int Id { get; set; }
        private DateTime _transactionDate = DateTime.Now;
        public DateTime TransactionDate { get { return _transactionDate; } set { _transactionDate = value; } }
        private Status _status = Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
