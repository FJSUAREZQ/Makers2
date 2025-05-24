using System;
using System.Collections.Generic;

namespace _1.DAL.DataContext;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }
}
