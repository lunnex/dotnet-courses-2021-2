using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static Dictionary<string, int> dictionary = new Dictionary<string, int>();
        static Dictionary<string, int> CountWords(string str)
        {

            int value = 0;
            
                
            if (!dictionary.ContainsKey(str))
            {
                dictionary.TryAdd(str, 1);
            }
            else
            {
                dictionary.TryGetValue(str, out value);
                value++;
                dictionary[str] = value;
                    //Console.WriteLine(str + " " + value);
            }
            return dictionary;
        }

        static void Main(string[] args)
        {
            string str = @"WHEN in the course of human Events, it becomes necessary for one People to dissolve the 
                            Political Bands which have connected them with another, and to assume among the Powers of 
                            the Earth, the separate and equal Station to which the Laws of Nature and of Nature’s God entitle them, 
                            a decent Respect to the Opinions of Mankind requires that they should declare the causes which impel them 
                            to the Separation.We hold these Truths to be self-evident, that all Men are created equal, that they are 
                            endowed by their Creator with certain unalienable Rights, that among these are Life, Liberty, and the pursuit 
                            of Happiness—-That to secure these Rights, Governments are instituted among Men, deriving their just Powers from the 
                            Consent of the Governed, that whenever any Form of Government becomes destructive of these Ends, it is the Right of the 
                            People to alter or abolish it, and to institute a new Government, laying its Foundation on such Principles, and organizing 
                            its Powers in such Form, as to them shall seem most likely to effect their Safety and Happiness. Prudence, indeed, 
                            will dictate that Governments long established should not be changed for light and transient Causes; and accordingly all 
                            Experience hath shewn, that Mankind are more disposed to suffer, while Evils are sufferable, than to right themselves by 
                            abolishing the Forms to which they are accustomed. But when a long Train of Abuses and Usurpations, pursuing invariably 
                            the same Object, evinces a Design to reduce them under absolute Despotism, it is their Right, it is their Duty, 
                            to throw off such Government, and to provide new Guards for their future Security. Such has been the patient Sufferance of 
                            these Colonies; and such is now the Necessity which constrains them to alter their former Systems of Government. The History
                            of the Present King of Great-Britain is a History of repeated Injuries and Usurpations, all having in direct Object the
                            Establishment of an absolute Tyranny over these States. To prove this, let Facts be submitted to a candid World.";
            str = str.ToLower();
            Regex regex = new Regex(@"\w*\w");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            MatchCollection strArr = regex.Matches(str);


            foreach (Match item in strArr)
            {
               dict = CountWords(item.ToString());
            }

            Dictionary<string, int>.KeyCollection kc = dict.Keys;

            foreach (string item in kc)
            {
                dict.TryGetValue(item, out int value);
                Console.WriteLine(item + " " + value);
            }


        }
    }
}
