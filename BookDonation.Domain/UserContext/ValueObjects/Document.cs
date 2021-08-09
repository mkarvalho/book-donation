using BookDonation.Shared.ValueObjects;
using Flunt.Extensions.Br.Validations;
using Flunt.Validations;

namespace BookDonation.Domain.UserContext.ValueObjects
{
    public class Document : BaseValueObjects
    {
        public Document(string cpf)
        {
            CPF = cpf;

            AddNotifications(new Contract<Document>()
                .IsCpf(CPF, "CPF", "CPF inválido")
            );
        }

        public string CPF { get; private set; }

        public override string ToString()
        {
            return $"{CPF}";
        }
    }
}