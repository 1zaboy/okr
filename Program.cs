using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication6
{


    class Program
    {
        class fil
        {
            public void file()
            {

                string string_of_file = File.ReadAllText("file.txt");

                Regex regular1 = new Regex("(0[1-9]|[10-31]){2}:(01|03|05|07|08|10|12):(0[000-999]{3}|1[000-999]{3}|201[0-7]|200[0-9])|(0[1-9]|[10-30]){2}:(04|06|09|11):(0[000-999]{3}|1[000-999]{3}|201[0-7]|200[0-9])|(0[1-9]|[10-28]){2}:(02):(0[000-999]{3}|1[000-999]{3}|201[0-7]|200[0-9])");//
                                                                                                                                                                                                                                                                                                    
                MatchCollection string_of = regular1.Matches(string_of_file);
                if (string_of.Count > 0)
                {
                    using (StreamWriter f = new StreamWriter("file1.txt"))
                    {
                        foreach (Match match in string_of)
                            f.WriteLine(match.Value);
                    }
                }
            }
        }
        class user
        {
            schet[] schet = new schet[1000];
            int tt = 0;
            public void work()
            {
                for (;;)
                {
                    Console.WriteLine("1: добавление счета");
                    Console.WriteLine("2: поиск счета(по имени)");
                    Console.WriteLine("3: сортировка счетов");
                    Console.WriteLine("4: сумма обших накоплений на счетах");
                    Console.WriteLine("5: отобразить все");
                    Console.WriteLine("6: добавления денег");
                    Console.WriteLine("7: уменьшения денег");
                    Console.WriteLine("6: блокировать счет");
                    Console.WriteLine("7: разблокировать счет");
                    int sv1 = Convert.ToInt32(Console.ReadLine());
                    switch (sv1)
                    {
                        case 1:
                            create_schet();
                            break;
                        case 2:
                            poisk();
                            break;
                        case 3:
                            sort_po_many();
                            break;
                        case 4:
                            summa_vseh_schetov();
                            break;
                        case 5:
                            drow();
                            break;
                        case 6:
                            add();
                            break;
                        case 7:
                            delete();
                            break;
                        case 8:
                            addBlok();
                            break;
                        case 9:
                            deleteBlok();
                            break;

                    }
                }
            }
            public void create_schet()
            {
                string name = Console.ReadLine();
                schet[tt] = new schet(name);

                tt++;
            }
            public void add()
            {
                Console.WriteLine("имя");
                string name = Console.ReadLine();
                Console.WriteLine("сумма пополнения");
                int sv = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].name_schet_in_bank == name)
                    {
                        schet[i].add_many(sv);
                        schet[i].drow();
                        break;
                    }
                }

            }
            public void delete()
            {
                Console.WriteLine("имя");
                string name = Console.ReadLine();
                Console.WriteLine("сумма отчисления");
                int sv = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].name_schet_in_bank == name)
                    {
                        schet[i].delete_many(sv);
                        schet[i].drow();
                        break;
                    }
                }
            }
            public void addBlok()
            {
                Console.WriteLine("имя");
                string name = Console.ReadLine();               
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].name_schet_in_bank == name)
                    {
                        schet[i].add_blok();
                        schet[i].drow();
                        break;
                    }
                }

            }
            public void deleteBlok()
            {
                Console.WriteLine("имя");
                string name = Console.ReadLine();               
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].name_schet_in_bank == name)
                    {
                        schet[i].delete_blok();
                        schet[i].drow();
                        break;
                    }
                }
            }
            public void poisk()
            {
                string name = Console.ReadLine();
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].name_schet_in_bank == name)
                    {
                        schet[i].drow();
                        break;
                    }
                }
            }
            public void sort_po_many()
            {
                schet f;
                for (int i = 0; i < schet.Length - 1; i++)
                {
                    if (schet[i + 1] == null) break;
                    if (schet[i].schet_in_bank < schet[i + 1].schet_in_bank)
                    {
                        f = schet[i];
                        schet[i] = schet[i + 1];
                        schet[i + 1] = f;
                    }
                }
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    schet[i].drow();
                }
            }
            public void summa_vseh_schetov()
            {
                double t = 0;
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i] != null && schet[i].blok != false)
                    {
                        t += schet[i].schet_in_bank;
                    }
                }
                Console.WriteLine("Обшая сумма");
                Console.WriteLine(t);
                t = 0;
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].schet_in_bank > 0 && schet[i].blok != false)
                    {
                        t += schet[i].schet_in_bank;
                    }
                }
                Console.WriteLine("Счета на которых положительное количество денег");
                Console.WriteLine(t);
                t = 0;
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    if (schet[i].schet_in_bank < 0 && schet[i].blok != false)
                    {
                        t += schet[i].schet_in_bank;
                    }
                }
                Console.WriteLine("Счета на которых отрецательное количество денег");
                Console.WriteLine(t);
            }
            public void drow()
            {
                for (int i = 0; i < schet.Length; i++)
                {
                    if (schet[i] == null) break;
                    schet[i].drow();
                }
            }
        }
        class schet
        {
            public string name_schet_in_bank;
            public double schet_in_bank;
            public bool blok;
            public schet(string name)
            {
                name_schet_in_bank = name;
                blok = true;
            }
            public void add_many(double many)
            {
                if (blok == true)
                    schet_in_bank += many;
            }
            public void delete_many(double many)
            {
                if (blok == true)
                    schet_in_bank -= many;
            }
            public void add_blok()
            {
                blok = false;
            }
            public void delete_blok()
            {
                blok = true;
            }
            public void drow()
            {
                Console.WriteLine(name_schet_in_bank);
                Console.WriteLine(schet_in_bank);
                Console.WriteLine(blok);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("1: зыдание 1 регулярка");
            Console.WriteLine("2: зыдание 2 счета");
            Console.WriteLine("3: зыдание 3 турестические путевки");
            Console.WriteLine("4: зыдание 4 кредиты");
            int sv = Convert.ToInt32(Console.ReadLine());
            switch(sv)
            {
                case 1:
                    fil f = new fil();
                    f.file();
                    break;
                case 2:
                    user user1 = new user();
                    user1.work();
                    break;
            }

        }
    }
}
