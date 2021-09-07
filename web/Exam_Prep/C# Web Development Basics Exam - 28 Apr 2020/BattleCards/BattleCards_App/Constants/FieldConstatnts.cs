using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleCards_App.Constants
{
    public class FieldConstatnts
    {
        public const int KEY_MAX_LENGHT = 40;

        public const int USER_USERNAME_MIN_LENGHT = 5;
        public  const  int USER_USERNAME_MAX_LENGHT = 20;
        public const int USER_PASSWORD_MIN_LENGHT = 5;
        public const int USER_PASSWORD_MAX_LENGHT = 20;
        public const string USER_EMAIL_REGEX = ".+@(([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]*.)+[a-zA-Z0-9]{2,17})$";



        public const int CARD_NAME_MIN_LENGHT = 5;
        public const int CARD_NAME_MAX_LENGHT = 15;
        public const int CARD_DESCRIPTION_MAX_LENGHT = 200;
    }
}
