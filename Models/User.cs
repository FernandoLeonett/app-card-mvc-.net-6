﻿namespace app_card.Models
{

    public enum Rol
    {

        Administrator,
        User
    }
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}
