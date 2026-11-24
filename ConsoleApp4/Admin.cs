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
            var keepRunning = true;
            while (keepRunning)
            {
                Console.Write("Enter your username: ");
                var username = Console.ReadLine();

                if (CurrentUser != null && CurrentUser.Username == username)
                {
                    Console.WriteLine("\nWelcome back, " + CurrentUser.Username + ".");
                    return;
                }

                foreach (var user in users)
                {
                    if (user.Username == username)
                    {
                        Console.WriteLine("\nUser existing detected, enter password to login.");

                        while (true)
                        {
                            Console.Write("Enter your password to login: ");
                            var loginPassword = Console.ReadLine().Trim();

                            if (user.Password == loginPassword)
                            {
                                CurrentUser = user;
                                Console.WriteLine("\nLogin successful.");
                                return;
                            }

                            Console.Write("\nWrong password. Do you want to try again? (Y/N): ");
                            string answer = Console.ReadLine().Trim().ToLower();

                            if (answer != "y")
                            {
                                Console.WriteLine("Login cancelled.");
                                return;
                            }
                        }
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
                break;
            }
        }


        public static void SetNewPassword(List<Admin> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nNo Record found");
                return;
            }
            Console.WriteLine("\nACCOUNTS");

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"Username: " + users[i].Username);
            }

            Console.Write("Enter the number of the user you want to change password: ");
            int selected;

            if (!int.TryParse(Console.ReadLine(), out selected))
            {
                Console.WriteLine("\nInvalid input.");
                return;
            }

            if (selected < 1 || selected > users.Count)
            {
                Console.WriteLine("\nUser not found.");
                return;
            }

            Admin found = users[selected - 1];

            Console.Write("Enter new password: ");
            var newPassword = Console.ReadLine();
            Console.Write("Confirm new password: ");
            var confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("\nPasswords do not match.");
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