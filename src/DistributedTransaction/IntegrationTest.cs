using System.Security.Authentication;
using DistributedTransaction.Exceptions;
using DistributedTransaction.Workers;
using Xunit;

namespace DistributedTransaction
{
    public class IntegrationTest
    {
        [Fact]
        public void ShouldHaveSameSuccessCountForEach()
        {
            var service = new Service();

            var result = service.Run(200);
            foreach (var childSuccess in result.ChildSuccess)
            {
                Assert.Equal(result.TotalSuccess, childSuccess);
            }
        }

        [Fact]
        public void FirstShouldFailSomeTimes()
        {
            var service = new FirstService();
            Assert.Throws<SingleWorkerException>(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    service.RunSingle(i);
                }
            });
        }

        [Fact]
        public void SecondShouldFailSomeTimes()
        {
            var service = new SecondService();
            Assert.Throws<SingleWorkerException>(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    service.RunSingle(i);
                }
            });
        }

        [Fact]
        public void ThirdShouldFailSomeTimes()
        {
            var service = new ThirdService();
            Assert.Throws<SingleWorkerException>(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    service.RunSingle(i);
                }
            });
        }
    }
}