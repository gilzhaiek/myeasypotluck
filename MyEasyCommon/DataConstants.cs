using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEasyCommon
{
    public class DataConstants
    {
        public const int UserNameLength = 25;
        public const int PasswordLength = 25;
        public const int EmailLength = 256;
        public const int FirstNameLength = 40;
        public const int LastNameLength = 40;
        public const int EventNameLength = 50;
        public const int MaxFileSizeBytes = 2097152;

        public const int EventMaxSide = 220;
        public const int EventThumbMaxSide = 100;

        public const int ItemMaxSide = 128;
        public const int ItemThumbMaxSide = 64;

        public const string FullImageUpload = "/user_space/images/uploads";
        public const string ThumbsImageUpload = "/user_space/images/thumbs";
    }
}
