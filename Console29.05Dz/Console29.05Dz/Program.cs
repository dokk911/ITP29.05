using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console29._05Dz
{
    class Boss
    {
        Wizard wizard = new Wizard();

        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int Damage { get; private set; }

        public Boss()
        {
            Name = "Босс";
            Hp = 3000;
            Damage = 30;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Hp} хп");
        }

        public void TakeDamage()
        {
            Hp -= wizard.RashamonDamage;
        }

        public void TakeSuper()
        {
            Hp -= wizard.Super;
        }
    }

    class Wizard
    {
        public string Name { get; private set; }
        public int Hp { get; private set; }
        public int RashamonDamage { get; private set; }
        public int Super { get; private set; }

        private int _riftHeal;
        private bool _isRift;
        private bool _isRashamon;

        public Wizard()
        {
            Name = "Волшебник";
            Hp = 750;
            RashamonDamage = 100;

            Super = 300;
            _riftHeal = 250;
            _isRift = false;
            _isRashamon = false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Hp} хп");
        }

        public void Rashamon()
        {
            _isRashamon = true;
            Hp -= RashamonDamage;
            Console.WriteLine("Рашамон!");
        }

        public void Huganzakura(Boss boss)
        {
            if (_isRashamon == true)
            {
                boss.TakeDamage();
                _isRashamon = false;
                Console.WriteLine("Хуганзакура!");
            }
            else
            {
                Console.WriteLine("Хуганзакура не доступна, создайте духа");
            }
        }

        public void Rift()
        {
            _isRift = true;
            Hp += _riftHeal;
            Console.WriteLine("Рифт!");
        }

        public void SuperDamage(Boss boss)
        {
            boss.TakeSuper();
            Console.WriteLine("Априор!");
        }

        public void TakeDamage(Boss boss)
        {
            if (_isRift != true)
                Hp -= boss.Damage;
            else
                _isRift = false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new Wizard();
            Boss boss = new Boss();

            Console.WriteLine("Q - Призыв теневого духа\nW - Отправляет теневого духа на врага\nE - Помещает игрока в разлом\nR - Наносит супер удар");
            Console.ReadKey();
            Console.Clear();

            while (boss.Hp > 0 && wizard.Hp > 0)
            {
                wizard.ShowInfo();
                boss.ShowInfo();

                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.Clear();

                switch (userInput.Key)
                {
                    case ConsoleKey.Q:
                        wizard.Rashamon();
                        break;
                    case ConsoleKey.W:
                        wizard.Huganzakura(boss);
                        break;
                    case ConsoleKey.E:
                        wizard.Rift();
                        break;
                    case ConsoleKey.R:
                        wizard.SuperDamage(boss);
                        break;
                }

                wizard.TakeDamage(boss);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
