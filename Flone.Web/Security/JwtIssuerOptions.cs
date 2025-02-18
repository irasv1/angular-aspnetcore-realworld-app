﻿using Microsoft.IdentityModel.Tokens;

namespace Flone.Web.Security
{
    public class JwtIssuerOptions
    {
        public string? Issuer { get; set; }
        public string? Subject { get; set; }
        public string? Audience { get; set; }
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);

        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());
        public SigningCredentials? SigningCredentials { get; set; }
    }
}
