using System.Collections.Generic;
using System.Linq;
using System;

namespace ReturnExceptionalCode {
    class Program {
        static void Main(string[] args) {
            var inputs = new List<string> { "123", "4, 5, 6", "hello" };
            inputs.ForEach(str => {
                try { ChooseInput(str); }
                catch (NumberBox box) { Console.WriteLine($"Got a number: {box.Number}"); }
                catch (ListBox box)   { Console.WriteLine($"Got a list  : [{String.Join(", ", box.Numbers)}]"); }
                catch (StringBox box) { Console.WriteLine($"Got a string: {box.Input}"); }
            });
        }

        static void ChooseInput(string input) {
            // if IsNumber
            try { throw new NumberBox(Int32.Parse(input)); }
            catch (FormatException) {}

            // else if isList
            try { throw new ListBox(input.Split(",").Select(n => Int32.Parse(n.Trim())).ToList()); }
            catch (FormatException) {}

            // else
            throw new StringBox(input);
        }
    }

    public class NumberBox: Exception {
        public Int32 Number { get; }
        public NumberBox(Int32 number) { this.Number = number; }
    }

    public class ListBox: Exception {
        public List<Int32> Numbers { get; }
        public ListBox(List<Int32> numbers) { this.Numbers = numbers; }
    }

    public class StringBox: Exception {
        public String Input { get; }
        public StringBox(String input) { this.Input = input; }
    }
}
