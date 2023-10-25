using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponTask.Models
{
    internal class Weapon
    {
        bool _isValid = true;
        public bool IsValid { get => _isValid; 
            set
            {
               _isValid = value;
            } 
        }
        double _clipSize;
        public double ClipSize { get => _clipSize; 
            set
            {
                if (value < 0)
                {
                    _isValid = false;
                    Console.WriteLine("Enter a valid clip size!");
                    return;
                }
                _clipSize = value;
            }
        }
        double _bulletCount;
        public double BulletCount { get =>_bulletCount; 
            set
            {
                if (BulletCount < 0 || BulletCount > ClipSize)
                {
                    IsValid = false;
                    Console.WriteLine("Enter a valid bullet count!");
                    return;
                }
                _bulletCount = value;
            } 
        }
        double _dischargeSeconds;
        public double DischargeSeconds { get=> _dischargeSeconds; 
            set
            {
                if (value < 0)
                {
                    IsValid = false;
                    Console.WriteLine("Enter a valid seconds for discharge!");
                    return;
                }
                _dischargeSeconds = value;
            } 
        }
        string _shootMode;
        public string ShootMode { get=> _shootMode; 
            set
            {
                if (!(value == "auto" || value == "single"))
                {
                    IsValid = false;
                    Console.WriteLine("Enter a valid bullet count!");
                    return;
                }
                _shootMode = value;
            }
        }

        public void Shoot()
        {
            Console.WriteLine("Shooted with one bullet");
            BulletCount--;
        }

        public void Fire()
        {
            if (ShootMode == "auto")
            {
                Console.WriteLine($"Clip became empty in {(BulletCount/ClipSize)*DischargeSeconds} seconds");
                BulletCount = 0;
                return;
            }
            Console.WriteLine("Shooted with one bullet");
            BulletCount--;
        }

        public double GetNeededBulletCount ()
        {
            return ClipSize - BulletCount;
        }

        public void Reload()
        {
            BulletCount = ClipSize;
        }

        public void ChangeFireMode()
        {
            if ( ShootMode == "auto" )
            {
                ShootMode = "single";
            } else if ( ShootMode == "single")
            {
                ShootMode = "auto";
            }
        }

        public override string ToString()
        {
            return $"Clipsize of your weapon:{ClipSize}, Your current bullet count: {BulletCount}, Full clip becomes empty in {DischargeSeconds}, Current shoot mode: {ShootMode}";
        }

        public Weapon ()
        {
            Console.WriteLine("Set clip size:");
            ClipSize = Convert.ToInt32(Console.ReadLine());
            //if (IsValid == false)
            //{
            //    return;
            //}
            Console.WriteLine("Set your bullet count:");
            BulletCount = Convert.ToInt32(Console.ReadLine());
            if (IsValid == false)
            {
                return;
            }
            Console.WriteLine("Set seconds for discharge: ");
            DischargeSeconds = Convert.ToInt32(Console.ReadLine());
            if (IsValid == false)
            {
                return;
            }
            Console.WriteLine("Set fire mode(auto/single):");
            ShootMode = Console.ReadLine().ToLower();
            if (IsValid == false)
            {
                return;
            }
        }
     }
}
