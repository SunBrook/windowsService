using System.Collections.Generic;

namespace DataDispose.Library.Models
{
    public class ApiRequest
    {
        public string RequestKey { get; set; }
        public List<MyTask> Tasks { get; set; }
    }
}
