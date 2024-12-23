// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;
using System.Text;

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
                    output = output + chars.Substring(tap_count - 1, 1);
                    StringBuilder sb = new StringBuilder(output);
                    int index = sb.Length - 2;
                    if (index >= 0)
                    {
                        sb.Remove(index, 1);
                        output = sb.ToString();
                    }
                    

                }
                else if (tap_count == 1)
                {
                    
                    output = output + chars.Substring(tap_count - 1, 1);
                }
                 
                


            }
        }

    }
    
    return output;
}