﻿namespace TaskManagerAPI.Domain.Entities.UserManage
{
	public class User
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

