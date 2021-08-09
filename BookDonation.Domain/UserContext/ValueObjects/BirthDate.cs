using BookDonation.Shared.ValueObjects;
using BookDonation.Shared.Utils;
using System;
using Flunt.Validations;

namespace BookDonation.Domain.UserContext.ValueObjects
{
    public class BirthDate : BaseValueObjects
    {
        private readonly DateTime _dateNow = DateTime.Now;
        public BirthDate(string birth)
        {
            Birth = StringToDate.ConvertToDate(birth);
            if (Birth > _dateNow)
                AddNotification("Birth", "Data de Nascimento inválida");            
        }

        public DateTime Birth { get; private set; }

        public override string ToString()
        {
            return $"{Birth}";
        }
    }
}