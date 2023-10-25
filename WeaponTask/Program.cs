using System.Threading.Channels;
using WeaponTask.Models;

namespace WeaponTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Weapon[] weapons = new Weapon[1];
            while (isRunning)
            {
                Console.WriteLine("Press:");
                Console.WriteLine("g - create a new weapon");
                Console.WriteLine("0 - get information about the current weapon");
                Console.WriteLine("1 - shoot");
                Console.WriteLine("2 - fire");
                Console.WriteLine("3 - get remaining bullet count");
                Console.WriteLine("4 - reload");
                Console.WriteLine("5 - change fire mode");
                Console.WriteLine("6 - terminate");

                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                

                switch (key)
                {
                    case 'g':
                        weapons[0] = new Weapon();
                        if (weapons[0].IsValid == false)
                        {
                            break;
                        }
                        Console.WriteLine("New weapon created.");
                        break;
                    case '0':
                        Console.WriteLine(weapons[0]);
                        break;
                    case '1':
                        weapons[0].Shoot();
                        break;
                    case '2':
                        weapons[0].Fire();
                        break;
                    case '3':
                        Console.WriteLine(weapons[0].GetNeededBulletCount());
                        break;
                    case '4':
                        weapons[0].Reload();
                        break;
                    case '5':
                        weapons[0].ChangeFireMode();
                        Console.WriteLine($"New shoot mode is {weapons[0].ShootMode}");
                        break;
                    case '6':
                        isRunning = false;
                        Console.WriteLine("Terminating...");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
