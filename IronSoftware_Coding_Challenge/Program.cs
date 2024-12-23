// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;
using System.Text;

// testing on the given example in the challenge
Console.WriteLine(OldPhonePad("333#"));
Console.WriteLine(OldPhonePad("227 *#"));
Console.WriteLine(OldPhonePad("333#"));
Console.WriteLine(OldPhonePad("4433555 555666#"));
Console.WriteLine(OldPhonePad("8 88777444666*664#"));


Console.ReadLine();
 
static string OldPhonePad(string input)
{
    Dictionary<char, string> keymap = new Dictionary<char, string>();

    char prev_Key = '0';
    int tap_count = 0;
    string output = string.Empty;
    keymap.Add('1', "");
    keymap.Add('2', "ABC");
    keymap.Add('3', "DEF");
    keymap.Add('4', "GHI");
    keymap.Add('5', "JKL");
    keymap.Add('6', "MNO");
    keymap.Add('7', "PQRS");
    keymap.Add('8', "TUV");
    keymap.Add('9', "WXYZ");
    keymap.Add('0', " ");
    keymap.Add('*', " ");

    //OldPhonePad(“33#”) => output: E
    //OldPhonePad(“227*#”) => output: B
    //OldPhonePad(“4433555 555666#”) => output: HELLO
    //OldPhonePad(“8 88777444666 * 664#”) => output: ?????

    foreach (char key in input)
    {
        if (key == '#') break;
        else if (key == '0') continue;
        else if (key == ' ')
        {
            prev_Key = '0';
            continue;
        }
        else
        {

            if (key == prev_Key)
            {
                //To keep track the same key how many times
                tap_count++;
            }
            else
            {
                tap_count = 1;
                prev_Key = key;
            }

            if (keymap.ContainsKey(key))
            {
                string chars = keymap[key];
                if (tap_count == 2 || tap_count == 3 || key == '*')
                {
                    //keymap.Add('2', "ABC");
                    //to get the second or third charactor of the string based on tap_count
                    //if 22 , it will get B
                    //if 222 , it will get C
                    // And assign the value to output
                    output = output + chars.Substring(tap_count - 1, 1);
                    StringBuilder sb = new StringBuilder(output);
                    int index = sb.Length - 2;
                    if (index >= 0)
                    {
                        //This removal is to handle the input scenario such as 22 or 222
                        //because previously the first charctor of the key was assigned to the output
                        //it is needed to remove it from the output
                        sb.Remove(index, 1);
                        //after removing the value, assign the remaining value back to output
                        output = sb.ToString();
                    }
                    

                }
                else if (tap_count == 1)
                {
                    //keymap.Add('2', "ABC");
                    //to get the first charactor of the string
                    //if the input is 2, it will get A
                    //and assign it to the output
                    output = output + chars.Substring(tap_count - 1, 1);
                }
                 
                


            }
        }

    }
    
    return output;
}