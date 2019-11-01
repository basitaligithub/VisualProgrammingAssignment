using System;
using System.IO;

namespace VisualProgrammingAssignment
{
    class Program
    {
        static int? searchstudentbyname(string sname, string[] namearray)       //ssearch by name
        {
            int? found = null;
            for (int k=0; k<namearray.Length; k++)
            {
                if (namearray[k]==sname)
                {
                    found = k;
                }
            }
            return found;
        }
        static int? searchstudentbyID(string sID, string[] IDarray)             //ssearch by ID
        {
            int? found1 = null;
            for (int k = 0; k < IDarray.Length; k++)
            {
                if (IDarray[k] == sID)
                {
                    found1 = k;
                }
            }
            return found1;
        }
        static int? deletebyname(string dname, string[] dnameArray)             //Delete by name
        {
            int? found2 = null;
            for (int k = 0; k < dnameArray.Length; k++)
            {
                if (dnameArray[k] == dname)
                {
                    found2 = k;
                }
            }
            return found2;
        }
        static int? deletebyID(string dID, string[] dIDArray)                   //Delete by ID
        {
            int? found3 = null;
            for (int k = 0; k < dIDArray.Length; k++)
            {
                if (dIDArray[k] == dID)
                {
                    found3 = k;
                }
            }
            return found3;
        }
        static void top3students(double[] abc, string[] xyz)                   //Top 3 students
        {
            double[] test = new double[50];

            for (int c=0; c<abc.Length; c++)
            {
                test[c] = abc[c];
            }

            Array.Sort(test);

            string topstudent = "";
            string secondStudent = "";
            string thirdStudent = "";
            double max1, max2, max3;
            max1 = max2 = max3 = 0;

            for (int d= test.Length - 1; d>=0; d--)
            {
                if (test[d]!=0)
                {
                    max1 = test[d];
                    max2 = test[d - 1];
                    max3 = test[d - 2];
                    break;
                }
            }
            for (int e=0; e<abc.Length; e++)
            {
                if (abc[e]==max1)
                {
                    topstudent = xyz[e];
                }
                else if (abc[e]==max2)
                {
                    secondStudent = xyz[e];
                }
                else if (abc[e] == max3)
                {
                    thirdStudent = xyz[e];
                }
            }
            Console.WriteLine("\nTop Student: "+topstudent+" ("+max1+")\nSecond Student: "+ secondStudent+" (" + max2 + ")\nThird Student: "+thirdStudent + " (" + max3+")");
        }
        static void Main(string[] args)
        {
            string textfilepath = @"C:\Users\basit\source\repos\VisualProgrammingAssignment\studentData.txt";
            string textfilepath1 = @"C:\Users\basit\source\repos\VisualProgrammingAssignment\StudentAttendance.txt";

            string[] name = new string[50];
            string[] id = new string[50];
            double[] cgpa = new double[50];
            string[] semester = new string[50];
            string[] department = new string[50];
            string[] university = new string[50];
            string[] attendance = new string[50];

            //reading student data file and putting the values into arrays

            StreamReader newfile = new StreamReader(textfilepath);

            int m = 0;
            while(!newfile.EndOfStream)
            {
                name[m] = newfile.ReadLine();
                id[m] = newfile.ReadLine();
                cgpa[m] = Convert.ToDouble(newfile.ReadLine());
                semester[m] = newfile.ReadLine();
                department[m] = newfile.ReadLine();
                university[m] = newfile.ReadLine();
                m++;
            }
            newfile.Close();

            //reading students attendance file and putting the values into attendance array

            StreamReader newfile1 = new StreamReader(textfilepath1);

            int n = 0;
            while(!newfile1.EndOfStream)
            {
                attendance[n] = newfile1.ReadLine();
                n++;
            }
            newfile1.Close();


            //--------------Start of menu-----------------//
            string choice;
            char choice4;
            do
            {
                Console.Clear();

                Console.WriteLine("---------------Main menu---------------\n");
                Console.WriteLine("1. Create Student profile");
                Console.WriteLine("2. Search Student data");
                Console.WriteLine("3. Delete student record");
                Console.WriteLine("4. List top 3 of class");
                Console.WriteLine("5. Mark Student Attendance");
                Console.WriteLine("6. View attendance report");
                choice = Console.ReadLine();
                Console.Clear();
                if (choice == "1")
                {
                    Console.WriteLine("How many records do you want to add?\n");
                    int number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-------------------Profile details-------------------");
                    for (int i = 0; i < number; i++)
                    {
                        Console.WriteLine("\nRecord number: {0} ", i + 1);
                        Console.Write("\nEnter your name: ");
                        name[i] = Console.ReadLine();
                        Console.Write("\nEnter your ID: ");
                        id[i] = Console.ReadLine();
                        Console.Write("\nEnter your CGPA: ");
                        cgpa[i] = Convert.ToDouble(Console.ReadLine());
                        Console.Write("\nEnter your semester: ");
                        semester[i] = Console.ReadLine();
                        Console.Write("\nEnter your department: ");
                        department[i] = Console.ReadLine();
                        Console.Write("\nEnter your university: ");
                        university[i] = Console.ReadLine();
                        Console.Write("\nThe new profile has been created and added into the system\n");

                        //writing the data from arrays into file
                        using (StreamWriter writer = File.AppendText(textfilepath))
                        {
                            writer.WriteLine(name[i]);
                            writer.WriteLine(id[i]);
                            writer.WriteLine(cgpa[i]);
                            writer.WriteLine(semester[i]);
                            writer.WriteLine(department[i]);
                            writer.WriteLine(university[i]);
                        }
                        newfile.Close();
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("1. Search by name");
                    Console.WriteLine("2. Search by ID");
                    Console.WriteLine("3. List all students");
                    string choice1 = Console.ReadLine();
                    if (choice1 == "1")
                    {
                        Console.Write("\nEnter the name of the student: ");
                        string searchname = Console.ReadLine();
                        int? tr = searchstudentbyname(searchname, name);
                        if (tr == null)
                        {
                            Console.WriteLine("\nNo record found for this name");
                        }
                        else
                        {
                            Console.WriteLine("--------------Student Details---------------\n");
                            Console.WriteLine("Name: " + name[Convert.ToInt32(tr)]);
                            Console.WriteLine("ID: " + id[Convert.ToInt32(tr)]);
                            Console.WriteLine("CGPA: " + cgpa[Convert.ToInt32(tr)]);
                            Console.WriteLine("Semester: " + semester[Convert.ToInt32(tr)]);
                            Console.WriteLine("Department: " + department[Convert.ToInt32(tr)]);
                            Console.WriteLine("University: " + university[Convert.ToInt32(tr)]);
                        }
                    }
                    else if (choice1 == "2")
                    {
                        Console.Write("\nEnter the ID of the student: ");
                        string searchID = Console.ReadLine();
                        int? tr1 = searchstudentbyID(searchID, id);
                        if (tr1 == null)
                        {
                            Console.WriteLine("\nNo record found for this ID");
                        }
                        else
                        {
                            Console.WriteLine("--------------Student Details---------------\n");
                            Console.WriteLine("Name: " + name[Convert.ToInt32(tr1)]);
                            Console.WriteLine("ID: " + id[Convert.ToInt32(tr1)]);
                            Console.WriteLine("CGPA: " + cgpa[Convert.ToInt32(tr1)]);
                            Console.WriteLine("Semester: " + semester[Convert.ToInt32(tr1)]);
                            Console.WriteLine("Department: " + department[Convert.ToInt32(tr1)]);
                            Console.WriteLine("University: " + university[Convert.ToInt32(tr1)]);
                        }
                    }
                    else if (choice1 == "3")
                    {
                        Console.WriteLine("------------------All Students-----------------\n");
                        for (int a = 0; a < name.Length; a++)
                        {
                            if (name[a] != null)
                            {
                                Console.WriteLine("Name: " + name[a]);
                                Console.WriteLine("ID: " + id[a]);
                                Console.WriteLine("CGPA: " + cgpa[a]);
                                Console.WriteLine("Semester: " + semester[a]);
                                Console.WriteLine("Department: " + department[a]);
                                Console.WriteLine("University: " + university[a]);
                            }
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("-----------------Deleting Student's Record-----------------\n");
                    Console.WriteLine("1. Delete by name");
                    Console.WriteLine("2. Delete by ID\n");
                    Console.Write("\nEnter your choice: ");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "1")
                    {
                        Console.Write("Enter the name of the student: ");
                        string deletename = Console.ReadLine();
                        int? index = deletebyname(deletename, name);

                        if (index == null)
                        {
                            Console.WriteLine("\nNo record found for this name to be deleted\n");
                        }
                        else
                        {
                            name[Convert.ToInt32(index)] = null;
                            id[Convert.ToInt32(index)] = null;
                            cgpa[Convert.ToInt32(index)] = 0;
                            semester[Convert.ToInt32(index)] = null;
                            department[Convert.ToInt32(index)] = null;
                            university[Convert.ToInt32(index)] = null;
                            attendance[Convert.ToInt32(index)] = null;
                            Console.WriteLine("\nThe record for this name has been deleted!");
                        }
                    }
                    else if (choice2 == "2")
                    {
                        Console.Write("Enter the ID of the student: ");
                        string deleteID = Console.ReadLine();
                        int? index1 = deletebyname(deleteID, id);

                        if (index1 == null)
                        {
                            Console.WriteLine("\nNo record found for this ID to be deleted\n");
                        }
                        else
                        {
                            name[Convert.ToInt32(index1)] = null;
                            id[Convert.ToInt32(index1)] = null;
                            cgpa[Convert.ToInt32(index1)] = 0;
                            semester[Convert.ToInt32(index1)] = null;
                            department[Convert.ToInt32(index1)] = null;
                            university[Convert.ToInt32(index1)] = null;
                            attendance[Convert.ToInt32(index1)] = null;
                            Console.WriteLine("\nThe record for this ID has been deleted!");
                        }
                    }

                    File.WriteAllText(textfilepath, String.Empty);
                    for (int b = 0; b < name.Length; b++)
                    {
                        if (name[b] != null)
                        {
                            using (StreamWriter writer = File.AppendText(textfilepath))
                            {
                                writer.WriteLine(name[b]);
                                writer.WriteLine(id[b]);
                                writer.WriteLine(cgpa[b]);
                                writer.WriteLine(semester[b]);
                                writer.WriteLine(department[b]);
                                writer.WriteLine(university[b]);
                            }
                            newfile.Close();

                        }
                    }
                    File.WriteAllText(textfilepath1, String.Empty);
                    for (int ab=0; ab<attendance.Length; ab++)
                    {
                        if (name[ab]!=null)
                        {
                            using (StreamWriter writer = File.AppendText(textfilepath1))
                            {
                                writer.WriteLine(attendance[ab]);
                            }
                            newfile1.Close();
                        }
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("------------------Top 3 Students-----------------");
                    top3students(cgpa, name);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("--------------------Attendance Marking----------------------\n");
                    for (int f = 0; f < name.Length; f++)
                    {
                        if (name[f] != null)
                        {
                            Console.Write("Name: " + name[f] + " | ID: " + id[f] + " | Attendance: ");
                            attendance[f] = Console.ReadLine();
                        }
                    }
                    File.WriteAllText(textfilepath1, String.Empty);
                    for (int g = 0; g < attendance.Length; g++)
                    {
                        if (attendance[g] != null)
                        {
                            using (StreamWriter writer = File.AppendText(textfilepath1))
                            {
                                writer.WriteLine(attendance[g]);
                            }
                            newfile1.Close();
                        }
                    }
                }
                else if (choice == "6")
                {
                    Console.WriteLine("-----------------Attendance Report------------------\n");

                    for (int h = 0; h < attendance.Length; h++)
                    {
                        if (name[h] != null)
                        {
                            Console.WriteLine("Name: " + name[h] + " | ID: " + id[h] + " | Attendance: " + attendance[h]);
                        }
                    }
                }
                Console.WriteLine("\nDo you want to go to Start Menu again? (Y/N) ");
                choice4 = Convert.ToChar(Console.ReadLine());

            }
            while (choice4 == 'Y' || choice4 == 'y');

            Console.ReadKey();
        }
    }
}
