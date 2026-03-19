using Xunit;
using MiniJobzAdminSite;

namespace AdminSiteTest
{
    public class UsermanagementUnitTest
    {
        private UserManagement CreateForm()
        {
            return new UserManagement("admin")
            {
                Visible = false
            };
        }

        [Fact]
        public void Test1_GetPenaltyId_Column2_Returns1()
        {
            var form = CreateForm();

            int result = form.GetPenaltyId(2);

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetPenaltyId_Column3_Returns2()
        {
            var form = CreateForm();

            int result = form.GetPenaltyId(3);

            Assert.Equal(2, result);
        }

        [Fact]
        public void GetPenaltyId_Column4_Returns3()
        {
            var form = CreateForm();

            int result = form.GetPenaltyId(4);

            Assert.Equal(3, result);
        }

        [Fact]
        public void GetPenaltyId_InvalidColumn_Returns0()
        {
            var form = CreateForm();

            int result = form.GetPenaltyId(10);

            Assert.Equal(0, result);
        }

        [Fact]
        public void TryParseUserId_ValidNumber_ReturnsTrue()
        {
            var form = CreateForm();

            bool result = form.TryParseUserId("123", out int userId);

            Assert.True(result);
            Assert.Equal(123, userId);
        }

        [Fact]
        public void TryParseUserId_InvalidString_ReturnsFalse()
        {
            var form = CreateForm();

            bool result = form.TryParseUserId("abc", out int userId);

            Assert.False(result);
        }

        [Fact]
        public void IsSearchEmpty_EmptyString_ReturnsTrue()
        {
            var form = CreateForm();

            bool result = form.IsSearchEmpty("");

            Assert.True(result);
        }

        [Fact]
        public void IsSearchEmpty_WithText_ReturnsFalse()
        {
            var form = CreateForm();

            bool result = form.IsSearchEmpty("user123");

            Assert.False(result);
        }
    }
}
