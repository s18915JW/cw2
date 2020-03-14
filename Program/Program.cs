using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // default paths and format
            string
                logPath = @"C:\Users\User\Desktop\log.txt",
                csvLoc = @"Data\dane.csv",
                resLoc = @"C:\Users\User\Desktop\wynik.xml",
                format = "xml";

            if (args.Length == 3)
            {
                csvLoc = "@" + args[0];
                resLoc = "@" + args[1];
                format = args[2];
            }

            using (StreamWriter writer = new StreamWriter(logPath))
            {
                try
                {
                    var data = File.ReadAllLines(csvLoc);                       // data read from *.csv file
                    var correctStudents = new HashSet<Student>(new Comparer()); // set for students

                    foreach (var line in data)
                    { 
                        string[] StudentInfo = line.Split(","); // info

                        // check if there is enough info
                        if (StudentInfo.Length != 9)
                        {
                            writer.WriteLine("Length != 9: \t" + DateTime.Now + "\t" + line);   // to log
                        }
                        else
                        {
                            // check if there are blanks
                            bool isValid = true;
                            foreach (var information in StudentInfo)
                            {
                                if (string.IsNullOrWhiteSpace(information) || string.IsNullOrEmpty(information))
                                {
                                    writer.WriteLine("Blank: \t\t" + DateTime.Now + "\t" + line);   // to log
                                    isValid = false;
                                }
                            }

                            // save correct info to set
                            if (isValid)
                            {
                                var stud = (new Student
                                {
                                    fname = StudentInfo[0],
                                    lname = StudentInfo[1],
                                    indexNumber = "s" + StudentInfo[4],
                                    birthdate = StudentInfo[5],
                                    email = StudentInfo[6],
                                    mothersName = StudentInfo[7],
                                    fathersName = StudentInfo[8],
                                    studies = (new Study
                                    {
                                        name = StudentInfo[2],
                                        mode = StudentInfo[3]
                                    })
                                });

                                if (!correctStudents.Add(stud))
                                {
                                    writer.WriteLine("Duplicate: \t" + DateTime.Now + "\t" + line); // to log
                                }
                            }
                        }
                    }
                    
                    // getting active studies + sort by number of students
                    var activeStudies = ExtractStudies(correctStudents);
                    activeStudies.Sort();

                    // university for xml and others
                    University university = new University
                    {
                        students = correctStudents,
                        activeStudies = activeStudies
                    };
                 
                    // write to xml and json
                    FileStream fw = new FileStream(resLoc, FileMode.Create);
                    if (format.Equals("xml"))
                    {
                        var serializer = new XmlSerializer(typeof(University));
                        serializer.Serialize(fw, university);
                        fw.Dispose();
                    }
                    else if (format.Equals("json"))
                    {
                        StreamWriter jsonWriter = new StreamWriter(fw);
                        jsonWriter.Write(JsonConvert.SerializeObject(university));
                        jsonWriter.Dispose();
                    }
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Plik " + csvLoc + " nie istnieje");
                    writer.WriteLine(DateTime.Now + "\tPlik: " + csvLoc + " nie istnieje");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Podana ścieżka: " + csvLoc + " jest niepoprawna");
                    writer.WriteLine(DateTime.Now + "\tPodana sciezka:" + csvLoc + " jest niepoprawna");
                }
            }
        }

        public static List<ActiveStudy> ExtractStudies(HashSet<Student> hash)
        {
            // courses
            List<string> all = new List<string>();
            foreach (Student student in hash)
            {
                all.Add(student.studies.name);
            }
            HashSet<string> WithoutDuplicates = new HashSet<string>(all);

            // counting for each of them number of students
            List<ActiveStudy> active = new List<ActiveStudy>();
            foreach (string course in WithoutDuplicates)
            {
                int counter = 0;
                foreach (Student student in hash)
                {
                    if (course.Equals(student.studies.name))
                    {
                        counter++;
                    }
                }
                active.Add(new ActiveStudy
                {
                    studiesName = course,
                    numberOfStudents = counter
                });
            }
            return active;
        }

    }
}