using System.Text.RegularExpressions;

namespace Auth;
class Program
{
    private static void Main(string[] args)
    {
        string username, firstname, lastname, password;
        string inputMenu, search;

        IList<User> userList = new List<User>();

        bool endApp = false;

        while (!endApp)
        {
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Program Autentikasi Abal");
            Console.WriteLine("Debug time: " + DateTime.Now);
            Console.WriteLine("===========================");
            Console.WriteLine("Menu.");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. User List");
            Console.WriteLine("3. Find user");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Exit");
            Console.Write("Your option? ");
            inputMenu = Console.ReadLine();

            switch (inputMenu)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Add user");
                    Console.Write("Firstname: ");
                    firstname = Console.ReadLine();
                    Console.Write("Lastname: ");
                    lastname = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    username = firstname.Substring(0, 2) + lastname.Substring(0, 2);

                    var cek = userList.Where(u => u.Username == username);
                    
                    if (cek.Count() >= 1)
                    {
                        Console.WriteLine("Firstname dan Lastname sudah tersedia");
                    }
                    else
                    {
                        if (password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsNumber))
                        {
                            User user = new User();

                            user.Username = username;
                            user.Firstname = firstname;
                            user.Lastname = lastname;
                            user.Password = password;

                            userList.Add(user);

                            Console.WriteLine("User berhasil ditambah. Tekan sembarang tombol untuk kembali ke halaman utama");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("User gagal ditambah, pastikan panjang password minimal 8, terdapat minimal 1 huruf kapital dan 1 angka");
                            Console.ReadKey();
                        }
                    }
                    
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("List of User(s)");

                    int index = 1;
                    foreach(User u in userList)
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("ID: " + index);
                        Console.WriteLine("Username: " + u.Username);
                        Console.WriteLine("Name: " + u.Firstname + " " + u.Lastname);
                        Console.WriteLine("Password: " + u.Password);
                        index++;
                    }

                    Console.WriteLine("Menu.");
                    Console.WriteLine("1. Edit user");
                    Console.WriteLine("2. Delete user");
                    Console.WriteLine("3. Return to main menu");
                    Console.Write("Your option? ");
                    inputMenu = Console.ReadLine();

                    if (inputMenu == "1")
                    {
                        Console.Write("Masukkan index yang ingin diubah: ");
                        int j = Convert.ToInt32(Console.ReadLine()) - 1;

                        Console.Write("Firstname: ");
                        firstname = Console.ReadLine();
                        Console.Write("Lastname: ");
                        lastname = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();

                        username = firstname.Substring(0, 2) + lastname.Substring(0, 2);

                        var cek2 = userList.Where(u => u.Username == username);

                        if (cek2.Count() != 0)
                        {
                            Console.WriteLine("Firstname dan Lastname sudah tersedia");
                        }
                        else
                        {
                            if (password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsNumber))
                            {
                                userList[j].Username = username;
                                userList[j].Firstname = firstname;
                                userList[j].Lastname = lastname;
                                userList[j].Password = password;

                                Console.WriteLine("User berhasil ditambah. Tekan sembarang tombol untuk kembali ke halaman utama");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("User gagal ditambah, pastikan panjang password minimal 8, terdapat minimal 1 huruf kapital dan 1 angka");
                                Console.ReadKey();
                            }
                        }
                    }
                    else if (inputMenu == "2")
                    {
                        Console.Write("Masukkan index yang ingin dihapus.");
                        int i = Convert.ToInt32(Console.ReadLine()) - 1;
                        userList.RemoveAt(i);
                        Console.WriteLine("Data terkait berhasil dihapus. Tekan sembarang tombol untuk kembali ke halaman utama");
                    }
                    else if (inputMenu == "3")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pilihan tidak tersedia");
                    }

                    Console.ReadKey();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Find User");
                    Console.WriteLine("WARNING: This is case sensitive");
                    Console.Write("Enter firstname: ");
                    search = Console.ReadLine();
                    var hasil = userList.Where(u => u.Firstname == search);
                    foreach (User u in hasil)
                    {
                        Console.WriteLine("Username: " + u.Username);
                        Console.WriteLine("Name: " + u.Firstname + " " + u.Lastname);
                        Console.WriteLine("Password: " + u.Password);
                    }
                    Console.WriteLine("Tekan sembarang kunci untuk kembali ke halaman utama");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Login Page");
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    Console.Write("Password: ");
                    password = Console.ReadLine();

                    var result = userList.SingleOrDefault(u => u.Username == username);
                    if (password == result.Password)
                    {
                        Console.WriteLine("Login berhasil. Tekan sembarang kunci untuk kembali ke halaman utama");
                        Console.ReadKey();
                    }
                                        
                    break;
                case "5":
                    endApp = true;
                    break;
                default:
                    break;
            }
        }       
        
    }
}