using System;
using System.Collections.Generic;
using ConsoleApp4;
using FOPGROUPMAIN;

namespace FOPGROUPMAIN
{
    public class Admin
    {
        public static Admin CurrentUser;
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;

        public static void AddUser(List<Admin> users, List<Warehouse> warehouseUser)
        {
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("\nUser existing detected, enter password to login.");
                    Console.Write("Enter your password to login: ");
                    var loginPassword = Console.ReadLine().Trim();

                    if (user.Password == loginPassword)
                    {
                        CurrentUser = user;
                        Console.WriteLine("\nLogin successful.");
                    }
                    else
                    {
                        Console.WriteLine("\nWrong password detected create new account.");
                        Console.WriteLine();
                        Admin.AddUser(users, warehouseUser);
                    }
                    return;
                }
            }

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Admin newUser = new Admin();
            newUser.Username = username;
            newUser.Password = password;
            users.Add(newUser);
            CurrentUser = newUser;

            Console.WriteLine("\nAccount created.");
        }

        public static void SetNewPassword(List<Admin> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No Record found");
                return;
            }
            Console.WriteLine("\nACCOUNTS");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"Username: " + users[i].Username);
            }

            Console.Write("Search the user you want to change password: ");
            var selected = Console.ReadLine();

            Admin found = users.Find(u => u.Username == selected);

            if (found == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter new password: ");
            var newPassword = Console.ReadLine();
            Console.Write("Confirm new password: ");
            var confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            found.Password = newPassword;
            Console.WriteLine("Password updated for " + found.Username);
        }

        public static void DeactivateUser(List<Admin> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No Record found");
                return;
            }
            Console.WriteLine("\nACCOUNTS");

            foreach (var user in users)
            {
                Console.WriteLine("Username: " + user.Username);
            }

            Console.WriteLine("\nDEACTIVATING USERS");
            Console.Write("Enter a username to deactivate: ");
            var keyword = Console.ReadLine().ToLower();

            Admin found = users.Find(u => u.Username.ToLower() == keyword);

            if (found == null)
                Console.WriteLine("No Record found");
            else
            {
                Console.Write("Do you wish to deactivate this user? (Y/N): ");
                string answer = Console.ReadLine().Trim().ToLower();

                if (answer == "y")
                {
                    found.IsActive = false;
                    Console.WriteLine("User deactivated.");
                }
                else
                    Console.WriteLine("User has not been deactivated");
            }
        }

        public static void DisplayAllUsers(List<Admin> users)
        {
            if (users.Count == 0)
                Console.WriteLine("No Record found");

            Console.WriteLine("\nUSER LIST");
            foreach (var user in users)
            {
                Console.WriteLine();
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("Status: " + (user.IsActive ? "Active" : "Deactivated"));
            }
        }

        public static void DisplayInactiveUsers(List<Admin> users)
        {
            var any = false;
            foreach (var user in users)
            {
                if (!user.IsActive)
                {
                    Console.WriteLine("\nUsername: " + user.Username);
                    any = true;
                }
            }

            if (!any)
                Console.WriteLine("No Inactive User");
        }

        public static void DisplayActiveUsers(List<Admin> users)
        {
            var any = false;
            foreach (var user in users)
            {
                if (user.IsActive)
                {
                    Console.WriteLine("\nUsername: " + user.Username);
                    any = true;
                }
            }

            if (!any)
                Console.WriteLine("No Active User");
        }
    }
}