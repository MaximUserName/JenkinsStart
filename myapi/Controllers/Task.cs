using System;

namespace myapi.Controllers
{
    public class Task
    {
        public Task()
        {
            Description = Guid.NewGuid().ToString("N");
        }
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string OneMore { get; set; }
    }
}