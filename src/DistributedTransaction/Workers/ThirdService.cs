namespace DistributedTransaction.Workers
{
    public class ThirdService : BaseService
    {
        public ThirdService() : base("./3_success.log", "./3_fail.log")
        {
        }
    }
}