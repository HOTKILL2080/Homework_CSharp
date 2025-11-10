using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIf1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count_question = 0;
            Console.WriteLine("WELCOME. это тест который определит насколько хорошо ты разбераешься в механиках и прочих вещях некоторых игр.\nТест состоит из 3-х уровней чтобы пройти на следующий уровень нужно правильно ответить на 50% вопросов.\nДля того чтобы ответить жмай 1(Да) или 2(Нет). \nВперёд.");
            Console.WriteLine("\nПродолжить");
            Console.WriteLine("1 - ДА\n2 - НЕТ\n");
            var key = Console.ReadKey(true);
            if (key.KeyChar == '1')
            {
                Console.WriteLine("Уровень - 1 \nСложность - Easy\n");

                Console.WriteLine("Вопрос 1:");
                Console.WriteLine("Можно ли в Terraria прыгать?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 2:");
                Console.WriteLine("У игрока в Minecraft 10HP?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '2')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 3:");
                Console.WriteLine("ARK: Survival Evolved - это игра про динозавров и выживание?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 4:");
                Console.WriteLine("Можно ли в Deep Rock Galactic пить пиво?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 5:");
                Console.WriteLine("Маркус Перссон (Notch) создал игру под названием Dota 2 в 2010году?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '2')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 6:");
                Console.WriteLine("В Buckshot Roulette есть ли вид патрона - Холостой?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 7:");
                Console.WriteLine("Главный герой Hollow Knight это - Рыцарь?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 8:");
                Console.WriteLine("Учитель Baldi из игры Baldi's Basics держит в левой руке АК-47?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '2')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 9:");
                Console.WriteLine("Cyberpunk 2077 была создана в 2077 году?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '2')
                {
                    count_question++;
                }
                Console.WriteLine("Вопрос 10:");
                Console.WriteLine("Если персонаж в Darkest Dungeon накопил 200 стресса он умирает от разрыва сердца?");
                Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    count_question++;
                }
                if (count_question >= 5)
                {
                    Console.WriteLine("Позвравляю вы перешли на уровень - 2\nСложность - Medium\n");
                    Console.WriteLine("Вопрос 11:");
                    Console.WriteLine("Маяк в игре Minecraft крафтится из: 3 - Стекла, 1 - Звезда Незера, 5 - Обсидиан");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 12:");
                    Console.WriteLine("В Terraria аксессуар Теработинки можно скрафтить до Hard-mode?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 13:");
                    Console.WriteLine("Можно ли вылечить ожог у игрока Barotrauma при помощи бинт?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 14:");
                    Console.WriteLine("Мужика со сломаными ногами и черном костюме из Library Of Ruina зовут Олег?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 15:");
                    Console.WriteLine("В Mortal Kombat 11 есть персонаж по имени Ghost face?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 16:");
                    Console.WriteLine("Убивает ли Derranger в голову в игре Hunt: ShowDown 1896?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 17:");
                    Console.WriteLine("Есть ли в Nuclear Throne пистолет стреляющий автобусами?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 18:");
                    Console.WriteLine("Может ли Рассеиватель изпользовать торий в игре Mindustry?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 19:");
                    Console.WriteLine("The Escapists - игра в которой нужно строить тюрьму и следить за порядком?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 20:");
                    Console.WriteLine("Хранитель имеет самое большое количество HP в Minecraft?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 21:");
                    Console.WriteLine("Может ли морбузин в Barotrauma вылечить эффект - галюцинации?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 22:");
                    Console.WriteLine("Есть ли в Rust боеприпас - высокоскоростная стрела?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        count_question++;
                    }
                    Console.WriteLine("Вопрос 23:");
                    Console.WriteLine("Предмет Hand of Midas из Dota 2 крафтится из: Gloves of Haste, Crown, Gauntlets of Strength?");
                    Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                    key = Console.ReadKey(true);
                    if (key.KeyChar == '2')
                    {
                        count_question++;
                    }
                    if (count_question >= 15)
                    {
                        Console.WriteLine("Позвравляю вы перешли на уровень - 3\nСложность - Hard\n");
                        Console.WriteLine("Вопрос 24:");
                        Console.WriteLine("В Satisfactory можно создать монитор?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '2')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 25:");
                        Console.WriteLine("Можно ли использовать Золотую Сковороду всем классам в Team Fortress 2?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '1')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 26:");
                        Console.WriteLine("Можно ли давать Фентанил игроку в Barotrauma у которого эффекты: кровотечение, нехватка кислорода, ожог?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '2')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 27:");
                        Console.WriteLine("Локомотив с тяжелым атомным двигателем может ли этот локомотив ташить больше 7 вагонов в игре Unrailed?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '1')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 28:");
                        Console.WriteLine("Максимальный ли 2-й тир оружие Дундр в Valheim?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '2')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 29:");
                        Console.WriteLine("Морфин в игре Barotrauma может вылечить ожог у игрока?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '1')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 30:");
                        Console.WriteLine("Можно ли скрафтить максимальный сок в игре Starbound?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '1')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 31:");
                        Console.WriteLine("Хватит ли машине 60км/ч чтобы срубить дерево в игре Unturned?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '1')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 32:");
                        Console.WriteLine("Первый уровень в A dance of Fire and Ice называется Welcome?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '2')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Вопрос 33:");
                        Console.WriteLine("\nНу ладно последний вопрос по баре\nВылечит ли хлоральгидрат в Barotrauma игрока у которого: лучевая болезнь, заражение паразитами?");
                        Console.WriteLine("1 - ДА\n2 - НЕТ\n");
                        key = Console.ReadKey(true);
                        if (key.KeyChar == '2')
                        {
                            count_question++;
                        }
                        Console.WriteLine("Ответ нет теперь у него паралич\n");
                    }
                }
            }
            Console.WriteLine("Количество правильных ответов: " + count_question.ToString());
            Console.ReadKey();
        }
    }
}
