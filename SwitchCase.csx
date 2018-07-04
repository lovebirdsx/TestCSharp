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
