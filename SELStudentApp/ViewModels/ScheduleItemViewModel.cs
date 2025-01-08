using SELStudentApp.Core.Models;

namespace SELStudentApp.ViewModels;

public record ScheduleItemViewModel(SELScheduleItem Model)
{
    public string StartTime => Model.ParaNumber switch
    {
        1 => "08:30",
        2 => "10:10",
        3 => "11:50",
        4 => "13:30",
        5 => "15:10",
        6 => "16:50",
        7 => "18:30",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string EndTime => Model.ParaNumber switch
    {
        1 => "09:50",
        2 => "11:30",
        3 => "13:10",
        4 => "14:50",
        5 => "16:30",
        6 => "18:10",
        7 => "19:50",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string ClassTypeName => Model.ClassType switch
    {
        ClassType.Lecture => "Лекція",
        ClassType.Practice => "Практична",
        ClassType.Lab => "Лабораторна",
        ClassType.Consultation => "Консультація",
        ClassType.SemesterExams => "Екзамен",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string? Teacher => Model.Teacher.FullName ?? Model.Teacher.ShortName;

    public string? Classroom
    {
        get
        {
            if (Model.Room is SELRoom room)
            {
                if (room.CaseNumber is null)
                    return $"Ауд. {room.Name}";
                if (room.Floor is null)
                    return $"{room.CaseNumber}-й корпус, ауд. {room.Name}";
                return $"{room.CaseNumber}-й корпус, {room.Floor}-й поверх, ауд. {room.Name}";
            }
            return null;
        }
    }
}
