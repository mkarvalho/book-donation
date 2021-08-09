using BookDonation.Shared.Commands;
using System;

namespace BookDonation.Domain.UserContext.Commands.UserCommands.Outputs
{
    public class CreateUserCommandResult : ICommandResult
    {
        public CreateUserCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }



        //public CreateUserCommandResult(Guid id, string name, string document, string email, string birthDate)
        //{
        //    Id = id;
        //    Name = name;
        //    Document = document;
        //    Email = email;
        //    BirthDate = birthDate;
        //}

        //public Guid Id { get; set; }
        //public string Name { get; set; }
        //public string Document { get; set; }
        //public string Email { get; set; }
        //public string BirthDate { get; set; }



        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
