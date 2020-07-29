using System.Collections.Generic;
namespace FileOperationLibrary
{
    interface IFileOperation
    {
        void AddToFile(object obj, string staffname);
        void RetrieveAllFromFile(string staffname);
        void DeleteFromFile(int id, string staffname);
        // void UpdateFile(object obj, string staffname);
    }
}