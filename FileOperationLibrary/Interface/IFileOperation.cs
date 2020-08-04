using System.Collections.Generic;
namespace FileOperationLibrary
{
    interface IFileOperation
    {
        void AddToFile<T>(object obj);
        void RetrieveAllFromFile<T>();
        void DeleteFromFile<T>(int id);
        void UpdateFile<T>(int id, object obj);
        void RetrieveFromFile<T>(string name);

    }
}