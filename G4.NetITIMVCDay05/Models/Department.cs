﻿namespace G4.NetITIMVCDay05.Models
{
    public class Department
    {
        /*---------------------------------------------------------*/
        public int Id { get; set; }
        public string Name { get; set; }
        /*---------------------------------------------------------*/
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        /*---------------------------------------------------------*/
    }
}
