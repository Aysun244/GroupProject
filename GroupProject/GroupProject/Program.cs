using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;


namespace GroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            static List<Group> groups = new List<Group>();
            static string filePath = "data.json";

            static void Main(string[] args)
            {
                LoadData();
                MainMenu();
            }

            static void MainMenu()
            {
                while (true)
                {
                    Console.Write("Seçiminizi edin: ");
                    Console.Write("_________________");
                    Console.Write("1. Qruplara bax");
                    Console.Write("2. Qrup yarat");
                    Console.Write("3. Qrup sil");
                    Console.Write("4. Qrupa keç");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ViewGroups();
                            break;
                        case "2":
                            CreateGroup();
                            break;
                        case "3":
                            DeleteGroup();
                            break;
                        case "4":
                            SwitchGroup();
                            break;
                        default:
                            Console.WriteLine("Yanlış seçim, yenidən cəhd edin.");
                            break;
                    }
                }
            }

            static void ViewGroups()
            {
                foreach (var group in groups)
                {
                    Console.WriteLine($"Qrup: {group.Name}");
                }
            }

            static void CreateGroup()
            {
                Console.Write("Qrup adını daxil edin: ");
                var groupName = Console.ReadLine();
                groups.Add(new Group { Name = groupName });
                SaveData();
            }

            static void DeleteGroup()
            {
                Console.Write("Silinəcək qrup adını daxil edin: ");
                var groupName = Console.ReadLine();
                groups.RemoveAll(g => g.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase));
                SaveData();
            }

            static void SwitchGroup()
            {
                Console.Write("Keçmək istədiyiniz qrup adını daxil edin: ");
                var groupName = Console.ReadLine();
                var group = groups.Find(g => g.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase));

                if (group != null)
                {
                    GroupMenu(group);
                }
                else
                {
                    Console.WriteLine("Qrup tapılmadı.");
                }
            }

            static void GroupMenu(Group group)
            {
                while (true)
                {
                    Console.Write("Seçiminizi edin: ");
                    Console.Write("_________________");
                    Console.Write("1. Tələbə əlavə et");
                    Console.Write("2. Tələbəni sil");
                    Console.Write("3. Geri qayıt");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent(group);
                            break;
                        case "2":
                            RemoveStudent(group);
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Yanlış seçim, yenidən cəhd edin.");
                            break;
                    }
                }
            }

            static void AddStudent(Group group)
            {
                var student = new Student();
                Console.Write("Tələbə kodunu daxil edin: ");
                student.Code = Console.ReadLine();
                Console.Write("Tələbə adını daxil edin: ");
                student.Name = Console.ReadLine();
                Console.Write("Tələbə soyadını daxil edin: ");
                student.Surname = Console.ReadLine();
                Console.Write("Tələbə yaşını daxil edin: ");
                student.Age = int.Parse(Console.ReadLine());
                group.Students.Add(student);
                SaveData();
            }

            static void RemoveStudent(Group group)
            {
                Console.Write("Silinəcək tələbə kodunu daxil edin: ");
                var studentCode = Console.ReadLine();
                group.Students.RemoveAll(s => s.Code.Equals(studentCode, StringComparison.OrdinalIgnoreCase));
                SaveData();
            }

            static void LoadData()
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    groups = JsonConvert.DeserializeObject<List<Group>>(json);
                }
            }

            static void SaveData()
            {
                var json = JsonConvert.SerializeObject(groups, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
        }
    }
}