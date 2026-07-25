using System;

namespace TaskManagement.Domain.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public int UserId { get; set; }        
        public string UserName { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}