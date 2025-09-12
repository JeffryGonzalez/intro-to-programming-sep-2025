import { send } from "vite";


export const add = (numbers: string):number => {
    const commatAt = numbers.indexOf(',');
    if(commatAt > 0) {
       return  numbers.split(/,|\n/) // ["1","2","3 "]
       .map(n => parseInt(n)) // n: string => b: number [1,2,3]
       .reduce((a,b) => a + b) // [1,2,3] => 6
    }
    return numbers === "" ? 0 : +numbers;
}

/*   public void SendEmailToEmployeeWithThanks(IProvideEmployeeInformation employee, string note, int delay)
   {
       // send an email to this employee with a note
       delay = 20;
       note = note.ToUpper();
       
       
       Console.WriteLine($"Sending an email to {employee.EmailAddress}: { note}");
   } */


       // Strctural typing.
export function sendEmailToEmployeeWithThanks(employee: { readonly emailAddress: string}, note:string, delay:number) {

    console.log(`Sending an email to ${employee.emailAddress}: ${note.toUpperCase()}`);
}

const sally = {
    name: 'Sally Bradley',
    job: 'CEO',
    salary: 1000000,
    emailAddress: 'sally@company.com'
};

sendEmailToEmployeeWithThanks(sally, 'Thanks for all your hard work', 10);