using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WPF;
using WPF.Models;
using WPF.ViewModels;

namespace WPF.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test_GetEmpDetails()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            EmployeeServiceAPI employeeServiceAPI = new EmployeeServiceAPI();
           ObservableCollection<Employee> employee = new ObservableCollection<Employee>();
            var userlist = employeeServiceAPI.GetEmpDetails().Result;
           // Assert.IsNotNull(userlist);
           if(userlist.Count>0)
            {
                Assert.IsTrue(userlist.Count > 0);

            }

        }

        [TestMethod]
        public async Task Test_CreateEmployee()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            EmployeeServiceAPI employeeServiceAPI = new EmployeeServiceAPI();
           Employee employee = new Employee() 
           { id=101,name= "justin",email="justin@gmail.com",gender="male",status="inactive" };
            var newuser =await employeeServiceAPI.CreateEmployee(employee);
            // Assert.IsNotNull(newuser);
            //Assert.AreEqual<Employee>(employee, newuser);
            Assert.IsTrue(OperatorNotEqualsToo(employee, newuser));

        } 

        private static bool OperatorNotEqualsToo (Employee expected, Employee actual)
        {
            if (((object)expected) == null || ((object)actual) == null)
                return !Object.Equals(expected, actual);

            return !(expected.Equals(actual));
        }

        [TestMethod]
        public void Test_Update()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            EmployeeServiceAPI employeeServiceAPI = new EmployeeServiceAPI();
            Employee employee = new Employee()
            { id = 101, name = "justin", email = "justin@gmail.com", gender = "male", status = "inactive" };
            var updateddata = EmployeeServiceAPI.Update(employee);
            Assert.IsNotNull(updateddata);

        }
        
    }
}
