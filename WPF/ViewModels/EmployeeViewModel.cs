﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPF.Models;
using System.Collections.ObjectModel;
using WPF.Commands;
using WPF.ServicesAPI;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace WPF.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        EmployeeServiceAPI employeeServiceAPI;
        public EmployeeViewModel()
        {
            employeeServiceAPI = new EmployeeServiceAPI();
            LoadData();
            CurrentEmployee = new Employee();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
            
        }
        private ObservableCollection<Employee> employeeList;
        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged("EmployeeList"); }
        }
        public async void LoadData()
        {
           EmployeeList = await employeeServiceAPI.GetAllEmployeeDetails();
          
        }

        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value;OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var Saved = employeeServiceAPI.CreateEmployee(CurrentEmployee);
                
                LoadData();
                if (Saved!=null)
                { 
                Message = "Employee Saved";
                }
                else
                    Message = "Saving Failed";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            
        }

        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var employee1 = employeeServiceAPI.GetById(CurrentEmployee.id);
                int index = 0;
                //for (int index = 0; index < EmployeeList.Count; index++)
                //{
                    if(CurrentEmployee.id == EmployeeList[index].id)
                    { 
                        CurrentEmployee.name = EmployeeList[index].name;
                    CurrentEmployee.email = EmployeeList[index].email;
                    CurrentEmployee.gender = EmployeeList[index].gender;
                    CurrentEmployee.status = EmployeeList[index].status;
                    Message = "Employee found";
                        //break;
                    }
                    else
                    {
                        Message = "employee not found";
                    }

                //}

                
            }
            catch (Exception ex)
            {

                Message= ex.Message;
            }
        }

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        
        }
        public void Update()
        {
            try
            {
                var updated = EmployeeServiceAPI.Update(CurrentEmployee);
                if(updated!=null)
                {
                    
                    for (int index = 0; index < EmployeeList.Count; index++)
                    {
                        if (EmployeeList[index].id == CurrentEmployee.id)
                        {
                            EmployeeList[index].name = CurrentEmployee.name;
                            EmployeeList[index].email = CurrentEmployee.email;
                            EmployeeList[index].gender = CurrentEmployee.gender;
                            EmployeeList[index].status = CurrentEmployee.status;
                            Message = "Updation succcess";
                            break;
                        }
                        else
                        {
                            Message = "updation failed";
                        }
                    }
                    //LoadData();
                }
                
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
           
        }

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }

        }
        public void Delete()
        {
            try
            {
                var deleted = EmployeeServiceAPI.Delete(CurrentEmployee.id);
                if (deleted != null)
                {
                   // int index = 0;
                    //for (int index = 0; index < EmployeeList.Count; index++)
                    //{
                        //if (EmployeeList[index].id == CurrentEmployee.id)
                        //{
                           EmployeeList.Remove(CurrentEmployee);
                          Message = "Employee deleted";
                        //}

                    //}
                }
                else
                {
                    Message = "Deletion failed";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message; ;
            }
        }

        

    } 
}   
