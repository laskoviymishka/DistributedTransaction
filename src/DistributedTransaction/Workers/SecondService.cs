namespace DistributedTransaction.Workers
{
    public class SecondService : BaseService
    {
        public SecondService() : base("./2_success.log", "./2_fail.log")
        {
        }
    }
}