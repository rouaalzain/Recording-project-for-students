using System;

namespace Tic_F23_IPG202
{
    class Program
    {
        // لتعريف اسماء الطلاب
        static string[,] Students = new string[7, 7];
        //لتعريف البرامج
        static string[] ProgramList = { "BIT", "BAIT", "TIC" };
        //لتعريف المواد
        static string[] CourseList = { "IPG101", "IPG201", "IPG202", "IPG203" };
        //مصفوفة للاحصائية الاجمالية
        static int[,] CourseCount = new int[4, 3];

        static void Main(string[] args)
        {
            //الواجهة الرئيسية
            DisplayHomepage();
        }

        static void DisplayHomepage()
        {
            Console.WriteLine("SVU – Students and Courses Registration System");
            Console.WriteLine("Choice an Operation:");
            Console.WriteLine("1 : Register Student and Courses");
            Console.WriteLine("2 : Edit Student and Courses");
            Console.WriteLine("3 : Print Students and Courses List");
            Console.WriteLine("4 : Print Students and Courses Ordered List");
            Console.WriteLine("5 : Students in Course and Program");
            Console.WriteLine("6 : Print Global Summary");
            Console.WriteLine("7 : Exit");
            //اختيار المستخدم ماذا يريد ان يفعل
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    //تسجيل طالب في النظام واختيار المقررات التي يرغب بالتسجيل عليها
                    RegisterStudentAndCourses();
                    break;
                case "2":
                    // البحث عن طالب وفي حال وجوده تعديل المقررات المسجلة من قبله
                    EditStudentAndCoursesRegistration();
                    break;
                case "3":
                    //  طباعة قائمة تتضمن أسماء الطالب وبرامجهم مع سجل يبين حالة تسجيل الطالب على  المقررات
                    
                    PrintStudentsAndCoursesList();
                    break;
                case "4":
                    // طباعة قائمة  بحيث تكون النتائج مرتبة حسب  الاكثر تسجيلا على المقررات
                  
                    PrintStudentsAndCoursesOrderedList();
                    break;
                case "5":
                    // طباعة قائمة بأسماء الطلاب المسجلين على مقرر معين من برنامج معين
                    DisplayStudentsInCourseAndProgram();
                    break;
                case "6":
                    //طباعة إحصائية تتضمن أعداد الطلاب المسجلين على كل مقرر في كل برنامج
                    PrintGlobalSummary();
                    break;
                case "7":
                    //للخروج من البرنامج
                    ExitProgram();
                    break;
                default:
                    //العودةالى الواجهة الاساسية
                    Console.WriteLine("The option is not available");
                    DisplayHomepage();
                    break;
            }
        }

        

        static void RegisterStudentAndCourses()
        {
            Console.WriteLine("Register Student and Courses:");
            Console.Write("Student Name:");
            //ادخال اسم الطالب
            string studentName = Console.ReadLine();
            for (int i = 0; i < Students.GetLength(0); i++)
            {
                //شرط لتكون المصفوفة فارغة
                if (Students[i, 0] == null)
                {
                    //اسناد اسم الطالب الى المصفوفة
                    Students[i, 0] = studentName;
                    Console.Write("Choice Program (0=>BIT, 1=>BAIT, 2=>TIC): ");
                    //ادخال البرنامج المراد التسحيل به
                    string programChoice = Console.ReadLine();
                    switch (programChoice)
                    {
                        case "0":
                            //اسناد اسم البرنامج الى المصفوفة
                            Students[i, 1] = ProgramList[0];
                            //طريقة لمعرفة المواد التي يريد ان يسجل الطالب بها
                            RegisterCourses(i);
                            break;
                        case "1":
                            Students[i, 1] = ProgramList[1];
                            RegisterCourses(i);
                            break;
                        case "2":
                            Students[i, 1] = ProgramList[2];
                            RegisterCourses(i);
                            break;
                        default:
                            Console.WriteLine("Sorry, not found this Program");
                            RegisterStudentAndCourses();
                            break;
                    }
                    Console.Write("Student Registered Successfully, register another (yes,no): ");
                    string registerAnother = Console.ReadLine();
                    switch (registerAnother)
                    {
                        case "y":
                            RegisterStudentAndCourses();
                            break;
                        case "n":
                            Console.WriteLine("==============OK===============");
                            DisplayHomepage();
                            break;
                        default:
                            DisplayHomepage();
                            break;
                    }
                    break;
                }
            }
        }
        //طريقة لمعرفة المواد التي يريد ان يسجل الطالب بها
        static void RegisterCourses(int i)
        {
            int courseCount = 0;
            //IPG101سؤال الطالب اذا كان يرغب بالتسجيل على مادة 
            Console.Write("Register IPG101 (yes,no): ");
            string registerIPG101 = Console.ReadLine();
            switch (registerIPG101)
            {
                case "y":
                    Students[i, 2] = CourseList[0];
                    courseCount++;
                    break;
                case "n":
                    Students[i, 2] = "";
                    break;
            }
            //IPG201سؤال الطالب اذا كان يرغب بالتسجيل على مادة 
            Console.Write("Register IPG201 (yes,no): ");
            string registerIPG201 = Console.ReadLine();
            switch (registerIPG201)
            {
                case "y":
                    Students[i, 3] = CourseList[1];
                    courseCount++;
                    break;
                case "n":
                    Students[i, 3] = "";
                    break;
            }
            //IPG202سؤال الطالب اذا كان يرغب بالتسجيل على مادة 
            Console.Write("Register IPG202 (yes,no): ");
            string registerIPG202 = Console.ReadLine();
            switch (registerIPG202)
            {
                case "y":
                    Students[i, 4] = CourseList[2];
                    courseCount++;
                    break;
                case "n":
                    Students[i, 4] = "";
                    break;
            }
            //IPG203سؤال الطالب اذا كان يرغب بالتسجيل على مادة 
            Console.Write("Register IPG203 (yes,no): ");
            string registerIPG203 = Console.ReadLine();
            switch (registerIPG203)
            {
                case "y":
                    Students[i, 5] = CourseList[3];
                    courseCount++;
                    break;
                case "n":
                    Students[i, 5] = "";
                    break;
            }
            
            //وضع عدد المواد في كل سطر من العامود السادس
            Students[i, 6] = Convert.ToString(courseCount);
        }
        //طريقة ل تعديل المقررات المسجلة
        static void EditStudentAndCoursesRegistration()
        {
            Console.WriteLine("Edit Student and Courses Registration: ");
            //البحث عن اسم الطالب
            Console.Write("Search Student Name: ");
            string studentName = Console.ReadLine();
            for (int i = 0; i < Students.GetLength(0); i++)
            {// شرط ان يكون اسم الطالب يساوي القيمة التي في المصفوفة 
                if (studentName == Students[i, 0])
                {

                    ModifyRegisteredCourses(i);
                    //تحديث المقررات
                    Console.Write("Student Updated Successfully, Update another (yes,no): ");
                    
                    string updateAnother = Console.ReadLine();
                    switch (updateAnother)
                    {
                        case "y":
                            EditStudentAndCoursesRegistration();
                            break;
                        case "n":
                            Console.WriteLine("==============OK===============");
                            DisplayHomepage();
                            break;
                        default:
                            Console.WriteLine("Wrong choice, try again");
                            DisplayHomepage();
                            break;
                    }
                    break;
                }
            }
        }
        //تعديل المقررات المسجلة مسبقاً
        static void ModifyRegisteredCourses(int i)
        {
            int modifyCount = 0;
            string answer = "";
            //Xشرط ان يكون الحقل يوجد به علامة 
            if (Students[i, 2] == CourseList[0])
            { //IPG101لحذف  التسجيل لمادة 
                Console.Write("IPG101 Registered, Cancel it (yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 2] = "";
                        break;
                    case "n":
                        modifyCount++;
                        break;
                    
                }
            }
            else
            {//IPG101 للتسجيل على مادة
                Console.Write("IPG101 Not Registered, Register it(yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 2] = CourseList[0];
                        modifyCount++;
                        break;
                }
            }
            if (Students[i, 3] == CourseList[1])

            {//IPG201 لالغاء التسجيل على مادة 
                Console.Write("IPG201 Registered, Cancel it (yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 3] = "";
                        break;
                    case "n":
                        modifyCount++;
                        break;
                }
            }
            else
            {//IPG201 للتسجيل على مادة
                Console.Write("IPG201 Not Registered, Register it(yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 3] = CourseList[1];
                        modifyCount++;
                        break;
                }
            }
            if (Students[i, 4] == CourseList[2])
            {//IPG202 لالغاء التسجيل على مادة 
                Console.Write("IPG202 Registered, Cancel it (yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 4] = "";
                        break;
                    case "n":
                        modifyCount++;
                        break;
                }
            }
            else
            {//IPG202 للتسجيل على مادة
                Console.Write("IPG202 Not Registered, Register it(yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 4] = CourseList[2];
                        modifyCount++;
                        break;
                }
            }
            if (Students[i, 5] == CourseList[3])
            {//IPG203 لالغاء التسجيل على مادة 
                Console.Write("IPG203 Registered, Cancel it (yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 5] = "";
                        break;
                    case "n":
                        modifyCount++;
                        break;
                }
            }
            else
            {//IPG203 للتسجيل على مادة
                Console.Write("IPG203 Not Registered, Register it(yes,no): ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Students[i, 5] = CourseList[3];
                        modifyCount++;
                        break;
                }
            }
            //وضع عدد البرامج في كل سطر من العامود السادس
            Students[i, 6] = Convert.ToString(modifyCount);
        }
        // طباعة قائمة تتضمن أسماء الطلاب وبرامجهم 

        static void PrintStudentsAndCoursesList()
        {
            Console.WriteLine("List of Students and Courses ");
            Console.WriteLine("Name\tProgram\tIPG101\tIPG201\tIPG202\tIPG203\tCount");
            Console.WriteLine("------------------------------------------------------");
            for (int i = 0; i < Students.GetLength(0); i++)
            {
                // اذا الاسم موجود وغير فارغ
                if (Students[i, 0] != null)
                {
                    // طباعة الاسم والمادة 
                    Console.Write(Students[i, 0] + "\t" + Students[i, 1] + "\t");
                    // طباعة علامة مكان البرنانج المسجل فيه الطالب
                    Console.Write(Students[i, 2] == CourseList[0] ? "  X\t" : "\t");
                    Console.Write(Students[i, 3] == CourseList[1] ? "  X\t" : "\t");
                    Console.Write(Students[i, 4] == CourseList[2] ? "  X\t" : "\t");
                    Console.Write(Students[i, 5] == CourseList[3] ? "  X\t" : "\t");
                    Console.WriteLine(Students[i, 6]);
                    Console.WriteLine("------------------------------------------------------");
                }
            }
            DisplayHomepage();
        }

        static void PrintStudentsAndCoursesOrderedList()
        {
            Console.WriteLine("List of Students and Courses Ordered ");
            Console.WriteLine("Name\tProgram\tIPG101\tIPG201\tIPG202\tIPG203\tCount");
            Console.WriteLine("------------------------------------------------------");

            for (int i = 0; i < Students.GetLength(0); i++)
            {
                //  لتحديد عدد المقررات المسجلة
                switch (Students[i, 6])
                {
                    case "4":
                        // طباعة معلومات الطالب إذا كان عدد المواد المسجلة 4
                        Print_information(i);
                        break;
                    case "3":
                        // طباعة معلومات الطالب إذا كان عدد المواد المسجلة 3
                        Print_information(i);
                        break;
                    case "2":
                        // طباعة معلومات الطالب إذا كان عدد المواد المسجلة 2
                        Print_information(i);
                        break;
                    case "1":
                        // طباعة معلومات الطالب إذا كان عدد المواد المسجلة 1
                        Print_information(i);
                        break;
                    case "0":
                        // طباعة معلومات الطالب إذا كان عدد المواد المسجلة 0
                        Print_information(i);
                        break;

                }
            }

            // العودة إلى الصفحة الرئيسية
            DisplayHomepage();
        }

        static void Print_information(int i)
        {
            Console.Write(Students[i, 0] + "\t" + Students[i, 1] + "\t");

            //X للتحقق  من المقرر المسجل ووضع علامة 
           

            switch (Students[i, 2])
            {

                case "IPG101":
                    Console.Write("  X\t");
                    break;
                default:
                    Console.Write("\t");
                    break;
            }

            switch (Students[i, 3])
            {
                case "IPG201":
                    Console.Write("  X\t");
                    break;
                default:
                    Console.Write("\t");
                    break;
            }

            switch (Students[i, 4])
            {
                case "IPG202":
                    Console.Write("  X\t");
                    break;
                default:
                    Console.Write("\t");
                    break;
            }

            switch (Students[i, 5])
            {
                case "IPG203":
                    Console.Write("  X\t");
                    break;
                default:
                    Console.Write("\t");
                    break;
            }

            Console.WriteLine(Students[i, 6]);
            Console.WriteLine("------------------------------------------------------");
        }
        // الطالب المسجلين في مقرر معين من برنامج معين 
        static void DisplayStudentsInCourseAndProgram()
        {
            Console.WriteLine("List of Students and Courses");
            Console.WriteLine("Choice Program (0=>BIT, 1=>BAIT, 2=>TIC):");
          
            string Choice_Program = Console.ReadLine();

            //  لتحديد البرنامج المختار
            switch (Choice_Program)
            {
                case "0":
                    Course_Count(0);
                    break;
                case "1":
                    Course_Count(1);
                    break;
                case "2":
                    Course_Count(2);
                    break;
                default:
                    Console.WriteLine("not found this Program");
                     DisplayStudentsInCourseAndProgram();
                    return;
            }
        }
        static void Course_Count(int programIndex)
        {
            Console.WriteLine(" Choice Course (0=>IPG101, 1=>IPG201, 2=>IPG202, 3=>IPG203): ");
            string Choice_Course = Console.ReadLine();
            Console.WriteLine("Name : ");
            Console.WriteLine("------------");

            for (int i = 0; i < Students.GetLength(0); i++)
            {
                // التأكد من البرنامج المختار و المقرر الدراسي  المسجل
                bool isProgramMatched = Students[i, 1] == ProgramList[programIndex];
                bool isCourseMatched = false;
                //لتحديد المقرر الدراسي المسجلة
                switch (Choice_Course)
                {
                    case "0":
                        isCourseMatched = Students[i, 2] == CourseList[0];
                        break;
                    case "1":
                        isCourseMatched = Students[i, 3] == CourseList[1];
                        break;
                    case "2":
                        isCourseMatched = Students[i, 4] == CourseList[2];
                        break;
                    case "3":
                        isCourseMatched = Students[i, 5] == CourseList[3];
                        break;
                    default:
                        Console.WriteLine("Course not found");
                        return;
                }

                if (isProgramMatched && isCourseMatched)
                {
                    Console.WriteLine(Students[i, 0]);
                    Console.WriteLine("------------");
                }
            }

            DisplayHomepage();
        }




        //  طباعة إحصائية تتضمن أعداد الطالب المسجلين على كل مقرر في كل برنامج

        static void PrintGlobalSummary()
        {
            for (int student = 0; student < Students.GetLength(0); student++)
            {
                for (int program = 0; program < ProgramList.Length; program++)
                {
                    if (ProgramList[program] == Students[student, 1])
                    {
                        GlobalCourses(program, student);
                    }
                }
            }
            //طباعة عدد الطلاب
            Console.WriteLine("Course\t BIT\t BAIT\t TIC");
            //طباعة اسم المقرر
            for (int course = 0; course < CourseList.Length; course++)
            {
                Console.Write(CourseList[course]);
                for (int i = 0; i < ProgramList.Length; i++)
                {
                    Console.Write("\t  " + CourseCount[course, i]);
                }
                Console.WriteLine("\n-----------------------------");
            }
            DisplayHomepage();
        }
        //   تعبئة المصفوفة حسب المواد المسجلة
            static void GlobalCourses(int program, int student)
            {
                switch (Students[student, 2])
                {
                    case "IPG101":
                        CourseCount[0, program]++;
                        break;
                }

                switch (Students[student, 3])
                {
                    case "IPG201":
                        CourseCount[1, program]++;
                        break;
                }

                switch (Students[student, 4])
                {
                    case "IPG202":
                        CourseCount[2, program]++;
                        break;
                }

                switch (Students[student, 5])
                {
                    case "IPG203":
                        CourseCount[3, program]++;
                        break;
                }
            }

            
        

        // للخروج من البرنامج
        static void ExitProgram()
        {
          
            Console.WriteLine("Thanks for trying our program, see you later ");
        }
    }
}
        




