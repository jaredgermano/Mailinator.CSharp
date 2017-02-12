using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Mailinator.CSharp.Tests
{
    [TestClass]
    public class MailinatorTests
    {
        private const string Token = "YourApiTokenHere";

        [TestMethod]
        public async Task ListInboxMessages()
        {
            Token.Should().NotBe("YourApiTokenHere", "you have not configured your API Token");

            using (Mailinator mailinator = new Mailinator(Token))
            {
                var result = await mailinator.ListInboxMessagesAsync(new InboxRequest()
                {
                    To = "Testing"
                });

                result.Should().NotBeNull();
                result.Messages.Count().Should().BeGreaterOrEqualTo(1);
            }
        }

        [TestMethod]
        public async Task GetEmailMessage()
        {
            Token.Should().NotBe("YourApiTokenHere", "you have not configured your API Token");

            using (Mailinator mailinator = new Mailinator(Token))
            {
                var inbox = await mailinator.ListInboxMessagesAsync(new InboxRequest()
                {
                    To = "Testing"
                });

                var result = await mailinator.GetEmailMessageAsync(new EmailRequest()
                {
                    EmailId = inbox.Messages.First().Id
                });

                result.Should().NotBeNull();
                result.Data.Should().NotBeNull();
                result.Data.Parts.Should().NotBeNull();
                result.Data.Parts.Count().Should().BeGreaterOrEqualTo(1);
            }
        }

        [TestMethod]
        public async Task DeleteEmailMessage_Success()
        {
            Token.Should().NotBe("YourApiTokenHere", "you have not configured your API Token");

            using (Mailinator mailinator = new Mailinator(Token))
            {
                var inbox = await mailinator.ListInboxMessagesAsync(new InboxRequest()
                {
                    To = "Testing"
                });

                var result = await mailinator.DeleteEmailMessageAsync(new EmailRequest()
                {
                    EmailId = inbox.Messages.First().Id
                });

                result.Status.Should().Be("ok");
            }
        }

        [TestMethod]
        public async Task DeleteEmailMessage_EmailDoesntExist()
        {
            Token.Should().NotBe("YourApiTokenHere", "you have not configured your API Token");

            using (Mailinator mailinator = new Mailinator(Token))
            {
                var result = await mailinator.DeleteEmailMessageAsync(new EmailRequest()
                {
                    EmailId = "somethingelsefdsfsdfsdfdsfdsfdsfdsfds"
                });

                result.Status.Should().Be("ok");
            }
        }
    }
}
