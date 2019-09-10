using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndReplace
{

    //Allow for large files. 
    //The easy way to to read it all into memory and then do the replace using String.Replace.

    class FileSearchAndReplace
    {
        static void Main(string[] args)
        {
            SearchAndReplace("D:\\test.txt", "D:\\test_out.txt", "file we", "foobar");
        }
        static void SearchAndReplace(string inFile, string outFile, string searchText, string replaceText)
        {
            if (!File.Exists(inFile))
            {
                throw new FileNotFoundException();
            }
            var reader = new StreamReader(inFile);
            var writer = new StreamWriter(outFile);

            var searchLength = searchText.Length;
            char[] buffer = new char[searchLength];
            var i = 0;

            reader.BaseStream.Seek(i, SeekOrigin.Begin);
            reader.DiscardBufferedData();

            while (!reader.EndOfStream)
            {

                reader.Read(buffer, 0, searchLength);
                var test = new string(buffer);
                //if buffer matches replace and write
                if (test == searchText)
                {
                    //move source seek head searchLength
                    writer.Write(replaceText.ToCharArray());
                    i += searchLength;

                }
                else
                {
                    //write char and move seek window 1 character
                    i++;
                    writer.Write(buffer[0]);

                }

                reader.BaseStream.Seek(i, SeekOrigin.Begin);
                reader.DiscardBufferedData();

                //write rest of file, and break.
                if (reader.BaseStream.Length - reader.BaseStream.Position < searchLength)
                {
                    var remainderBufferLenght = reader.BaseStream.Length - reader.BaseStream.Position;
                    char[] endBlob = new char[remainderBufferLenght];
                    reader.Read(endBlob, 0, Convert.ToInt32(remainderBufferLenght));
                    writer.Write(endBlob);
                    break;
                }

            }

            reader.Close();
            writer.Close();
        }
    }
}
