using System.Collections.Generic;
namespace FileOperationLibrary
{
    interface IFileOperation
    {
        void AddToFile(object obj, string staffname);
        void RetrieveAllFromFile(string staffname);
        void DeleteFromFile(int id, string staffname);
        void UpdateFile(int id, string staffname, object obj);
        void RetrieveFromFile(string name, string staffname);
        //object GetObj(int id ,string staffname, object obj);
    }
}