﻿using System.ComponentModel.DataAnnotations;

namespace BlogProjectApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
