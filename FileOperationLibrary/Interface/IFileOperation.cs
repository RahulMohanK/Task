using System.Collections.Generic;
namespace FileOperationLibrary
{
    interface IFileOperation
    {
        void AddToFile<T>(object obj, string staffname);
        void RetrieveAllFromFile<T>(string staffname);
        void DeleteFromFile(int id, string staffname);
        void UpdateFile<T>(int id, string staffname, object obj);
        void RetrieveFromFile(string name, string staffname);
        //object GetObj(int id ,string staffname, object obj);
    }
}