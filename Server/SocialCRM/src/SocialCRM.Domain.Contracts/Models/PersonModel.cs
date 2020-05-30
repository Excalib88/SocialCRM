using System;

namespace SocialCRM.Domain.Contracts.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string SecondPhone { get; set; }
    }
}