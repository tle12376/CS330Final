using System;
using System.IO;
using System.Text.Json;

namespace CS330Final
{

    public static class TokenHelper
    {
        public static string GetToken(string userEmail, string password)
        {
            // do a db lookup to confirm the userEmail and password
            // create the token
            var token = new Token
            {
                UserId = 10,
                Expires = DateTime.UtcNow.AddMinutes(1),
            };
            var jsonString = JsonSerializer.Serialize(token);
            var encryptedJsonString = Crypto.EncryptStringAES(jsonString);
            return encryptedJsonString;
        }

        public static Token DecodeToken(string token)
        {
            var decryptedJsonString = Crypto.DecryptStringAES(token);
            var tokenObject = JsonSerializer.Deserialize<Token>(decryptedJsonString);
            if (tokenObject.Expires < DateTime.UtcNow)
            {
                return null;
            }
            return tokenObject;
        }
    }
}
