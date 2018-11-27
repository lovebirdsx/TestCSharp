public enum WeekDay {
    Monday,
    Tuesday,
    Wendsday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

void OutputDay(WeekDay day) {
    switch (day)
    {
        case WeekDay.Monday:
            Console.WriteLine("Monday");
            break;
        
        case WeekDay.Tuesday:
            Console.WriteLine("Tuesday");
            break;
        
        case WeekDay.Wendsday:
            Console.WriteLine("Wendsday");
            break;

        case WeekDay.Thursday:
            Console.WriteLine("Thursday");
            break;

        case WeekDay.Friday:
            Console.WriteLine("Friday");
            break;

        case WeekDay.Saturday:
            Console.WriteLine("Saturday");
            break;

        case WeekDay.Sunday:
            Console.WriteLine("Sunday");
            break;
    }
}

OutputDay(WeekDay.Monday);

bool TestFoo(int foo) {
    switch (foo) {
        case 1:
        case 2:
        case 3:
        case 4:
            return true;
        default:
            return false;
    }
}

Console.WriteLine(TestFoo(1));