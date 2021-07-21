using System.ComponentModel.DataAnnotations.Schema;

namespace Recruitment.Models
{
    public class ApprovalsList
    {
       
        public long Id{get; set;}
        public long LevelId{get; set;}

        public string Role{get; set;}
        public string EmailTo{get; set;}

        public string Cc{get; set;}
        public string Status{get; set;}
        public bool IsCompleted{get; set;}
    }
}
