using BattleCards_App.Dto;
using BattleCards_App.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BattleCards_App.Services
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository;

        public UsersService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        internal UserLoginVM Login(UserLoginVM user)
        {
            Models.User _user = _usersRepository.GetByUsernameAndPassword(user.Username,HashGenerator.Generate(user.Password));
            if (_user==null)
            {
                throw new Exception("Username with this password does not exist");
            }
            return user;
        }

        internal UserVM Register(UserRegisterMV user)
        {
            if (!user.Password.Equals(user.ConfirmPassword))
            {
                throw new Exception("Passwords not matched");
            }
            if (_usersRepository.GetByUsername(user.Username) !=null)
            {
                throw new Exception("User with this username exist");
            }
            if (_usersRepository.GetByEmail(user.Email) != null)
            {
                throw new Exception("User with this username exist");
            }

            Models.User _user = new Models.User() 
            { 
                Username= user.Username,
                Email= user.Email,
                Password=HashGenerator.Generate(user.Password)
            };
            _usersRepository.Add(_user);
            return new UserVM() { Username = _user.Username };

        }
    }

    class HashGenerator {

        public static string Generate(string input) {

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
             Convert.ToBase64String(salt);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
