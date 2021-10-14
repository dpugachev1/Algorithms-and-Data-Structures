using System;
using System.Text;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
public class RotationalCipher
{

    private static string rotationalCipher(String input, int rotationFactor)
    {
        StringBuilder builder = new StringBuilder(input);
        for (int i = 0; i < input.Length; i++)
        {
            builder[i] = RotateCharacter(input[i], rotationFactor);
        }
        return builder.ToString();
    }

    private static char RotateCharacter(char cInput, int rotationFactor)
    {
        //determing if char is a number
        if (Char.IsLetterOrDigit(cInput))
        {
            if (Char.IsNumber(cInput))
            {
                return (char)(9 % (int)cInput + rotationFactor);
            }
            else
            {
                //there is 28 letters so rotation factor is either
                return cInput;

            }
        }
        else //if non-alphanumeric return same character
        {
            return cInput;
        }
    }
}