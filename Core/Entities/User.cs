﻿namespace Levelnis.Learning.AutofacExamples.Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
    }
}