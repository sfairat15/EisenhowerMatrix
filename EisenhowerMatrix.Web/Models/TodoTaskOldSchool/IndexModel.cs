using System.Collections.Generic;

namespace EisenhowerMatrix.Web.Models.TodoTaskOldSchool
{
    public class IndexModel
    {
        public IList<TaskModel> Tasks { get; set; } = new List<TaskModel>();
    }
}
