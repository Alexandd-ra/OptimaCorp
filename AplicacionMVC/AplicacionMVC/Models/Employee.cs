using System;
using System.Collections.Generic;

namespace AplicacionMVC.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public long Salary { get; set; }

    public int IdDeparmentFk { get; set; }

    public virtual Department IdDeparmentFkNavigation { get; set; } = null!;
}
