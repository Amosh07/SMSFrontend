﻿namespace SMS.Models.Responses.Class
{
    public class GetClassDetailDto
    {
        public Guid Id { get; set; }

        public string ClassName { get; set; }

        public bool IsActive { get; set; }  
    }
}
