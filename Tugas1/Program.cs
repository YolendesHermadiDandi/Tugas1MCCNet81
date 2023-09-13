//Yolendes Hermadi Dandi

using System.Collections.Generic;

namespace Tugas1;

public class program
{


    /*
     * Melakukan eksekusi method yang telah dibuat
     */
    static void Main()
    {
        menu();
    }

    /* Menampilkan Menu
     */
    static void menu()
    {

        Boolean menuLoop = true; //pembatasan looping 

        do
        {

            Console.WriteLine("\n====================================");
            Console.WriteLine("\tMENU GANJIL GENAP");
            Console.WriteLine("====================================");
            Console.WriteLine("Pilih Menu");
            Console.WriteLine("1. Cek Ganjil/Genap");
            Console.WriteLine("2. Cetak Ganjil/Genap (dengan limit)");
            Console.WriteLine("3. Keluar Program");
            Console.Write("Pilih Menu : ");

            String menuSelect = Console.ReadLine(); //scanner
            Console.WriteLine("====================================");
            switch (menuSelect)
            {
                case "1":
                    Console.Write("Masukan bilangan yang ingin diinput : "); // harus angka
                    String input = Console.ReadLine();

                    if (input.All(Char.IsDigit) == true) //cek inputan berupa angka
                    {
                        String cetak = checkEvenOdd(int.Parse(input)); //jalankan method checkEvenOdd
                        Console.WriteLine(cetak);
                  
                    }
                    else
                    {
                        Console.WriteLine("INPUTAN TIDAK FALID !");
                    }

                    break;
                case "2":
                    Console.Write("Pilih (Ganjil/Genap) : ");
                    String choseSelect = Console.ReadLine();
                    Console.Write("masukan Limit : ");
                    String limitInput = Console.ReadLine();

                    if (limitInput.All(Char.IsDigit) == true)
                    {

                        printEvenOdd(int.Parse(limitInput), choseSelect); //Jalankan method printEvenOdd
                    }
                    else
                    {
                        Console.WriteLine("INPUTAN TIDAK FALID !");
                    }
                    break;
                case "3":
                    menuLoop = false;
                    break;
                default:
                    Console.WriteLine("\nPilihan tidak tersedia");
                    break;
            }



        } while (menuLoop); //loop check

    }


    /*
     * ex   : printEvenOdd(10, "ganjil")
     * out  : 1,3,5,7,9
     * ex   : printEvenOdd(10, "genap") (
     * out  : 2,4,6,8,10
     * 
     * @PHARAM choice  : pilihan, hanya boleh "genap" atau "ganjil" <-- boleh dituliskan dengan semua bentuk kelompok
     *                   huruf (uppercase, lowercase, dll)
     * @PHARAM limit   : batas akhir , minimal 1, tidak boleh 0 atau negatif, dan tidak boleh huruf
     */
    static void printEvenOdd(int limit, String choice)
    {
        if (limit < 1)
        {
            Console.WriteLine("LIMIT TIDAK BOLEH KURANG DARI 1 !!!");
            return;
        }

        if (choice.ToLower() != "ganjil" && choice.ToLower() != "genap")
        {
            Console.WriteLine("INPUTAN TIDAK VALID !!!");
            return;
        }

            Console.WriteLine("Bilangan " + choice + " 1 - " + limit + " :");
            for (int i = 1; i <= limit; i++)
            {
                if ( (choice.ToLower().Equals("ganjil") && i % 2 != 0) ||
                    (choice.ToLower().Equals("genap") && i % 2 == 0))
                {
                    Console.Write(i + ", ");
                }

            }
    }

    /*
     * ex   : checkEvenOdd(20) 
     * out  : Genap
     * 
     * ex   : checkEvenOdd (5)
     * out  : ganjil
     * 
     * Note : untuk mencetak nilai hasil method tersebut gunakan fungsi untuk mencetak tulisan / 
     *        nilainya ditampung kedalam variabel yang memiliki tipe data yang sama kemudain dicetak.
     *        
     * @PHARAM  input : Angka yang akan dicek, minimal 1, tidak boleh 0, atau negatif, dan tidak boleh huruf 
     * @RETURN  "Ganjil" jika input angka ganjil, "Genap" jika input angka genap
     * 
     */

    static String checkEvenOdd(int input)
    {
        if (input < 1)
        {
            return "LIMIT TIDAK BOLEH KURANG DARI 1!!!";
        }
        if (input % 2 != 0)
        {
            return "Ganjil";
        }
        return "Genap";

    }
}