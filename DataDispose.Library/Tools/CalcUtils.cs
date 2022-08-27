namespace DataDispose.Library.Tools
{
    public class CalcUtils
    {
        public static int GetRequestCount(int totalCount, int rowCount)
        {
            var row = totalCount / rowCount;
            if (totalCount % rowCount != 0)
            {
                row++;
            }
            return row;
        }
    }
}
