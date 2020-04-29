using System;
using Telegram.Bot.Types;
using Xunit;

namespace Telegram.Bot.Tests.Unit
{
    public class ChatIdTests
    {
        [Theory]
        [InlineData("@username")]
        [InlineData("@UserName")]
        [InlineData("@User1")]
        [InlineData("@12345")]
        public void Valid_User_Name(string userName)
        {
            var chatId = new ChatId(userName);

            Assert.Equal(chatId, userName);
        }

        [Fact]
        public void Null_User_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatId(null));
        }


        [Theory]
        [InlineData("12345")]
        [InlineData("username")]
        [InlineData("@u")]
        [InlineData("@User")]
        [InlineData("@1234")]
        public void Invalid_User_Name(string userName)
        {
            Assert.Throws<ArgumentException>(() => new ChatId(userName));
        }
    }
}
