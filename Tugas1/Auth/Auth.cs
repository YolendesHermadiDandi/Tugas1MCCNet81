using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tugas1.EvenOdd;
using Tugas1.User;

namespace Tugas1.Auth
{


    public class Auth
    {
        private static Dictionary<int, Employees> daftarKaryawan = new Dictionary<int, Employees> { };

        private static int count = 0;
        private static int usernamecount = 0;
        public static void Main(string[] args)
        {
            Menu();

        }


        /*
         * Metod dibawah digunakan untuk mencetak menu dari tampilan awal aplikasi
         * 
         */
        public static void Menu()
        {
            Boolean menuloop = true;
            do
            {


                Console.WriteLine("===========BASIC AUTH==============");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login");
                Console.WriteLine("5. Exit");

                Console.Write("Pilih Menu : ");
                String selectMenu = Console.ReadLine();
                switch (selectMenu)
                {
                    case "1":
                        Console.Clear();
                        CreateUser();
                        break;
                    case "2":
                        Console.Clear();
                        ShowUser();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Masukan Nama User (case senitif) : ");
                        String name = Console.ReadLine();
                        SearchUser(name);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("=========MENU LOGIN============");
                        String status = Login();
                        if (status == "Berhasil")
                        {
                            Console.WriteLine("Login Berhasil");
                            program.menu();


                        }
                        else
                        {
                            Console.WriteLine("Login Gagal");
                        }
                        break;

                    case "5":
                        menuloop = false;
                        break;
                    default:
                        break;
                }
            } while (menuloop);

        }

        /*
         * Method dibawah digunakan untuk menambahkan user baru
         * 
         * 
         */
        public static void CreateUser()
        {

            Employees user = UserInputValidation();
            daftarKaryawan.Add(++count, user);

            Console.WriteLine("Data Berhasil Disimpan");


        }


        /*
         * Method dibawah digunakan untuk malakukan validasi terhadap inputan user
         * dan membuat username secara otomatis
         */
        private static Employees UserInputValidation()
        {

            String firstName;
            String lastName;
            String password;

            //Cek Validasi
            firstName = InputCheck("First Name : "); //cek inputan first name
            lastName = InputCheck("Last Name : "); // cek inputan last name
            password = InputCheck("Password : "); // cek inputan password


            //membuat username secara otomatis 
            String username = firstName.Substring(0, 2) + "" + lastName.Substring(0, 2);
            foreach (var item in daftarKaryawan)
            {
                if (item.Value.Username == username)
                {

                    username = username + "" + (++usernamecount);
                }
            }


            Employees user = new Employees(firstName, lastName, password, username);
           
            return user;

        }

        /*
         * Method dibawah digunakan untuk menampilkan semua user yang disimpan
         * 
         */
        public static void ShowUser()
        {

            Boolean showUserselect = true;
            do
            {
                Console.WriteLine("==========LIST USERS==========");
                foreach (var item in daftarKaryawan)
                {
                    Console.WriteLine("id : " + item.Key);
                    Console.WriteLine(item.Value.toString());
                }


                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Edit User");
                Console.WriteLine("2. Deleter User");
                Console.WriteLine("3. Back");
                Console.Write("Pilih Menu : ");
                String menuSelect = Console.ReadLine();
                String userId;
                switch (menuSelect)
                {
                    case "1":

                        Console.Write("Masukan Id (Angka) User yang ingin diubah : ");
                        userId = Console.ReadLine();
                        try
                        {
                            EditUser(int.Parse(userId));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("INPUTAN TIDAK FALID");
                        }



                        break;
                    case "2":
                        Console.Write("Masukan Id (Angka) User yang ingin dihapus : ");
                        userId = Console.ReadLine();
                        try
                        {
                            DeleteUser(int.Parse(userId));

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("INPUTAN TIDAK FALID");
                        }
                        break;
                    case "3":
                        Console.Clear();
                        showUserselect = false;
                        break;
                    default:
                        break;
                }


            } while (showUserselect);
        }

        /*
         * Method dibawah digunakan untuk melalukan edit terhadap data user berdasarkan ID
         */
        public static void EditUser(int id)
        {


            try
            {
                //trigger try catch jika id tidak ada.
                daftarKaryawan[id].ToString();

                Employees user = UserInputValidation();
                daftarKaryawan[id].FirstName = user.FirstName;
                daftarKaryawan[id].LastName = user.LastName;
                daftarKaryawan[id].Password = user.Password;
                daftarKaryawan[id].Username = user.Username;
                Console.WriteLine("DATA BERHASIL DIUBAH");

            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("User dengan Id : " + id + " tidak ditemukan");
            }

        }

        /*
         * Method dibawah digunakan untuk menghapus user berdasarkan ID
         */
        public static void DeleteUser(int id)
        {
            daftarKaryawan.Remove(id);
            Console.WriteLine("DATA BERHASIL DIHAPUS");
        }

        /*
         * Method dibawah digunakan untuk mencari user berdasarkan nama user
         * 
         */
        public static void SearchUser(String name)
        {

            foreach (var item in daftarKaryawan)
            {
                if (item.Value.FirstName.Contains(name) || item.Value.LastName.Contains(name))
                {
                    Console.WriteLine("id : " + item.Key);
                    Console.WriteLine(item.Value.toString());
                }

            }

        }

        // Method dibawah digunakan untuk login
        public static String Login()
        {
            Console.Write("Username : ");
            String userName = Console.ReadLine();
            Console.Write("Password : ");
            String password = Console.ReadLine();

            foreach (var item in daftarKaryawan)
            {
                if (item.Value.Username == userName && item.Value.Password == password)
                {
                    return "Berhasil";
                }


            }
            return "Gagal";


        }


        /*
         * 
         * 
         * Method dibawah digunakan untuk melakukan pengecekan dari input user
         *
         *
         *@PHARAM inputType :   digunakan untuk memilih input berdasarkan field yang ada :
         *                      First Name, Last Name, Password
         */
        private static String InputCheck(String inputType)
        {
            Boolean checkvalidation = true;
            String input ="";

            do
            {
                if (inputType.Equals("First Name : ") || inputType.Equals("Last Name : "))
                {
                    Console.Write(inputType);
                    input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input) || input.Any(Char.IsDigit) || input.Length < 2)
                    {
                        Console.WriteLine("INPUTAN TIDAK FALID");

                    }
                    else
                    {
                        checkvalidation = false;
                    }
                }
                else if (inputType.Equals("Password : "))
                {
                    Console.Write("Password : ");
                    input = Console.ReadLine();
                    if (input.Length < 8 ||
                        !input.Any(Char.IsDigit) ||
                        !input.Any(Char.IsUpper) || !input.Any(Char.IsLower))
                    {
                        Console.WriteLine("PASSWORD MINIMAL MEMILIKI 8 KARAKTER !!");
                        Console.WriteLine("PASSWORD HARUS TERDIRI DARI HURUF BESAR, HURUF KECIL DAN ANGKA");
                    }
                    else
                    {
                        checkvalidation = false;
                    }

                }


            } while (checkvalidation);

            return input;

        }









    }



}
