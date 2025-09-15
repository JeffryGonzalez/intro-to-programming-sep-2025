using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc.Domain;
public class Marketing
{
    public void SendEmailToEmployeeWithThanks(IProvideEmployeeInformation employee, string note, int delay)
    {
        // send an email to this employee with a note
        delay = 20;
        note = note.ToUpper();
        
        
        Console.WriteLine($"Sending an email to {employee.EmailAddress}: { note}");
    }
}
