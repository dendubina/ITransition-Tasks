using Task_6_RandomData.Constants;

namespace Task_6_RandomData.Models
{
    public class RequestDataModel
    {
        public Regions Region { get; set; }
        public double MistakesCount { get; set; }
        public int Seed { get; set; }
        public int PageNumber { get; set; }
    }
}
