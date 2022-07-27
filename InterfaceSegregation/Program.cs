namespace InterfaceSegregation;

//This is a bad example.


//Because FullTimeEmployee class does not need to implement the CalculateWorkedSalary function 
//And the ContractEmployee class does not need to implement the CalculateNetSalary function.
//This example does not follow the "Interface Segregation Principle"



//public interface IWorker
//{
//    string ID { get; set; }
//    string Name { get; set; }
//    string Email { get; set; }
//    float MonthlySalary { get; set; }
//    float OtherBenefits { get; set; }
//    float HourlyRate { get; set; }
//    float HoursInMonth { get; set; }
//    float CalculateNetSalary();
//    float CalculateWorkedSalary();
//}

//public class FullTimeEmployee : IWorker
//{
//    public string ID { get; set; }
//    public string Name { get; set; }
//    public string Email { get; set; }
//    public float MonthlySalary { get; set; }
//    public float OtherBenefits { get; set; }
//    public float HourlyRate { get; set; }
//    public float HoursInMonth { get; set; }
//    public float CalculateNetSalary() => MonthlySalary + OtherBenefits;
//    public float CalculateWorkedSalary() => throw new NotImplementedException();
//}

//public class ContractEmployee : IWorker
//{
//    public string ID { get; set; }
//    public string Name { get; set; }
//    public string Email { get; set; }
//    public float MonthlySalary { get; set; }
//    public float OtherBenefits { get; set; }
//    public float HourlyRate { get; set; }
//    public float HoursInMonth { get; set; }
//    public float CalculateNetSalary() => throw new NotImplementedException();
//    public float CalculateWorkedSalary() => HourlyRate * HoursInMonth;
//}


public interface IBaseWorker
{
    string ID { get; set; }
    string Name { get; set; }
    string Email { get; set; }

}

public interface IFullTimeWorkerSalary : IBaseWorker
{
    float MonthlySalary { get; set; }
    float OtherBenefits { get; set; }
    float CalculateNetSalary();
}

public interface IContractWorkerSalary : IBaseWorker
{
    float HourlyRate { get; set; }
    float HoursInMonth { get; set; }
    float CalculateWorkedSalary();
}

public class FullTimeEmployeeFixed : IFullTimeWorkerSalary
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public float MonthlySalary { get; set; }
    public float OtherBenefits { get; set; }
    public float CalculateNetSalary() => MonthlySalary + OtherBenefits;
}

public class ContractEmployeeFixed : IContractWorkerSalary
{
    public string ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public float HourlyRate { get; set; }
    public float HoursInMonth { get; set; }
    public float CalculateWorkedSalary() => HourlyRate * HoursInMonth;
}

//We see that we have created a base interface which has the common properties of all employees.
//Then, we created 2 more interfaces which implement the base interface and these interfaces are for the full time and contract employee, respectively.
//They only contain properties and methods for the particular type of employee.
//Finally, in our classes for the full time and contract employee,
//we only implement the required interface (full time or contract). No additional method or property is required.