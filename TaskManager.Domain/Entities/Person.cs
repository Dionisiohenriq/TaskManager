namespace TaskManager.Domain.Entities;

public class Person : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public ICollection<PersonTask> Tasks { get; set; }


    public Person(string? name, string? email, DateTime birthDate)
    {
        SetName(name);
        SetEmail(email);
        SetBirthDate(birthDate);
    }

    public void SetName(string? name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        Name = name;
    }

    public void SetEmail(string? email)
    {
        if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
        Email = email;
    }

    public void SetBirthDate(DateTime birthDate)
    {
        if (birthDate == DateTime.MinValue) throw new ArgumentNullException(nameof(birthDate));
        BirthDate = birthDate;
    }
}