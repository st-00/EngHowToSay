using Xunit;

namespace Tests
{
    public class DisplayChapterServiceTests
    {
        private readonly DisplayChapterService _service = new DisplayChapterService();

        [Fact]
        public void Get_Senteses_To_Display()
        {
        }
    }


    public class DisplayChapterService
    {
        public const int DesiredMaxNumberOfChars = 100;
    }
}