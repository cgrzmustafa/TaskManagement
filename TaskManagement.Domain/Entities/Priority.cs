using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Priority : BaseEntity
    {
        public string Definiton { get; set; } = null!;

        #region NavigationProperties
        public List<AppTask>? Tasks { get; set; }
        #endregion
    }
}
