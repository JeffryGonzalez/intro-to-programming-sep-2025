

export const add = (numbers: string):number => {
    const commatAt = numbers.indexOf(',');
    if(commatAt > 0) {
       return  numbers.split(/,|\n/) // ["1","2","3 "]
       .map(n => parseInt(n)) // n: string => b: number [1,2,3]
       .reduce((a,b) => a + b) // [1,2,3] => 6
    }
    return numbers === "" ? 0 : +numbers;
}