namespace DistributedTransaction.Workers
{
    public class FirstService : BaseService
    {
        public FirstService() : base("./1_success.log", "./1_fail.log")
        {
        }
    }
}