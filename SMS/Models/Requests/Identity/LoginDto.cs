﻿namespace SMS.Models.Requests.Identity
{
    public class LoginDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Provider { get; set; } = Constants.Constants.Provider.Wasm;
    }
}
