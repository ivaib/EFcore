using System;
using EMSDBfirst.Models;
using System.Linq;
    namespace EMSDBfirst
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine($"1 Add Department, 2 List Dept, 3 Add Employee, 4 List Emp, 5 Exit");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddDepartment()
                            break;
                        case 2:
                            ListDepartments();
                            break;
                        case 3:
                            AddEmployee();
                            break;
                        case 4:
                            ListEmployee();
                            break;
                        case5:
                            A
                            break;
                        default:
                            break;
                    }
                }
            } while (true);


        }
        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();
            Console.WriteLine("Enter Name");
            string input = ConsoleReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                newEmployee.Name = input;
                Console.WriteLine("Enter salary");
                input = Console.ReadLine();
                if (decimal.TryParse(input,out decimal salary) && salary>0)              {
                    {
                        newEmployee.Salary = salary;
                        Console.WriteLine("Enter Commision");
                        input = Console.ReadLine();
                        if (decimal.TryParse(input,out decimal commision)&& commision>0)
                        {
                            Console.WriteLine("Enter the date of Joing");
                            input = Console.ReadLine();
                            if (DateTime.TryParse(input, out DateTime DOJ))
                            {
                                newEmployee.DateofJoining = DOJ;
                                Console.WriteLine("Enter the Date of Birth");
                                input = Console.ReadLine();
                                if (DateTime.TryParse(input, out DateTime DOB)&& DOB<DateTime.Today )
                                {
                                    newEmployee.DateofBirth = DOB;
                                    ListDepartments();
                                    Console.WriteLine("Enter Department Id");
                                    input = Console.ReadLine();
                                    if (int.TryParse(input,out int deptId))
                                    {
                                        newEmployee.DepartmentNo = deptId;
                                        Console.WriteLine("Enter Job Title");
                                        input = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(input))
                                        {
                                            newEmployee.JobTitle = input;
                                            Console.WriteLine("Employee manager Id");
                                            input = Console.ReadLine();
                                            if (int.TryParse(input,out int managerId))
                                            {
                                                newEmployee.ReportingTo = managerId;
                                                using (TrainingDbContext context = new TrainingDbContext())
                                                {
                                                    context.Employee.Add(newEmployee);
                                                    int recordsUpdated = context.SaveChanges();
                                                                                                                                                      if (recordsUpdated>0)
                                                        if (recordsUpdated>0)
                                                        {
                                                            Console.WriteLine("Success");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("not");
                                                        }
                                                
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    
                    
                    }

                   
            }
        
        
        }
        private static void ListDepartments()
        {
            using (TrainingDbContext context = new TrainingDbContext())
            {
                var list = context.Departments.ToList();
                        
            }
        }
        static void AddDepartment()
        {
            AddDepartment newDept = new AddDepartment();
            Console.WriteLine("Enter Name");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                newDept.Name = input;
                Console.WriteLine("Enter Location");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    newDept.Location = input;
                    using (TrainingDbContext context = new TrainingDbContext())
                    {
                        int deptId = context.Department.Max(d => d.DeaprtmentId);
                        newDept.DepartmentId = deptId + 10;
                        context.Departments.Add(newDept);
                        int recordedAffected = context.SaveChanges();
                        if (recordedAffected>0)
                        {
                            Console.WriteLine("Dept added succesfully");
                        }
                        else
                        {
                            Console.WriteLine("Not added");
                        }
                    }
                }
            }


        }
    }
}

